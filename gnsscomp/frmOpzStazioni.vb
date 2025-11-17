'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

'Crea un file di configurazione Stazioni.cfg che contiene la lista delle stazoni GNSS
'da conside nel calcolo con:
' - Server FTP
' - Nome Stazione GNSS
' - Diretory remota del file RINEX
' - Check sulla produzione dei grafici
Public Class frmOpzStazioni

    Dim contaStaz As Integer
    Dim numEmp As Integer
    Dim wStazioni As StreamWriter

    '''**********************************************************************
    ''' Nome:       frmOpzStazioni_Load
    ''' Se sono già scritti nel file testuale di configurazione Stazioni.cfg,
    ''' popola i textbox con i parametri già salvati.
    ''' **********************************************************************
    Private Sub frmOpzStazioni_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Tooltip per i caratteri speciali
        ToolTip1.SetToolTip(Label7, "YYYY Anno esteso es. 2024" & vbCrLf & "DDD Giorno Giuliano es. 120")

        If File.Exists("config\Stazioni.cfg") Then

            'Lettura del file Stazioni.cfg
            Try
                Dim rStazioni As String() = File.ReadAllLines("config\Stazioni.cfg")

                txtSrvFTP1.Text = rStazioni(0).Split(",")(0)
                txtStaz1.Text = rStazioni(0).Split(",")(1)
                txtRemPath1.Text = rStazioni(0).Split(",")(2)
                chkGra1.Checked = rStazioni(0).Split(",")(3)

                For i = 1 To (rStazioni.Length - 1)

                    Dim lblContaStaz As New Label With {
                        .Name = "lblContaStaz" & (i + 1),
                        .Location = New Point(26, 219 + (27 + 19) * i),
                        .Text = (i + 1) & ".",
                        .AutoSize = True,
                        .Visible = True
                            }
                    Dim txtSrvFTP As New TextBox With {
                            .Name = "txtSrvFTP" & (i + 1),
                            .Location = New Point(58, 214 + (27 + 19) * i),
                            .Text = rStazioni(i).Split(",")(0),
                            .Width = 100,
                            .Visible = True
                            }
                    Dim txtStaz As New TextBox With {
                            .Name = "txtStaz" & (i + 1),
                            .Location = New Point(178, 214 + (27 + 19) * i),
                            .Text = rStazioni(i).Split(",")(1),
                            .Width = 138,
                            .Visible = True
                            }
                    Dim txtRemPath As New TextBox With {
                            .Name = "txtRemPath" & (i + 1),
                            .Location = New Point(332, 214 + (27 + 19) * i),
                            .Text = rStazioni(i).Split(",")(2),
                            .Width = 360,
                            .Visible = True
                            }
                    Dim chkGra As New CheckBox With {
                            .Name = "chkGra" & (i + 1),
                            .Location = New Point(749, 214 + (27 + 19) * i),
                            .Checked = rStazioni(i).Split(",")(3),
                            .Visible = True
                            }

                    Controls.Add(lblContaStaz)
                    Controls.Add(txtSrvFTP)
                    Controls.Add(txtStaz)
                    Controls.Add(txtRemPath)
                    Controls.Add(chkGra)

                Next
            Catch ex As Exception

                File.Create("config\Stazioni.cfg").Close()
            End Try

        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       btnStazPiu_Click
    ''' Aggiunge un rigo di textbox inerente ad una nuova CORS da inserire
    ''' nel calcolo di compensazione.
    ''' **********************************************************************
    Private Sub btnStazPiu_Click(sender As Object, e As EventArgs) Handles btnStazPiu.Click
        ' Aggiungi righe per inserimento stazione GNSS

        contaStaz = 0
        ' Conto il numero di righe già esistenti nel panel
        For Each ctrl In Controls.OfType(Of Label)

            If ctrl.Name.StartsWith("lblContaStaz") Then contaStaz += 1
        Next

        Dim lblContaStaz As New Label With {
            .Name = "lblContaStaz" & (contaStaz + 1),
            .Location = New Point(26, 214 + (27 + 19) * contaStaz),
            .Text = (contaStaz + 1) & ".",
            .AutoSize = True,
            .Visible = True
            }
        Dim txtSrvFTP As New TextBox With {
            .Name = "txtSrvFTP" & (contaStaz + 1),
            .Location = New Point(58, 214 + (27 + 19) * contaStaz),
            .Width = 100,
            .Visible = True
            }
        Dim txtStaz As New TextBox With {
            .Name = "txtStaz" & (contaStaz + 1),
            .Location = New Point(178, 214 + (27 + 19) * contaStaz),
            .Width = 138,
            .Visible = True
            }
        Dim txtRemPath As New TextBox With {
            .Name = "txtRemPath" & (contaStaz + 1),
            .Location = New Point(332, 214 + (27 + 19) * contaStaz),
            .Width = 360,
            .Visible = True
            }
        Dim chkGra As New CheckBox With {
            .Name = "chkGra" & (contaStaz + 1),
            .Location = New Point(749, 214 + (27 + 19) * contaStaz),
            .Visible = True
            }

        Controls.Add(lblContaStaz)
        Controls.Add(txtSrvFTP)
        Controls.Add(txtStaz)
        Controls.Add(txtRemPath)
        Controls.Add(chkGra)

    End Sub

    '''**********************************************************************
    ''' Nome:       btnStazPiu_Click
    ''' Elimina un rigo di textbox inerente l'ultima CORS inserita nel  
    ''' calcolo di compensazione.
    ''' **********************************************************************
    Private Sub btnStazMeno_Click(sender As Object, e As EventArgs) Handles btnStazMeno.Click
        ' Togli righe per inserimento stazione GNSS

        contaStaz = 0
        ' Conto il numero di righe già esistenti (1 è di default)
        For Each ctrl In Controls.OfType(Of Label)

            If ctrl.Name.StartsWith("lblContaStaz") Then contaStaz += 1
        Next

        If contaStaz > 1 Then
            Controls.Remove(Controls.Find("lblContaStaz" & contaStaz, False)(0))
            Controls.Remove(Controls.Find("txtSrvFTP" & contaStaz, False)(0))
            Controls.Remove(Controls.Find("txtStaz" & contaStaz, False)(0))
            Controls.Remove(Controls.Find("txtRemPath" & contaStaz, False)(0))
            Controls.Remove(Controls.Find("chkGra" & contaStaz, False)(0))

            contaStaz -= 1
        End If
    End Sub

    '''**********************************************************************
    ''' Nome:       btnAvantiStazioni_Click
    ''' Controlla la validità e la presenza dei parametri inseriti, 
    ''' li salva nel file Stazioni.cfg e apre il form child frmOpzServer.
    ''' **********************************************************************
    Private Sub btnAvantiStazioni_Click(sender As Object, e As EventArgs) Handles btnAvantiStazioni.Click

        contaStaz = 0
        ' Conto il numero di righe già esistenti (1 è di default)
        For Each ctrl In Controls.OfType(Of Label)

            If ctrl.Name.StartsWith("lblContaStaz") Then contaStaz += 1
        Next

        numEmp = 0
        ' Controllo la presenza di campi vuoti
        For Each ctrl In Me.Controls.OfType(Of TextBox)

            If ctrl.Text = "" Then numEmp += 1
        Next

        If numEmp = 0 Then

            ' Scrittura del file Stazioni.cfg
            File.WriteAllText("config\Stazioni.cfg", "")
            wStazioni = File.AppendText("config\Stazioni.cfg")

            'wStazioni.WriteLine(txtSrvFTP1.Text & "," & txtStaz1.Text & "," &
            'txtRemPath1.Text & "," & chkGra1.Checked)

            For i = 1 To contaStaz
                wStazioni.WriteLine(Controls.Find("txtSrvFTP" & i, False)(0).Text & "," &
                Controls.Find("txtStaz" & i, False)(0).Text & "," &
                Controls.Find("txtRemPath" & i, False)(0).Text & "," &
                DirectCast(Controls.Find("chkGra" & i, False)(0), CheckBox).Checked)
            Next

            wStazioni.Close()
            Me.Close()
            frmPrincipale.subform(frmOpzServer)

        Else
            MsgBox("Errore! Ci sono " & numEmp & " caselle vuote." & vbCrLf &
                   "Riempire tutte le caselle, oppure rimuovere le righe vuote.", vbOKOnly, "Errore Opzioni Stazioni GNSS")
        End If
    End Sub
End Class