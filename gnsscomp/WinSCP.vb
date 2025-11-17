'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO

Module WinSCP

    '''**********************************************************************
    ''' Nome:       WinSCP_opt
    ''' Ricava dal file Server.cfg i parametri di connessione FTP del server.
    '''**********************************************************************
    Function WinSCP_opt(server As String)
        Dim srvLinea, srvAdd, srvUsr, serverPass As String
        Dim sessionOptions As New SessionOptions

        '  **** LETTURA DEL FILE Server.cfg ****

        Try
            Dim rSrv As New StreamReader("config\Server.cfg")

            Do While rSrv.Peek() > 0
                srvLinea = rSrv.ReadLine()

                If Split(srvLinea, ",")(0) = server Then
                    srvAdd = Split(srvLinea, ",")(1)
                    srvUsr = Split(srvLinea, ",")(2)
                    serverPass = Split(srvLinea, ",")(3)

                    Exit Do
                End If
            Loop
            rSrv.Close()

            'Opzioni di connessione server
            With sessionOptions
                .HostName = srvAdd
                .UserName = srvUsr
                .Password = serverPass
            End With

        Catch ex As Exception

            frmPrincipale.txtLog.SelectionColor = Color.Red
            frmPrincipale.txtLog.SelectedText = DateTime.Now & " !!! ERRORE nella lettura del file Server.cfg " & vbCrLf
        End Try

        Return sessionOptions

    End Function


    '''***********************************************************************
    ''' Nome:       WinSCP_dwn
    ''' Utilizzo del software WinSCP per scaricare i file desiderati.
    '''**********************************************************************
    Function WinSCP_dwn(remotePath As String, localPath As String,
                        mandatory As String, sessionOptions As SessionOptions)

        Dim TransferResult As String = "False"
        Dim err As String

        sessionOptions.Protocol = Protocol.Ftp
        sessionOptions.FtpMode = FtpMode.Passive
        sessionOptions.PortNumber = 21
        sessionOptions.Timeout = New TimeSpan(0, 0, 0, 30, 0)

        Dim i = 0
        While TransferResult Is "False" And i < 3
            i += 1

            Try
                Using session As New Session
                    'Connessione tramite winscp al server
                    session.Open(sessionOptions)
                    'Opzioni di trasferimento
                    Dim transferOptions As New TransferOptions
                    transferOptions.AddRawSettings("ReplaceInvalidChars", "0")
                    Dim transferResultOption As TransferOperationResult
                    'Download dei file
                    transferResultOption = session.GetFiles(remotePath, localPath, False, transferOptions)
                    TransferResult = transferResultOption.IsSuccess
                    session.Close()
                End Using

            Catch ex As Exception

                TransferResult = "False"

                If mandatory = "yes" Then
                    err = DateTime.Now & " !!! Tentativo " & i & " : ERRORE durante il download del file " & remotePath & " .Il server non risponde!"
                    frmPrincipale.txtLog.SelectionColor = Color.Red
                    frmPrincipale.txtLog.SelectedText = err & vbCrLf

                    Threading.Thread.Sleep(30000)
                Else

                    Exit While
                End If

            End Try

            If mandatory = "no" And TransferResult = "False" Then Exit While
        End While

        Return TransferResult
    End Function

End Module
