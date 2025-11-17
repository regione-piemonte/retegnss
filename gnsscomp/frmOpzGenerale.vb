'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

'Crea un file di configurazione Generale.cfg che contiene:
' - Nome della campagna Bernese
' - Intervallo temporale di calcolo
Public Class frmOpzGenerale
    Dim msgErrori, msgTempo, response, genLine As String
    Dim dataIn, dataFin As Date
    Dim rGenerale As StreamReader
    Dim settIn, settFin, numErr As Integer

    '''**********************************************************************
    ''' Nome:       frmOpzGenerale_Load
    ''' Se sono già scritti nel file testuale di configurazione Generale.cfg,
    ''' popola i textbox con i parametri già salvati.
    ''' **********************************************************************
    Private Sub frmOpzGenerale_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists("config\Generale.cfg") Then

            'Lettura Generale.cfg
            Try
                rGenerale = My.Computer.FileSystem.OpenTextFileReader("config\Generale.cfg")

                genLine = rGenerale.ReadLine
                txtNomeCamp.Text = genLine
                genLine = rGenerale.ReadLine
                genLine = rGenerale.ReadLine
                txtDataInizio.Text = genLine
                genLine = rGenerale.ReadLine
                txtDataFine.Text = genLine

                rGenerale.Close()
            Catch ex As Exception

                File.Create("config\Generale.cfg").Close()
            End Try

        End If
    End Sub

    '''**********************************************************************
    ''' Nome:       chkAuto_CheckedChanged
    ''' Abilita (e individua) o disabilita i textbox relativi all'
    ''' individuazione automatica dell'intervallo di calcolo.
    ''' **********************************************************************
    Private Sub chkAuto_CheckedChanged(sender As Object, e As EventArgs) Handles chkAuto.CheckedChanged

        If chkAuto.Checked = True Then

            'Nel caso in cui è attivata la selezione automatica, viene popolata la variabile dataInizio con
            'il primo giorno della settimana utile più recente, ovvero la prima DOMENICA andando indietro di 8 settimane. 
            dataIn = DateAdd("d", -7 * 8, DateTime.Now)
            While Format(dataIn, "ddd") <> "dom"
                dataIn = DateAdd("d", -1, dataIn)
            End While
            dataFin = DateAdd("d", 6, dataIn)

            txtDataInizio.Enabled = False
            txtDataInizio.Text = dataIn.ToString("dd/MM/yyyy")
            txtDataFine.Enabled = False
            txtDataFine.Text = dataFin.ToString("dd/MM/yyyy")
        Else
            txtDataInizio.Clear()
            txtDataFine.Clear()
            txtDataInizio.Enabled = True
            txtDataFine.Enabled = True
        End If
    End Sub

    '''**********************************************************************
    ''' Nome:       btnAvantiGenerale_Click
    ''' Controlla la validità e la presenza dei parametri inseriti, 
    ''' li salva nel file Generale.cfg e apre il form child frmOpzStazioni.
    ''' **********************************************************************
    Private Sub btnAvantiGenerale_Click(sender As Object, e As EventArgs) Handles btnAvantiGenerale.Click
        msgErrori = ""
        numErr = 0

        'Definizione e controllo della variabile Nome Campagna
        If txtNomeCamp.Text = "" Then
            numErr += 1
            msgErrori = msgErrori & numErr & ") Nome campagna non inserito." & vbCrLf

        ElseIf Not Directory.Exists(Environ("P") & "\" & txtNomeCamp.Text) Then
            numErr += 1
            msgErrori = msgErrori & numErr & ") Campagna BERNESE inesistente! Creare la campagna prima di avviare la procedura." & vbCrLf
        End If


        'Definizione e controllo dell' intervallo temporale
        Try
            dataIn = txtDataInizio.Text
            dataFin = txtDataFine.Text

            'Nel caso in cui è disattivata la selezione automatica, vengono lette le due date riportate,
            'e viene ricavato un intervallo che preveda un numero di settimane piene (da DOMENICA a SABATO).
            While Format(dataIn, "ddd") <> "dom"
                dataIn = DateAdd("d", -1, dataIn)
            End While
            While Format(dataFin, "ddd") <> "sab"
                dataFin = DateAdd("d", 1, dataFin)
            End While

            If CDate(dataIn) > CDate(dataFin) Then
                numErr += 1
                msgErrori = msgErrori & numErr & ") Intervallo temporale non valido!" & vbCrLf
            End If
        Catch ex As Exception

            numErr += 1
            msgErrori = msgErrori & numErr & ") Formato data non valido!" & vbCrLf
        End Try


        'Mostra eventuali messaggi di errore o riassunto parametri dichiarati
        If msgErrori = "" Then
            settIn = CInt(DateDiff("ww", "06-Jan-1980 00:00:00", dataIn))
            settFin = CInt(DateDiff("ww", "06-Jan-1980 00:00:00", dataFin))
            msgTempo = "L' intervallo temporale effettivo è il seguente:" & vbCrLf &
                "dal " & dataIn.ToString("dd-MM-yy") & " (settimana GPS: " & settIn & ")" & vbCrLf &
                "al " & dataFin.ToString("dd-MM-yy") & " (settimana GPS: " & settFin & ")" & vbCrLf &
                "Numero di epoche: " & (settFin - settIn + 1) & vbCrLf & vbCrLf &
                "Vuoi proseguire?"

            response = MsgBox(msgTempo, vbYesNo, "Intervallo temporale")
            If response = vbYes Then

                ' Scrittura del file Generale.cfg
                File.WriteAllText("config\Generale.cfg", txtNomeCamp.Text & vbCrLf &
                                    chkAuto.Checked & vbCrLf &
                                    dataIn & vbCrLf &
                                    dataFin)

                Me.Close()
                frmPrincipale.subform(frmOpzStazioni)
            End If

        Else
            MsgBox(msgErrori, vbOKOnly, "Errore Opzioni Generali")
        End If
    End Sub

End Class