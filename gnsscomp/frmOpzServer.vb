'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

'Crea un file di configurazione Server.cfg che contiene la lista dei server FTP usati
'per scaricare i file RINEX con:
' - Server FTP
' - Indirizzo IP
' - Nome utente
' - Password
Public Class frmOpzServer

    Dim numEmp, contaSrv As Integer
    Dim wServer As StreamWriter
    Dim numSrv = 0
    Dim nomeSrv As String = ""

    '''**********************************************************************
    ''' Nome:       frmOpzServer_Load
    ''' Se sono già scritti nel file testuale di configurazione Server.cfg,
    ''' popola i textbox con i parametri già salvati, partendo dai srv 
    ''' indicati nel file testuale di configurazione Stazioni.cfg.
    ''' **********************************************************************
    Private Sub frmOpzServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Lettura file Stazioni.cfg
        Try

            Dim rStazioni As String() = File.ReadAllLines("config\Stazioni.cfg")

            For Each staz In rStazioni

                    If Not Split(staz, ",")(0) = nomeSrv Then
                        nomeSrv = Split(staz, ",")(0)

                    Dim lblServer As New Label With {
                                    .Name = "lblServer" & (numSrv + 1),
                                    .Location = New Point(26, 200 + (27 + 19) * numSrv),
                                    .Text = (numSrv + 1) & ".",
                                    .AutoSize = True,
                                    .Visible = True
                                     }
                    Dim txtSrvFTP As New TextBox With {
                                    .Name = "txtSrvFTP" & (numSrv + 1),
                                    .Location = New Point(58, 200 + (27 + 19) * numSrv),
                                    .Text = nomeSrv,
                                    .Width = 100,
                                    .Visible = True,
                                    .Enabled = False
                                    }
                    Dim txtIP As New TextBox With {
                                    .Name = "txtIP" & (numSrv + 1),
                                    .Location = New Point(187, 200 + (27 + 19) * numSrv),
                                    .Width = 150,
                                    .Visible = True
                                    }
                    Dim txtUtente As New TextBox With {
                                    .Name = "txtUtente" & (numSrv + 1),
                                    .Location = New Point(366, 200 + (27 + 19) * numSrv),
                                    .Width = 150,
                                    .Visible = True
                                    }
                    Dim txtPassword As New TextBox With {
                                    .Name = "txtPassword" & (numSrv + 1),
                                    .Location = New Point(544, 200 + (27 + 19) * numSrv),
                                    .Width = 150,
                                    .Visible = True
                                    }

                    Controls.Add(lblServer)
                    Controls.Add(txtSrvFTP)
                    Controls.Add(txtIP)
                    Controls.Add(txtUtente)
                    Controls.Add(txtPassword)

                    numSrv += 1
                End If
                Next
            Catch

                MsgBox("Non hai ancora finito di inserire le stazioni permanenti. Prima di inserire i server sorgente assicurati
                    di aggiungere tutte le stazioni GNSS di cui calcolare le coordinate.", vbOKOnly, "Errore Opzioni Server FTP")
                frmPrincipale.Show()

            End Try

        If File.Exists("config\Server.cfg") Then

            ' Lettura file Server.cfg
            Try

                Dim rServer As String() = File.ReadAllLines("config\Server.cfg")
                Dim i As Integer

                For Each srv In rServer
                    nomeSrv = srv.Split(",")(0)

                    For i = 1 To numSrv

                        If nomeSrv = Controls.Find("txtSrvFTP" & i, False)(0).Text Then

                            Controls.Find("txtIP" & i, False)(0).Text = srv.Split(",")(1)
                            Controls.Find("txtUtente" & i, False)(0).Text = srv.Split(",")(2)
                            Controls.Find("txtPassword" & i, False)(0).Text = srv.Split(",")(3)

                            Exit For
                        End If

                    Next
                Next

            Catch ex As Exception

                MsgBox("Errore nella lettura del file Server.cfg", vbOKOnly, "Errore Opzioni Server FTP")
                frmPrincipale.Show()

            End Try

        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       btnAvantiServer_Click
    ''' Controlla la validità e la presenza dei parametri inseriti, 
    ''' li salva nel file Server.cfg e chiude il form child.
    ''' **********************************************************************
    Private Sub btnAvantiServer_Click(sender As Object, e As EventArgs) Handles btnFineServer.Click

        numEmp = 0
        ' Controllo la presenza di campi vuoti
        For Each ctrl In Me.Controls.OfType(Of TextBox)

            If ctrl.Text = "" Then numEmp += 1
        Next

        If numEmp = 0 Then

            contaSrv = 0
            For Each ctrl In Me.Controls.OfType(Of Label)

                If ctrl.Name.StartsWith("lblServer") Then contaSrv += 1
            Next

            ' Scrittura file Server.cfg
            File.WriteAllText("config\Server.cfg", "")
            wServer = File.AppendText("config\Server.cfg")

            For i = 1 To contaSrv
                wServer.WriteLine(Me.Controls.Find("txtSrvFTP" & i, False)(0).Text & "," &
                Me.Controls.Find("txtIP" & i, False)(0).Text & "," &
                Me.Controls.Find("txtUtente" & i, False)(0).Text & "," &
                Me.Controls.Find("txtPassword" & i, False)(0).Text)
            Next

            wServer.Close()
            Me.Close()

        Else

            MsgBox("Errore! Ci sono " & numEmp & " caselle vuote." & vbCrLf &
                   "Riempire tutte le caselle.", vbOKOnly, "Errore Opzioni Server FTP")
        End If
    End Sub
End Class