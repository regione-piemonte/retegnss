'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

''******************************************************************************
''  PROGRAM: Compensazione Automatica v. 1.0.0
''
''  AUTHOR : CSI Piemonte 2025
''
''  PURPOSE:  Programma per la compensazione automatizzata di un cluster di
''            stazioni GNSS tramite script del software proprietario BERNESE.
''            Le operazioni effettuate sono:
''              - download dei prodotti necessari al calcolo della compensazione
''              - download dei dati RINEX 
''              - downlaod delle coordinate delle stazioni di vincolo
''              - lancio degli script BERNESE
''              - scrittura e graficizzazione dei risultati
''
''  WHAT'S NEW:
''******************************************************************************

Imports System.IO

Public Class frmPrincipale

    Private Const ATTACH_PARENT_PROCESS As Long = (-1&)
    Private Declare Function AttachConsole Lib "kernel32.dll" (ByVal dwProcessId As Long) As Long

    '''**********************************************************************
    ''' Nome:       subform
    ''' Lancia il form child all'interno di frmPrincipale.
    '''**********************************************************************
    Public Sub subform(ByVal form As Form)
        'Sub per il lancio di frm child

        txtLog.Visible = False

        If form IsNot Me.ActiveMdiChild Then

            If Me.ActiveMdiChild IsNot Nothing Then Me.ActiveMdiChild.Close()

            form.MdiParent = Me
            form.Dock = DockStyle.Fill
            form.FormBorderStyle = FormBorderStyle.None
            form.Show()
        End If
    End Sub

    '''**********************************************************************
    ''' Nome:       mnGenerale_Click
    ''' Lancia il form frmOpzGenerale.
    '''**********************************************************************
    Private Sub mnGenerale_Click(sender As Object, e As EventArgs) Handles mnOpzGenerale.Click

        subform(frmOpzGenerale)

    End Sub

    Public Sub mnAvanzate_Click(sender As Object, e As EventArgs) Handles cmdAvanzate.Click, mnAvanzate.Click

        subform(frmAvanzate)

    End Sub

    '''**********************************************************************
    ''' Nome:       mnStazioni_Click
    ''' Lancia il form frmOpzStazioni.
    '''**********************************************************************
    Private Sub mnStazioni_Click(sender As Object, e As EventArgs) Handles mnOpzStazioni.Click

        subform(frmOpzStazioni)

    End Sub

    '''**********************************************************************
    ''' Nome:       mnServer_Click
    ''' Lancia il form frmOpzServer.
    '''**********************************************************************
    Private Sub mnServer_Click(sender As Object, e As EventArgs) Handles mnOpzServer.Click

        subform(frmOpzServer)

    End Sub

    '''**********************************************************************
    ''' Nome:       mnCalcola_Click
    ''' Lancia tutto il processo di calcolo scriptato all'interno della sub
    ''' Calcola.
    '''**********************************************************************
    Private Sub mnCalcola_Click(sender As Object, e As EventArgs) Handles mnCalcola.Click

        txtLog.Text = ""
        txtLog.Visible = True
        Cursor = Cursors.WaitCursor

        Calcola()

        Cursor = Cursors.Default

    End Sub

    '''**********************************************************************
    ''' Nome:       mnRisCrd_Click
    ''' Lancia il form frmRisCrd.
    '''**********************************************************************
    Private Sub mnRisCrd_Click(sender As Object, e As EventArgs) Handles mnRisCrd.Click

        subform(frmRisCrd)

    End Sub

    '''**********************************************************************
    ''' Nome:       mnRisGrafici_Click
    ''' Lancia il form frmRisGrafici.
    '''**********************************************************************
    Private Sub mnRisGrafici_Click(sender As Object, e As EventArgs) Handles mnRisGrafici.Click

        subform(frmRisGrafici)

    End Sub

    '''**********************************************************************
    ''' Nome:       Calcola
    ''' Effettua tutto il processo di calcolo, partendo dai parametri scritti 
    ''' nei file testuali .cfg, poi scarica i dati necessari al calcolo,
    ''' scrive i log di successo o insuccesso di tutti gli steps, nonchè 
    ''' eventuali warnings. Infine produce i risultati finali e lancia il 
    ''' programma esterno Grafici.py per la generazione dei risultati in
    ''' forma grafica.
    '''**********************************************************************
    Private Sub Calcola()

        'Percorsi dei file di configurazione:
        '- Generale.cfg:    contiene i principali parametri per il programma
        '- Stazioni.cfg:    contiene le stazioni di cui scaricare i file RINEX
        '- Server.cfg  :    contiene i dati per l'accesso FTP ai server utili
        '- Avanzate.cfg:    contiene i parametri avanzati per il programma
        Dim cfgGen, cfgSta, cfgSrv, cfgAva, pthGEN, pthScr As String
        Dim pthCfg, pthLog, pthCrd, pthGra As String

        pthCfg = "Config\"
        cfgSta = pthCfg & "Stazioni.cfg"
        cfgGen = pthCfg & "Generale.cfg"
        cfgSrv = pthCfg & "Server.cfg"
        cfgAva = pthCfg & "Avanzate.cfg"
        pthGEN = pthCfg & "GEN\"
        pthScr = pthCfg & "Script\"

        pthLog = "Report\"
        pthCrd = "Coordinate\"
        pthGra = "Grafici\"

        Dim rGen As String()
        Dim rAva As String()
        Dim rSta As String()

        Dim dataInizio, dataFine, data As Date
        Dim nCamp, srvfix, filefix, smtp, email, bin7z As String
        Dim notifica As Boolean
        Dim srepEN, srepQ As Double
        Dim mese, anno, doy, settimana, dow, d0 As String
        Dim lclus As String()
        Dim ngiorni, nsettimane As Integer
        Dim calendario() As Date

        Dim i As Integer



        '  **** PREPARAZIONE DELLE CARTELLE UTILI ****

        Varie.Prep_fold(pthCfg, pthGEN, pthScr, pthCrd, pthGra, pthLog)



        '  **** LETTURA DEL FILE Generale.cfg ****
        Try
            rGen = File.ReadAllLines(cfgGen)

            nCamp = rGen(0)
            If rGen(1) = "True" Then

                'Nel caso in cui è attivata la selezione automatica, viene popolata la variabile dataInizio con
                'il primo giorno della settimana utile più recente, ovvero la prima DOMENICA andando indietro di 8 settimane. 
                dataInizio = DateAdd("d", -7 * 8, DateTime.Now)
                While Format(dataInizio, "ddd") <> "dom"
                    dataInizio = DateAdd("d", -1, dataInizio)
                End While
                dataFine = DateAdd("d", 6, dataInizio)

            Else

                dataInizio = rGen(2)
                dataFine = rGen(3)
            End If
        Catch ex As Exception

            MsgBox("Errore nelle opzioni generali!", vbOKOnly, "Errore Opzioni Generali")

            subform(frmOpzGenerale)
        End Try


        '  **** LETTURA DEL FILE Avanzate.cfg ****
        Try
            rAva = File.ReadAllLines(cfgAva)
            srvfix = rAva(0).Split(",")(0)
            filefix = rAva(0).Split(",")(1)
            notifica = rAva(1)

            If notifica = True Then

                smtp = rAva(2).Split(",")(0)
                email = rAva(2).Split(",")(1)
            End If

            srepEN = CDbl(Val(rAva(3).Split("-")(0)))
            srepQ = CDbl(Val(rAva(3).Split("-")(1)))

            bin7z = rAva(4)

        Catch ex As Exception

            MsgBox("Errore nelle opzioni avanzate!", vbOKOnly, "Errore Opzioni Avanzate")

            subform(frmAvanzate)
            Exit Sub
        End Try


        '  **** DEFINIZIONE DEL PERIODO DI CALCOLO ****

        'Calcolo del numero di settimane intere tramite la funzione DateDiff che conta
        'il numero di Domeniche che ricorrono nel periodo tra le due date. (non conta
        'però la prima domenica della prima data.)
        nsettimane = DateDiff("ww", dataInizio, dataFine) + 1
        ngiorni = nsettimane * 7

        'Ridimensiono la variabile calendario() che contiene tutte le date
        'del periodo scelto.
        ReDim calendario(ngiorni - 1)
        For i = 0 To (ngiorni - 1)

            data = DateAdd("d", i, dataInizio)
            calendario(i) = data
        Next



        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\'
        Dim sessionOptions As New SessionOptions
        Dim remotePath, idSrv, idSta, CRS As String
        Dim arrClu As String = ""


        '  **** DOWNLOAD DAL SERVER BERNESE ****
        'Per ogni data scarico tutti i prodotti necessari

        'Opzioni per il collegamento ftp del server Bernese 
        sessionOptions.HostName = "Ftp.aiub.unibe.ch"
        sessionOptions.UserName = "anonymous"
        sessionOptions.Password = ""

        'Download File_Astronomici
        Download.FileAstronomici(pthGEN, sessionOptions)

        'Download Moto_Polo
        d0 = ""
        For Each data In calendario

            anno = Format(data.Year, "0000")
            If anno <> d0 Then
                Download.MotoPolo(anno, sessionOptions)
                d0 = anno
            End If
        Next


        'Download Effemeridi_Precise
        For Each data In calendario

            dow = Format(data.DayOfWeek)
            doy = Format(data.DayOfYear, "000")
            settimana = DateDiff("ww", "06-Jan-1980 00:00:00", data)
            anno = Format(data.Year, "0000")
            Download.Effemeridi(dow, doy, settimana, anno, sessionOptions)
        Next


        'Download Errore_Orologio
        For Each data In calendario

            dow = Format(data.DayOfWeek)
            doy = Format(data.DayOfYear, "000")
            settimana = DateDiff("ww", "06-Jan-1980 00:00:00", data)
            anno = Format(data.Year, "0000")
            Download.EOrologio(dow, doy, settimana, anno, sessionOptions)
        Next

        'Download Moto_Terrestre
        d0 = ""
        For Each data In calendario

            settimana = DateDiff("ww", "06-Jan-1980 00:00:00", data)
            If settimana <> d0 Then
                doy = Format(data.DayOfYear, "000")
                anno = Format(data.Year, "0000")
                Download.MTerrestre(doy, settimana, anno, sessionOptions)
                d0 = settimana
            End If
        Next

        'Download Ionosfera
        For Each data In calendario

            dow = Format(data.DayOfWeek)
            doy = Format(data.DayOfYear, "000")
            settimana = DateDiff("ww", "06-Jan-1980 00:00:00", data)
            anno = Format(data.Year, "0000")
            Download.Ionosfera(dow, doy, settimana, anno, sessionOptions)
        Next

        'Download DCB
        d0 = ""
        For Each data In calendario

            mese = Format(data.Month, "00")
            If mese <> d0 Then
                anno = Format(data.Year, "0000")
                Download.DCB(mese, anno, sessionOptions)
                d0 = mese
            End If
        Next


        '  **** DOWNLOAD DELLE COORDINATE DELLE STAZ. VINCOLO ****
        'Opzioni per il collegamento ftp del server 
        sessionOptions.HostName = srvfix
        sessionOptions.UserName = "anonymous"
        sessionOptions.Password = ""

        d0 = ""
        For Each data In calendario
            settimana = DateDiff("ww", "06-Jan-1980 00:00:00", data)
            If settimana <> d0 Then
                doy = Format(data.DayOfYear, "000")
                anno = Format(data.Year, "0000")

                Try
                    filefix = Replace(filefix, "YYYY", anno)
                    filefix = Replace(filefix, "YY", Format(data.Year, "00"))
                    filefix = Replace(filefix, "WWWW", settimana)
                    filefix = Replace(filefix, "DDD", doy)

                Catch ex As Exception
                End Try

                ' Definisco SR a seconda dell'epoca dei dati scaricati.
                If settimana < 2238 Then CRS = "IGS14"
                If settimana >= 2238 Then CRS = "IGS20"

                Download.CoordinateREF(filefix, settimana, data, nCamp, sessionOptions, CRS, bin7z)
                d0 = settimana
            End If
        Next

        '  **** LETTURA DEL FILE Stazioni.cfg ****
        '                     &
        '  **** DOWNLOAD DEI FILE RINEX ****
        Try
            rSta = File.ReadAllLines(cfgSta)
            i = 0

            For Each sta In rSta

                idSrv = Split(sta, ",")(0)
                idSta = Split(sta, ",")(1)
                remotePath = Split(sta, ",")(2)

                ' Inserisco in un array le stazioni permanenti di cui generare report e grafici
                If Split(sta, ",")(3) = "True" Then

                    ReDim Preserve lclus(i)
                    lclus(i) = idSta
                    i += 1
                End If

                sessionOptions = WinSCP.WinSCP_opt(idSrv)

                For Each data In calendario
                    anno = Format(data.Year, "0000")
                    doy = Format(data.DayOfYear, "000")

                    Download.Rinex(remotePath, anno, doy, sessionOptions)
                Next

            Next

        Catch ex As Exception

            txtLog.SelectionColor = Color.Red
            txtLog.SelectedText = DateTime.Now & " !!! ERRORE nella lettura del file Stazioni.cfg " & vbCrLf
        End Try


        '  **** PREPARAZIONE DEI FILE OUTPUT ****

        Varie.Prep_file(lclus, nCamp, pthCrd, pthGra)



        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\'
        Dim pthScript As String = Environ("U") & "\SCRIPT\"
        Dim pthPCF As String = Environ("U") & "\PCF\"
        Dim pthCamp As String = Environ("P") & "\" & nCamp
        Dim temp As Object
        Dim wcrd As StreamWriter
        Dim rcrd As StreamReader
        Dim crdLine, staz, domenica, mercoledi, anno0, anno3 As String
        Dim crdXYZ_Ixx As String()
        Dim crdXYZ_I20, crdgeo_I20, crdutm_I20, crdXYZ_E00, crdgeo_E00, crdutm_E00 As Double()
        Dim iday As Integer = 0


        '  **** COPIA E MODIFICA DEGLI SCRIPT UTILI ****

        For Each f In My.Computer.FileSystem.GetFiles(pthScr, 2, "*.pl")
            File.Copy(f, pthScript & Path.GetFileName(f), True)
        Next

        For Each f In My.Computer.FileSystem.GetFiles(pthScr, 2, "*.PCF")
            File.Copy(f, pthPCF & Path.GetFileName(f), True)

            temp = File.ReadAllText(pthPCF & Path.GetFileName(f))
            temp = Replace(temp, "[NCAMP]", nCamp)
            File.Create(pthPCF & Path.GetFileName(f)).Close()
            File.WriteAllText(pthPCF & Path.GetFileName(f), temp)

        Next


        '  **** COMPENSAZIONE TRAMITE SCRIPT BERNESE ****

        For Each data In calendario

            anno = Format(data.Year, "0000")
            doy = Format(data.DayOfYear, "000")
            settimana = DateDiff("ww", "06-Jan-1980 00:00:00", data)

            If settimana < 2238 Then CRS = "IGS14"
            If settimana >= 2238 Then CRS = "IGS20"


            '  **** Compensazione GIORNALIERA **** 

            If Not File.Exists(pthCamp & "\STA\FIX" & Strings.Right(anno, 2) & doy & "0.CRD") Then
                Bernese.CompensazioneD(pthScript, nCamp, anno, doy, CRS)
            End If

            Varie.Log_Verifica("COMPENSAZIONE D:" & Strings.Right(anno, 2) & doy, pthCamp & "\STA\FIX" & Strings.Right(anno, 2) & doy & "0.CRD", "Compensazione")

            iday += 1
            If iday = 1 Then domenica = doy         'Primo giorno della settimana GPS e rispettivo anno
            If iday = 1 Then anno0 = anno
            If iday = 4 Then mercoledi = doy        'Giorno intermedio della della settimana GPS e rispettivo anno
            If iday = 4 Then anno3 = anno


            If iday = 7 Then


                '  **** Compensazione SETTIMANALE **** 

                If Not File.Exists(pthCamp & "\STA\WEKCMP_" & settimana & ".CRD") Then
                    Bernese.CompensazioneW(pthScript, nCamp, anno0, domenica, settimana, CRS)
                End If

                Varie.Log_Verifica("COMPENSAZIONE W:" & settimana, pthCamp & "\STA\WEKCMP_" & settimana & ".CRD", "Compensazione")

                iday = 0            'Azzero il contatore


                'Salvo le coordinate finali
                If File.Exists(pthCamp & "\STA\WEKCMP_" & settimana & ".CRD") Then
                    rcrd = My.Computer.FileSystem.OpenTextFileReader(pthCamp & "\STA\WEKCMP_" & settimana & ".CRD")

                    'Lettura intestazione
                    For i = 0 To 5
                        rcrd.ReadLine()
                    Next

                    Do While rcrd.Peek() > 0
                        crdLine = rcrd.ReadLine
                        staz = Mid(crdLine, 6, 4)

                        'Salvo ogni posizione calcolata nel file di testo rispettivo della stazione
                        If lclus.Contains(staz) Then

                            crdXYZ_Ixx = Split(Mid(crdLine, 24, 43), "  ")

                            'Nel caso in cui le coordinate siano nel sistema I14, le converto in I20
                            If CRS = "IGS14" Then
                                crdXYZ_I20 = Geog.I14toI20(CDbl(Val(crdXYZ_Ixx(0))), CDbl(Val(crdXYZ_Ixx(1))),
                                          CDbl(Val(crdXYZ_Ixx(2))), mercoledi, anno3)
                            Else
                                crdXYZ_I20 = {CDbl(Val(crdXYZ_Ixx(0))), CDbl(Val(crdXYZ_Ixx(1))),
                                    CDbl(Val(crdXYZ_Ixx(2)))}
                            End If

                            'Converto le coordinate geocentriche da ITRF20 a ETRF riferite al giorno intermedio della settimana
                            crdXYZ_E00 = Geog.IGStoETRF(CDbl(Val(crdXYZ_I20(0))), CDbl(Val(crdXYZ_I20(1))),
                                          CDbl(Val(crdXYZ_I20(2))), mercoledi, anno3)

                            'Converto le coordinate geocentriche in geografiche
                            crdgeo_I20 = Geog.XYZtoGeo(crdXYZ_I20(0), crdXYZ_I20(1), crdXYZ_I20(2))
                            crdgeo_E00 = Geog.XYZtoGeo(crdXYZ_E00(0), crdXYZ_E00(1), crdXYZ_E00(2))

                            'Converto le coordinate geografiche in cartografiche
                            crdutm_I20 = Geog.GeoToEN(crdgeo_I20(0), crdgeo_I20(1), crdgeo_I20(2))
                            crdutm_E00 = Geog.GeoToEN(crdgeo_E00(0), crdgeo_E00(1), crdgeo_E00(2))

                            'Scrivo le coordinate convertite
                            wcrd = File.AppendText(pthCrd & staz & ".crd")
                            wcrd.WriteLine(String.Format("{0,4}{1,17}{2,18}{3,15}{4,21}{5,18}{6,15}",
                                settimana, Format(crdutm_I20(0), "0.00000"), Format(crdutm_I20(1), "0.00000"), Format(crdutm_I20(2), "0.00000"),
                                Format(crdutm_E00(0), "0.00000"), Format(crdutm_E00(1), "0.00000"), Format(crdutm_E00(2), "0.00000")))
                            wcrd.Close()

                        End If
                    Loop

                    rcrd.Close()
                End If
            End If

        Next

        txtLog.SelectionColor = Color.Black
        txtLog.SelectedText = DateTime.Now & " [ RISULTATI ] Generazione risultati in corso..." & vbCrLf


        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\'
        Dim stazArray(0) As String
        Dim week, reportfile As String


        '  **** SISTEMAZIONE COORDINATE NEI FILES .CRD ****
        '                           &
        '            **** RIEMPIMENTO FILE .REP ****

        For Each staz In lclus

            rcrd = My.Computer.FileSystem.OpenTextFileReader(pthCrd & staz & ".crd")

            'Intestazione .crd
            rcrd.ReadLine()
            rcrd.ReadLine()
            rcrd.ReadLine()

            i = 0
            Do While rcrd.Peek() > 0
                crdLine = rcrd.ReadLine

                'Non considero eventuali doppioni
                If Not stazArray.Contains(crdLine) Then

                    ReDim Preserve stazArray(i)
                    stazArray(i) = crdLine
                    i += 1
                End If
            Loop
            rcrd.Close()

            'Ordino in modo cronologico
            Array.Sort(stazArray)

            ' Sovrascrivo il file .crd
            File.Create(pthCrd & staz & ".crd").Close()

            wcrd = File.AppendText(pthCrd & staz & ".crd")
            wcrd.WriteLine("                            ITRF2020                                              ETRF2000" & vbCrLf &
                        "           Est (M)          Nord (M)          Hell (M)           Est (M)          Nord (M)          Hell (M)" & vbCrLf &
                        "WEEK")

            For Each crdLine In stazArray
                wcrd.WriteLine(crdLine)

                ' Scrivo la ripetibilità nel file .rep
                week = Strings.Left(crdLine, 4)
                Rep_file(staz, week, pthCrd, srepEN, srepQ)

            Next
            wcrd.Close()

        Next

        '  **** GENERAZIONE GRAFICI ****

        Dim p As New Process
        Dim graf As New ProcessStartInfo("cmd.exe", "/c py Grafici.py")
        p.StartInfo = graf
        p.Start()
        p.WaitForExit()

        txtLog.SelectionColor = Color.Green
        txtLog.SelectedText = DateTime.Now & " [ FINE ] " & vbCrLf


        '  **** SALVATAGGIO REPORT & INVIO NOTIFICA EMAIL ****

        reportfile = Varie.Report(txtLog.Text, pthLog)

        If notifica = True Then Varie.Invio_email(smtp, email, reportfile)

    End Sub

    '''**********************************************************************
    ''' Nome:       txtLog_TextChanged
    ''' Visualizza sempre il botton del form frmPrincipale che contiene i log.
    '''**********************************************************************
    Private Sub txtLog_TextChanged(sender As Object, e As EventArgs) Handles txtLog.TextChanged

        txtLog.ScrollToCaret()

    End Sub

    '''**********************************************************************
    ''' Nome:       frmPrincipale_Load
    ''' Se il lancio del programma avviene da linea di comando, viene avviata
    ''' autamaticamente la sub mnCalcola_Click, e infine viene chiusa
    ''' l'interfaccia.
    ''' **********************************************************************
    Private Sub frmPrincipale_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If AttachConsole(ATTACH_PARENT_PROCESS) Then

            Me.Show()
            mnCalcola_Click(sender, e)
            Me.Close()
        Else

            Me.Show()
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       cmdAiuto_Click
    ''' Visualizza il manuale utente (in pdf).
    ''' **********************************************************************
    Private Sub cmdAiuto_Click(sender As Object, e As EventArgs) Handles cmdAiuto.Click

        Dim p As New Process
        Dim man As New ProcessStartInfo("ManualeUtente.pdf") With {
            .UseShellExecute = True
        }

        If File.Exists("ManualeUtente.pdf") Then
            p.StartInfo = man
            p.Start()
        End If

    End Sub

End Class