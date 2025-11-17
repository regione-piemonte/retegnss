'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************
Imports System.IO

Module Bernese
    '''**********************************************************************
    ''' Nome:       CompensazioneD
    ''' Effettua la compensazione giornaliera tramite il software Bernese e
    ''' ricerca gli eventuali messaggi di errore/warning.
    '''**********************************************************************
    Sub CompensazioneD(scriptPath As String, ncampagna As String, anno As String,
                       doy As String, CSR As String)
        Dim campagnaPath As String = Environ("P") & "\" & ncampagna
        Dim compensD As String = "dbpe_i" & Strings.Right(CSR, 2) & ".pl"
        Dim bernReader As StreamReader
        Dim bernResult, iline As String
        Dim flag As Integer = 1


        'AGGIUNTA: Inserito loop in previsione della possibile interruzione del processo sul modulo 202 di RNX2SNX (nessun messaggio di errore)
        Do While flag = 1

            'Parametri di processo + start
            Dim bernD As New Process
            bernD.StartInfo.UseShellExecute = False
            bernD.StartInfo.RedirectStandardOutput = True
            bernD.StartInfo.FileName = "cmd.exe"
            bernD.StartInfo.Arguments = String.Concat("/c perl " & scriptPath & compensD & " " & ncampagna & " " & anno & " " & doy & "0")
            bernD.Start()

            'Salvo lo scritto batch del Bernese
            bernReader = bernD.StandardOutput
            bernResult = bernReader.ReadToEnd()
            bernD.WaitForExit()
            bernReader.Close()

            frmPrincipale.txtLog.SelectionColor = Color.Black
            frmPrincipale.txtLog.SelectedText = DateTime.Now & bernResult & vbCrLf


            '  **** Lettura errori/warning ****

            'Se il processo si è interrotto a causa di un errore, leggo il file di output _.OUT
            'alla ricerca del modulo in cui l'errore si è verificato
            If InStr(bernResult, "BPE error") <> 0 Then

                Dim modulo, errore As String
                Dim rreport As New StreamReader(campagnaPath & "\BPE\RNX2SNX_I" & Strings.Right(CSR, 2) & ".OUT")
                Dim rmodulo As String()

                Do While rreport.Peek() > 0
                    iline = rreport.ReadLine

                    'Cerco il rigo in cui è segnalato l'errore e copio il numero del modulo relativo
                    If InStr(iline, "Script finished  ERROR") Then
                        modulo = Mid(iline, 29, 7)
                        errore = " [ COMPENSAZIONE D:" & Right(anno, 2) & doy & " ] !!! Errore nel MODULO [ " & modulo & " ]:"

                        'Apro il file di testo relativo al modulo e copio il contenuto
                        rmodulo = File.ReadAllLines(campagnaPath & "\BPE\" & ncampagna & Right(anno, 2) & doy & "0_" & modulo & ".LOG")

                        For Each lmod In rmodulo
                            errore = String.Concat(errore & lmod & vbCrLf)
                        Next
                        frmPrincipale.txtLog.SelectionColor = Color.Red
                        frmPrincipale.txtLog.SelectedText = DateTime.Now & errore & vbCrLf

                    End If
                Loop
                rreport.Close()


                'AGGIUNTA : Se intercorre un errore sul modulo 202 che non lascia trascrizione sul file BPE interrompendo il processo bruscamente,
                'elimino il file RINEX che ha generato questo problema, rintracciandolo tramite il file SMT (es. campagnaPath\BPE\SMT220860001.BPE)
                If Left(modulo, 3) = "202" And errore.Contains("***") = False Then
                    Dim smtLines() As String = File.ReadAllLines(campagnaPath & "\BPE\SMT" & Right(anno, 2) & doy & "0" & Right(modulo, 3) & ".BPE")
                    Dim nstaz, rnx As String

                    'Per ogni file RINEX processato nel sottoinsieme segnato sul file SMT, controllo se esiste la sua versione lisciata
                    For Each smtLine In smtLines
                        If Not File.Exists(Left(smtLine, Len(smtLine) - 3) & "SMT") Then

                            nstaz = Left(smtLine.Split("\")(UBound(smtLine.Split("\"))), 4)
                            rnx = My.Computer.FileSystem.GetFiles(Environ("D") & "\RINEX3\", 2, nstaz & "*_" & anno & doy & "0000*")(0)
                            File.Delete(rnx)

                            errore = " [ COMPENSAZIONE D: " & Right(anno, 2) & doy & " ] !!! Errore nel MODULO [ " & modulo & " ] per il file " & rnx & ". File eliminato."

                            'Segno l'operazione di eliminazione del file RINEX
                            frmPrincipale.txtLog.SelectionColor = Color.Red
                            frmPrincipale.txtLog.SelectedText = DateTime.Now & errore & vbCrLf

                            'Trovato il RINEX che ha generato l'errore, esco dal For
                            Exit For
                        End If
                    Next

                Else
                    flag = 0

                End If

            Else
                'Il processo è terminato con successo.
                'Disattivo il loop
                flag = 0

                'Leggo i warning relativi a discrepanze tra il file .STA e gli header dei RINEX
                Dim rwarn As New StreamReader(campagnaPath & "\OUT\RNX" & Right(anno, 2) & doy & "0.ERR")
                Dim warning As String = ""

                'Apro il file RNXAADDD.ERR dove sono segnati i warning con ### SR RXOANT
                Do While rwarn.Peek() > 0
                    iline = rwarn.ReadLine

                    If InStr(iline, "### SR RXOANT") Then
                        Do While iline <> ""

                            warning = String.Concat(warning & iline & vbCrLf)
                            iline = rwarn.ReadLine
                        Loop

                        frmPrincipale.txtLog.SelectionColor = Color.Orange
                        frmPrincipale.txtLog.SelectedText = warning
                        warning = ""
                    End If
                Loop

                rwarn.Close()
            End If
        Loop

    End Sub


    '''***********************************************************************
    ''' Nome:       CompensazioneW
    ''' Effettua la compensazione settimanale tramite il software Bernese e
    ''' ricerca gli eventuali messaggi di errore/warning.
    '''**********************************************************************
    Sub CompensazioneW(scriptPath As String, ncampagna As String, anno As String,
                       doy As String, settimana As String, CSR As String)

        Dim campagnaPath As String = Environ("P") & "\" & ncampagna
        Dim compensW As String = "wbpe_i" & Strings.Right(CSR, 2) & ".pl"
        Dim bernReader As StreamReader
        Dim bernResult, iline As String

        'Parametri di processo + start
        Dim bernW As New Process
        bernW.StartInfo.UseShellExecute = False
        bernW.StartInfo.RedirectStandardOutput = True
        bernW.StartInfo.FileName = "cmd.exe"
        bernW.StartInfo.Arguments = String.Concat("/c perl " & scriptPath & compensW & " " & ncampagna & " " & anno & " " & doy & "0")
        bernW.Start()

        'Salvo lo scritto batch del Bernese
        bernReader = bernW.StandardOutput
        bernResult = bernReader.ReadToEnd()
        bernW.WaitForExit()
        bernReader.Close()

        frmPrincipale.txtLog.SelectionColor = Color.Black
        frmPrincipale.txtLog.SelectedText = DateTime.Now & bernResult & vbCrLf


        '  **** Lettura errori/warning ****

        'Se il processo si è interrotto a causa di un errore, leggo il file _.OUT
        'alla ricerca del modulo in cui l'errore si è verificato
        If InStr(bernResult, "BPE error") <> 0 Then

            Dim errore, modulo As String
            Dim rreport As New StreamReader(campagnaPath & "\BPE\WKLYSNX_I" & Strings.Right(CSR, 2) & ".OUT")
            Dim rmodulo As String()

            'Cerco il rigo in cui è segnalato l'errore e copio il numero del modulo relativo
            Do While rreport.Peek() > 0

                iline = rreport.ReadLine
                If InStr(iline, "Script finished  ERROR") Then

                    modulo = Mid(iline, 29, 7)
                    errore = " [ COMPENSAZIONE W:" & settimana & " ] !!! Errore nel MODULO [ " & modulo & " ]:"

                    'Apro il file di testo relativo al modulo e copio il contenuto
                    rmodulo = File.ReadAllLines(campagnaPath & "\BPE\WKLY" & Right(anno, 2) & doy & "0_" & modulo & ".LOG")

                    For Each lmod In rmodulo
                        errore = String.Concat(errore & lmod & vbCrLf)
                    Next

                    frmPrincipale.txtLog.SelectionColor = Color.Red
                    frmPrincipale.txtLog.SelectedText = errore & vbCrLf

                End If
            Loop

        Else
            'Se il processo è terminato con successo, leggo il CHI**2 della compensazione e la Ripetibilità infrasettimanale
            Dim ANQout As New StreamReader(campagnaPath & "\OUT\WEKCMP_" & settimana & ".OUT")
            Dim ANQsum As New StreamReader(campagnaPath & "\OUT\WEKCMP_" & settimana & ".SUM")
            Dim RMS, Rep As String

            'Apro il file di testo WEK_CMP_WWWW.OUT e copio i valori del CHI**2 e RMS A posteriori
            Do While ANQout.Peek() > 0
                iline = ANQout.ReadLine

                If InStr(iline, "RMS OF UNIT WEIGHT FOR COORDINATE COMPARISON") Then
                    RMS = iline
                End If
            Loop
            ANQout.Close()

            'Apro il file di testo WEK_CMP_WWWW.SUM e copio la Ripetibilità infrasettimanale
            Do While ANQsum.Peek() > 0
                iline = ANQsum.ReadLine

                If InStr(iline, "# Coordinate estimates") Then
                    Rep = " RIPETIBILITA' (MM): N=" & Mid(iline, 35, 4) & "   E=" & Mid(iline, 41, 4) & "   H=" & Mid(iline, 47, 4)
                End If
            Loop
            ANQsum.Close()

            frmPrincipale.txtLog.SelectionColor = Color.Green
            frmPrincipale.txtLog.SelectedText = DateTime.Now & " [ COMPENSAZIONE W:" & settimana & " ] :" & vbCrLf &
                              RMS & vbCrLf & Rep & vbCrLf
        End If

    End Sub
End Module

