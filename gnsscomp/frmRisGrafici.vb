'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

'Si visualizza l'elenco delle CORS di cui sono stati creati i grafici sotto
'forma di link da cui si accede al risultato in forma grafica, nominato
'<NOME>_<SR>.png. I risultati possono essere selezionati in funzione del SR
'(sistema di riferimento) Europeo od Internazionale. Infine si visualizzano le
'velocità di spostamento (in planimetria e altimetria) sia in forma grafica che in
'forma testuale.
Public Class frmRisGrafici

    Public pthGra As String = "Grafici\"
    Public pthCrd As String = "Coordinate\"
    Public sr As String

    '''**********************************************************************
    ''' Nome:       frmRisGrafici_Load
    ''' Impone di default il check al radio button rbtnETRF.
    ''' **********************************************************************
    Private Sub frmRisGrafici_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbtnETRF.Checked = True

    End Sub

    '''**********************************************************************
    ''' Nome:       rbtnETRF_CheckedChanged
    ''' Al cambio del check sui radio button rbtnETRF e rbtnITRF viene 
    ''' lanciata con parametri differenti la sub sisriferimento.
    ''' **********************************************************************
    Private Sub rbtnETRF_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnETRF.CheckedChanged

        If rbtnETRF.Checked = True Then

            sr = "E00"
            sisriferimento(sr)
            rbtnITRF.Checked = False
        Else

            sr = "I20"
            rbtnITRF.Checked = True
            sisriferimento(sr)
        End If

        cmb_plh.SelectedItem = "Planimetria"

    End Sub

    '''**********************************************************************
    ''' Nome:       sisriferimento
    ''' In funzione del sr selezionato si visualizza l'elenco delle CORS di
    ''' cui sono stati i grafici sotto forma di link da cui si accede ai 
    ''' risultati in forma grafica, nonchè la mappa con le velocità.
    ''' **********************************************************************
    Private Sub sisriferimento(sr As String)
        Dim i As Integer

        ' Pulizia linklabel (6 sono i gli elementi già presenti sul frm)
        For i = 6 To Controls.Count - 1
            Controls.Remove(Controls(6))
        Next


        ' Mappa con le velocità
        If File.Exists(pthGra & "VELp" & sr & ".png") Then picVel.ImageLocation = pthGra & "VELp" & sr & ".png"


        If Directory.GetFiles(pthGra, "*_" & sr & ".png").Length > 0 Then

            i = 0
            For Each staz In Directory.GetFiles(pthGra, "*_" & sr & ".png")

                Dim linkstaz As New LinkLabel With {
                           .Name = "link" & Path.GetFileName(staz),
                           .Location = New Point(30, 82 + (20 + 26) * i),
                           .Text = Path.GetFileName(staz),
                           .Visible = True,
                           .AutoSize = True
                           }

                Controls.Add(linkstaz)

                AddHandler linkstaz.Click, AddressOf link_click
                i += 1

            Next
        Else
            Exit Sub
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       link_click
    ''' Visualizza il risultato (serie storica) in forma grafica.
    ''' **********************************************************************
    Private Sub link_click(sender As Object, e As EventArgs)

        Dim linkstaz As LinkLabel = DirectCast(sender, LinkLabel)
        Dim p As New Process
        Dim gra As New ProcessStartInfo(pthGra & linkstaz.Text) With {
            .UseShellExecute = True
        }

        If File.Exists(pthGra & linkstaz.Text) Then
            p.StartInfo = gra
            p.Start()
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       linkVelo_LinkClicked
    ''' Visualizza il risultato (velocità) in forma testuale.
    ''' **********************************************************************
    Private Sub linkVelo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkVelo.LinkClicked

        Dim p As New Process
        Dim gra As New ProcessStartInfo(pthCrd & "VEL.txt") With {
            .UseShellExecute = True
        }

        If File.Exists(pthCrd & "VEL.txt") Then
            p.StartInfo = gra
            p.Start()
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       picVel_Click
    ''' Visualizza il risultato (velocità) in forma grafica.
    ''' **********************************************************************
    Private Sub picVel_Click(sender As Object, e As EventArgs) Handles picVel.Click
        Dim p As New Process

        If File.Exists(picVel.ImageLocation) Then
            Dim gra As New ProcessStartInfo(picVel.ImageLocation) With {
            .UseShellExecute = True
        }

            p.StartInfo = gra
            p.Start()
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       cmb_plh_SelectedIndexChanged
    ''' In funzione del valore selezionato nella combo box cmb_pl (Planimetria
    ''' o Altimetria) si visualizza nella picture box picvel l'immagine 
    ''' corrispondente.
    ''' **********************************************************************
    Private Sub cmb_plh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_plh.SelectedIndexChanged

        Select Case cmb_plh.SelectedItem
            Case "Planimetria"
                picVel.ImageLocation = pthGra & "VELp" & sr & ".png"

            Case "Altimetria"
                picVel.ImageLocation = pthGra & "VELh" & sr & ".png"
        End Select

    End Sub
End Class