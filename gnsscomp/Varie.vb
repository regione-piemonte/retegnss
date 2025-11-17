'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO
Imports System.Net.Mail

Module Varie

    '''***********************************************************************
    ''' Nome:       Prep_fold
    ''' Preparazione delle cartelle utili.
    '''**********************************************************************
    Sub Prep_fold(pthCfg As String, pthGEN As String, pthScr As String, pthCrd As String, pthGra As String, pthLog As String)

        If Not Directory.Exists(pthCfg) Then Directory.CreateDirectory(pthCfg)

        If Not Directory.Exists(pthGEN) Then Directory.CreateDirectory(pthGEN)

        If Not Directory.Exists(pthScr) Then Directory.CreateDirectory(pthScr)

        If Not Directory.Exists(pthCrd) Then Directory.CreateDirectory(pthCrd)

        If Not Directory.Exists(pthGra) Then Directory.CreateDirectory(pthGra)

        If Not Directory.Exists(pthLog) Then Directory.CreateDirectory(pthLog)

    End Sub


    '''***********************************************************************
    ''' Nome:       Prep_file
    ''' Preparazione dei file:
    ''' - per la raccolta delle crd compensate delle stazioni (.crd),
    ''' - per la registrazione di eventi di cambio antenna (.evnt),
    ''' - per la raccolta delle ripetibilità delle crd compensate (.rep)
    '''**********************************************************************
    Sub Prep_file(listaClu() As String, nomeCamp As String,
                  crdPath As String, graPath As String)

        Dim STAlines As String()
        Dim STAread As StreamReader
        Dim EVNTwri As StreamWriter
        Dim stazClu, STAline, antenna, antenna_old, index1, index2, index3 As String
        Dim i, j As Integer


        ' * Scrittura files _.evnt *
        'Scorro il file _.STA per ricavare gli indici delle sezioni in cui è suddiviso il file 
        Try
            STAlines = File.ReadAllLines(Environ("D") & "\REF52\" & nomeCamp & ".STA")
            STAread = My.Computer.FileSystem.OpenTextFileReader(Environ("D") & "\REF52\" & nomeCamp & ".STA")

            Do While STAread.Peek() > 0

                STAline = STAread.ReadLine
                If Left(STAline, 9) = "TYPE 001:" Then index1 = i + 5
                If Left(STAline, 9) = "TYPE 002:" Then index2 = i - 3
                If Left(STAline, 9) = "TYPE 003:" Then index3 = i - 3
                i += 1
            Loop
            STAread.Close()

        Catch ex As Exception

            frmPrincipale.txtLog.SelectionColor = Color.Red
            frmPrincipale.txtLog.SelectedText = DateTime.Now & " !!! ERRORE nella lettura del file " & nomeCamp & ".STA" & vbCrLf
        End Try


        'Per ogni stazione del Cluster elencata nella sezione1 del file,
        'ne vado a ricercare nella sezione2 gli eventi di cambio antenna
        For Each stazClu In listaClu
            For i = index1 To index2
                If Left(STAlines(i), 4) = stazClu Then

                    File.Create(graPath & stazClu & ".evnt").Close()
                    EVNTwri = File.AppendText(graPath & stazClu & ".evnt")
                    EVNTwri.WriteLine("### EVENTI DI CAMBIO ANTENNA")

                    For j = index2 To index3
                        If Left(STAlines(j), 4) = stazClu Then
                            antenna = Mid(STAlines(j), 122, 80)
                            If antenna <> antenna_old Then
                                antenna_old = antenna

                                'Scrittura evento
                                EVNTwri.WriteLine(Mid(STAlines(j), 36, 2) & "\" & Mid(STAlines(j), 33, 2) & "\" & Mid(STAlines(j), 30, 2) & "," & Mid(STAlines(j), 122, 20))
                            End If
                        End If
                    Next
                    antenna_old = ""
                    EVNTwri.Close()


                    ' * Scrittura files _.crd *
                    If Not File.Exists(crdPath & stazClu & ".crd") Then
                        File.Create(crdPath & stazClu & ".crd").Close()

                        File.WriteAllText(crdPath & stazClu & ".crd", "                            ITRF2020                                              ETRF2000" & vbCrLf &
                                          "           Est (M)          Nord (M)          Hell (M)           Est (M)          Nord (M)          Hell (M)" & vbCrLf &
                                          "WEEK" & vbCrLf)
                    End If


                    ' * Scrittura files _.rep *
                    File.Create(crdPath & stazClu & ".rep").Close()
                    File.WriteAllText(crdPath & stazClu & ".rep", "         RIPETIBILITA'[mm]" & vbCrLf &
                                          "WEEK     N      E       Q      T" & vbCrLf)


                    Exit For

                End If

            Next
        Next

    End Sub


    '''********************************************************
    ''' Nome:       Prep_CRDfix
    ''' Estrapolazione delle coordintate stimate dal file SNX. 
    '''********************************************************
    Sub Prep_CRDfix(SNXfile As String, localPath As String)
        Dim SNXline, crdfile, staz, idxSol1, idxSol2, idxID1, idxID2 As String
        Dim domsList() As String
        Dim stazCrd(2) As String
        Dim i, j, k As Integer

        Dim SNXlines() As String = File.ReadAllLines(localPath & SNXfile)
        Dim SNXread As New StreamReader(localPath & SNXfile)
        Dim crdFIX_Wri As StreamWriter

        crdfile = "snx" & Strings.Mid(SNXfile, 4, 6) & "crd"
        File.Create(localPath & crdfile).Close()
        crdFIX_Wri = File.AppendText(localPath & crdfile)

        'Intestazione stile Bernese
        crdFIX_Wri.WriteLine("                                                                 ##-###-## ##:##" & vbCrLf &
                            "--------------------------------------------------------------------------------" & vbCrLf &
                            "LOCAL GEODETIC DATUM: XXXXX             EPOCH: XXXXXXXXXX" & vbCrLf &
                            vbCrLf & "NUM  STATION NAME           X (M)          Y (M)          Z (M)     FLAG" & vbCrLf)


        'Scorro il file SNX per ricavare gli indici delle sezioni in cui è suddiviso 
        Do While SNXread.Peek() > 0
            SNXline = SNXread.ReadLine
            If SNXline = "+SITE/ID" Then idxID1 = i + 2
            If SNXline = "-SITE/ID" Then idxID2 = i - 1
            If SNXline = "+SOLUTION/ESTIMATE" Then idxSol1 = i + 2
            If SNXline = "-SOLUTION/ESTIMATE" Then idxSol2 = i - 1
            i += 1
        Loop
        SNXread.Close()

        'Per ogni stazione elencata nella sezione1 del file, ne vado a ricercare nella sezione2 il numero id (DOMS)
        ReDim domsList(idxID2 - idxID1 + 1)
        k = 0
        For i = idxID1 To idxID2
            domsList(k) = Mid(SNXlines(i), 10, 9)
            k += 1
        Next

        'Scrivo nel nuovo file solo le coordinate delle stazioni permanenti
        k = 1
        For i = idxSol1 To idxSol2 Step 3
            staz = Mid(SNXlines(i), 15, 4)
            For j = 0 To 2
                stazCrd(j) = CDbl(Val(Mid(SNXlines(i + j), 48, 21))).ToString("F5")
            Next

            crdFIX_Wri.WriteLine(String.Format("{0,3}{1,6}{2,10}{3,17}{4,15}{5,15}{6,5}",
                                              k, staz, domsList(k - 1), Replace(stazCrd(0), ",", "."), Replace(stazCrd(1), ",", "."), Replace(stazCrd(2), ",", "."), "*"))
            k += 1
        Next

        crdFIX_Wri.Close()
        File.Delete(localPath & SNXfile)

    End Sub


    '''***********************************************************************
    ''' Nome:       Log_Verifica
    ''' Verifica che i files siano stati scaricati/generati e lo scrive
    '''**********************************************************************
    Sub Log_Verifica(tipoFile As String, filePath As String, tag As String)

        Dim log As String

        'Definisco il messaggio di log
        If File.Exists(filePath) Then
            Select Case tag
                Case "Download"
                    log = DateTime.Now & " [ " & tipoFile & " ] " & filePath & " - Scaricato con successo."
                    frmPrincipale.txtLog.SelectionColor = Color.Black

                Case "Compensazione"
                    log = DateTime.Now & " [ " & tipoFile & " ] " & filePath & " - Generato con successo."
                    frmPrincipale.txtLog.SelectionColor = Color.Green
            End Select
        Else
            log = DateTime.Now & " [ " & tipoFile & " ] !!! File non ottenuto! Directory: " & filePath

            If tipoFile = "RINEX" Then
                frmPrincipale.txtLog.SelectionColor = Color.Black
            Else
                frmPrincipale.txtLog.SelectionColor = Color.Red
            End If

        End If

        frmPrincipale.txtLog.SelectedText = log & vbCrLf

    End Sub

    '''***********************************************************************
    ''' Nome:       Report
    ''' Crea report in formato testuale delle elaborazioni
    '''**********************************************************************
    Function Report(testo As String, logPath As String)

        Dim reportfile = logPath & "Report_" & DateTime.Today.ToString("yyyy-MM-dd") & ".txt"

        File.Create(reportfile).Close()
        File.WriteAllText(reportfile, testo)

        Return reportfile

    End Function


    '''***********************************************************************
    ''' Nome:       Invio_email
    ''' Invio email di notifica dell'ultimazione del processo.
    '''***********************************************************************
    Sub Invio_email(smtp As String, email As String, report As String)

        Dim SmtpServer As New SmtpClient()
        Dim oMsg As New MailMessage
        Dim mail As New MailAddress(email, "Compensazione geodetica")

        'Server SMTP
        SmtpServer.Port = 25
        SmtpServer.Host = smtp

        oMsg.From = mail 'Mittente
        oMsg.To.Add(email) 'Destinatario (coincide con mittente)

        oMsg.Subject = "Risultato del calcolo di compensazione"
        oMsg.Body = "La procedura di compensazione geodetica è ultimata." & vbCrLf &
            "Prendere visione del report: " & report

        Try

            SmtpServer.Send(oMsg)
        Catch ex As Exception

            frmPrincipale.txtLog.SelectionColor = Color.Red
            frmPrincipale.txtLog.SelectedText = DateTime.Now & "!!! IMPOSSIBILE inviare notifica email!" & vbCrLf
        End Try

    End Sub


    '''***********************************************************************
    ''' Nome:       Rep_file
    ''' Scrittura del file .rep che raccogle le ripetibilità delle crd 
    ''' compensate 
    '''**********************************************************************
    Sub Rep_file(staz As String, settimana As String,
                  crdPath As String, sEN As Double, sQ As Double)

        Dim PRCread As StreamReader
        Dim PRClines As String()
        Dim REPwri As StreamWriter
        Dim PRCline, index1, index2, repE, repN, repQ As String
        Dim doy, anno As String
        Dim data_d, data_s As Date
        Dim i As Integer


        data_d = DateAdd("ww", CInt(settimana), "06-Jan-1980 00:00:00")
        data_s = DateAdd("d", 6, data_d)
        doy = Format(data_s.DayOfYear, "000")
        anno = Format(data_s.Year, "000")

        'Scorro il file _.PRC per ricavare gli indici della sezione in cui si trovano
        'le ripetibilità 
        Try
            PRCread = My.Computer.FileSystem.OpenTextFileReader(Environ("S") & "\RNX2SNX_GAL\" & anno &
                                                                "\OUT\R2S" & Strings.Right(anno, 2) & doy & "0.PRC")
            PRClines = File.ReadAllLines(Environ("S") & "\RNX2SNX_GAL\" & anno &
                                                                "\OUT\R2S" & Strings.Right(anno, 2) & doy & "0.PRC")

            Do While PRCread.Peek() > 0

                PRCline = PRCread.ReadLine
                If PRCline = "PART 9: SLIDING 7-SESSION COMPARISON OF STATION COORDINATES" Then
                    index1 = i + 11
                End If
                If Left(PRCline, 24) = " # Coordinate estimates:" Then
                    index2 = i - 1
                End If
                i += 1
            Loop
            PRCread.Close()

        Catch ex As Exception

            frmPrincipale.txtLog.SelectionColor = Color.Red
            frmPrincipale.txtLog.SelectedText = DateTime.Now & " !!! ERRORE nella lettura del file " & "\RNX2SNX_GAL\" & anno &
                                                                "\OUT\R2S" & Strings.Right(anno, 2) & doy & "0.PCR" & vbCrLf
        End Try


        'Per ogni stazione del Cluster elencata nella sezione ricavata del file,
        'ne vado a ricercare la ripetibilità
        REPwri = File.AppendText(crdPath & staz & ".rep")

        For i = index1 To index2
            If Mid(PRClines(i), 2, 4) = staz Then

                'Scrittura .rep, se la ripetibilità è maggiore della soglia apposto un *
                repN = Mid(PRClines(i), 34, 5)
                repE = Mid(PRClines(i), 40, 5)
                repQ = Mid(PRClines(i), 46, 5)

                If CDbl(Val(repN)) > sEN Or CDbl(Val(repE)) > sEN Or CDbl(Val(repQ)) > sQ Then

                    REPwri.WriteLine(String.Format("{0,4}{1,8}{2,7}{3,8}{4,5}", settimana, Format(CDbl(Val(repN)), "0.00"),
                                                                 Format(CDbl(Val(repE)), "0.00"), Format(CDbl(Val(repQ)), "0.00"), "*"))

                Else
                    REPwri.WriteLine(String.Format("{0,4}{1,8}{2,7}{3,8}", settimana, Format(CDbl(Val(repN)), "0.00"),
                                                                 Format(CDbl(Val(repE)), "0.00"), Format(CDbl(Val(repQ)), "0.00")))
                End If

                Exit For

            End If
        Next

        REPwri.Close()

    End Sub

End Module
