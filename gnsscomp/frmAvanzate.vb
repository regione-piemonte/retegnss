'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

'Crea un file di configurazione Avanzate.cfg che contiene:
' - Server per scaricare le coordinate delle stazioni GNSS di vincolo
' - Directory remota per il file di coordinate
' - Soglie di ripetibilità settimanale
' - Server SMTP e indirizzo email per invio email di conferma
' - Eventuale locazione del software 7z.exe

Public Class frmAvanzate

    '''**********************************************************************
    ''' Nome:       chkEmail_CheckedChanged
    ''' Abilita o disabilita i textbox relativi all'invio per email della
    ''' notifica di conclusione del processo.
    ''' **********************************************************************
    Private Sub chkEmail_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmail.CheckedChanged

        If chkEmail.Checked = True Then

            txtSMTP.Enabled = True
            txtEmail.Enabled = True
        Else

            txtSMTP.Enabled = False
            txtEmail.Enabled = False
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       frmAvanzate_Load
    ''' Se sono già scritti nel file testuale di configurazione Avanzate.cfg,
    ''' popola i textbox con i parametri già salvati.
    ''' **********************************************************************
    Private Sub frmAvanzate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Tooltip per i caratteri speciali
        ToolTip1.SetToolTip(Label10, "YYYY Anno esteso es. 2024" & vbCrLf & "DDD Giorno Giuliano es. 120" & vbCrLf & "WWWW Settimana GPS es. 2312")

        ' Variabile di ambiente per il percorso della cartella GEN (del Bernese)
        Try
            lblAstr.Text = Replace(lblAstr.Text, "{X}", Environ("X"))
        Catch ex As Exception

            MsgBox("Errore! Variabile di ambiente {X} non trovata!", vbOKOnly, "Errore Opzioni Avanzate")

        End Try
        lblAstr.Text = Replace(lblAstr.Text, "{current}", Directory.GetCurrentDirectory())


        If File.Exists("config\Avanzate.cfg") Then

            ' Lettura file Avanzate.cfg
            Try

                Dim rAvanzate As String() = File.ReadAllLines("config\Avanzate.cfg")

                txtIPFix.Text = rAvanzate(0).Split(",")(0)
                txtPathFix.Text = rAvanzate(0).Split(",")(1)

                chkEmail.Checked = rAvanzate(1)
                If chkEmail.Checked = True Then

                    txtSMTP.Text = rAvanzate(2).Split(",")(0)
                    txtEmail.Text = rAvanzate(2).Split(",")(1)
                Else

                    txtSMTP.Enabled = False
                    txtEmail.Enabled = False
                End If

                txtsogEN.Text = rAvanzate(3).Split("-")(0)
                txtsogQ.Text = rAvanzate(3).Split("-")(1)

            Catch ex As Exception

                File.Create("config\Avanzate.cfg").Close()

            End Try

        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       btnFineAvanz_Click
    ''' Controlla la validità e la presenza dei parametri inseriti, 
    ''' li salva nel file Avanzate.cfg e chiude il form child.
    ''' **********************************************************************
    Private Sub btnFineAvanz_Click(sender As Object, e As EventArgs) Handles btnFineAvanz.Click
        Dim numEmp As Integer = 0
        Dim bin7z As String = "-"

        ' Controllo la presenza di campi vuoti
        For Each ctrl In Me.Controls.OfType(Of TextBox)

            If ctrl.Text = "" And ctrl.Enabled = True Then numEmp += 1
        Next


        If numEmp = 0 Then

            ' Se il file delle crd vincolo è un archivio di tipo .Z viene richiesta la 
            ' directory di 7Z.exe
            If Strings.Right(txtPathFix.Text, 2) = ".Z" Then

                Dim response = MsgBox("Per utilizzare il file " & txtPathFix.Text & " è necessario il software 7z.exe." & vbCrLf &
                    "Indicare di seguito la cartella contenente tale programma.", vbOKOnly, "Opzioni Avanzate")

                If response = vbOK Then
                    FolderBrowserDialog1.ShowDialog()
                    bin7z = FolderBrowserDialog1.SelectedPath
                End If
            End If


            ' Scrittura del file Avanzate.cfg
            File.WriteAllText("config\Avanzate.cfg",
                              txtIPFix.Text & "," & txtPathFix.Text & vbCrLf &
                              chkEmail.Checked & vbCrLf &
                              txtSMTP.Text & "," & txtEmail.Text & vbCrLf &
                              txtsogEN.Text & "-" & txtsogQ.Text & vbCrLf &
                              bin7z)

            Me.Close()

            Else

                MsgBox("Inserire dati mancanti!", vbOKOnly, "Errore Opzioni Avanzate")
        End If

    End Sub

End Class