'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

'Si visualizza l'elenco delle CORS di cui sono state calcolate le coordinate
'sotto forma di link da cui si accede ai risultati in forma di file testuale,
'nominato <NOME>.crd contenente l'elenco delle soluzioni per tutte le epoche
'considerate, nei sistemi di riferimento Europeo ed Internazionale.
Public Class frmRisCrd

    Public pthCrd As String = "Coordinate\"
    Public pthGra As String = "Grafici\"

    '''**********************************************************************
    ''' Nome:       frmRisCrd_Load
    ''' Visualizza l'elenco delle CORS di cui sono state calcolate le
    ''' coordinate sotto forma di link da cui si accede ai risultati in forma
    ''' di file testuale, nonchè la mappa.
    ''' **********************************************************************
    Private Sub frmRisCrd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim i As Integer

        If File.Exists(pthGra & "MAPPA.png") Then
            picMappaCrd.ImageLocation = pthGra & "MAPPA.png"
        Else
            picMappaCrd.Visible = False
        End If

        If Directory.GetFiles(pthCrd, "*.crd").Length > 0 Then

            i = 0
            For Each staz In Directory.GetFiles(pthCrd, "*.crd")

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
    ''' Visualizza l'elenco delle coordinate ottenute per quella CORS in forma
    ''' di file testuale.
    ''' **********************************************************************
    Private Sub link_click(sender As Object, e As EventArgs)

        Dim linkstaz As LinkLabel = DirectCast(sender, LinkLabel)
        Dim p As New Process
        Dim crd As New ProcessStartInfo(pthCrd & linkstaz.Text) With {
            .UseShellExecute = True
        }

        p.StartInfo = crd
        p.Start()

    End Sub

End Class