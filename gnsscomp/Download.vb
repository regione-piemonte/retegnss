'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.IO
Imports System.IO.Compression

Module Download

    '''**********************************************************************
    ''' Nome:       FileAstronomici
    ''' Scarica i file contenenti i dati astronomici.
    '''**********************************************************************
    Sub FileAstronomici(pthGEN As String, sessionOptions As SessionOptions)
        Dim remotePath As String = "/BSWUSER52/GEN/*"
        Dim localPath As String = Environ("X") & "\GEN\"
        Dim transferRes As Boolean

        transferRes = WinSCP.WinSCP_dwn(remotePath, localPath, "no", sessionOptions)

        'Copio i file all'interno della cartella GEN
        For Each f As String In My.Computer.FileSystem.GetFiles(pthGEN)
            Dim fname As String = Path.GetFileName(f)
            File.Copy(f, Path.Combine(localPath, fname), True)
        Next

        If transferRes = True Then
            frmPrincipale.txtLog.SelectionColor = Color.Black
            frmPrincipale.txtLog.SelectedText = DateTime.Now & " [ GEN ] Cartella aggiornata con successo." & vbCrLf
        End If

    End Sub

    '''**********************************************************************
    ''' Nome:       MotoPolo
    ''' Scarica i file contenenti i dati sul moto del polo.
    '''**********************************************************************
    Sub MotoPolo(anno As String, sessionOptions As SessionOptions)
        Dim remotePath, filename, localPath As String

        remotePath = "/BSWUSER52/ORB/C04_" & anno & ".ERP"
        filename = remotePath.Split("/")(UBound(remotePath.Split("/")))
        localPath = Environ("X") & "\GEN\"

        WinSCP.WinSCP_dwn(remotePath, localPath, "yes", sessionOptions)

        Varie.Log_Verifica("Moto_Polo", localPath & filename, "Download")

    End Sub

    '''**********************************************************************
    ''' Nome:       Effemeridi
    ''' Scarica i file contenenti i dati sulle effemeridi precise.
    '''**********************************************************************
    Sub Effemeridi(dow As String, doy As String, settimana As String,
                   anno As String, sessionOptions As SessionOptions)
        Dim filename, localPath, remotePath, filename_fin, transferRes As String

        If CInt(settimana) < 1856 Then
            remotePath = "/CODE/" & anno & "/COD" & settimana & dow & ".EPH.Z"

        ElseIf CInt(settimana) >= 1856 And CInt(settimana) < 2238 Then
            remotePath = "/CODE/" & anno & "_M/COD" & settimana & dow & ".EPH_M.Z"

        ElseIf CInt(settimana) >= 2238 Then
            remotePath = "/CODE/" & anno & "/COD0OPSFIN_" & anno & doy & "0000_01D_05M_ORB.SP3.gz"
        End If

        filename = remotePath.Split("/")(UBound(remotePath.Split("/")))
        filename_fin = "COM" & settimana & dow & ".EPH.gz"
        localPath = Environ("D") & "\COM\"

        If Not File.Exists(localPath & filename_fin) Then

            transferRes = WinSCP.WinSCP_dwn(remotePath, localPath, "yes", sessionOptions)
            If transferRes = "True" Then Rename(localPath & filename, localPath & filename_fin)
        End If

        Varie.Log_Verifica("Effemeridi_precise", localPath & filename_fin, "Download")

    End Sub

    '''**********************************************************************
    ''' Nome:       EOrologio
    ''' Scarica i file contenenti i dati sul'errore di orologio dei satelliti.
    '''**********************************************************************
    Sub EOrologio(dow As String, doy As String, settimana As String,
                  anno As String, sessionOptions As SessionOptions)
        Dim filename, localPath, remotePath, filename_fin, transferRes As String

        If CInt(settimana) < 1856 Then
            remotePath = "/CODE/" & anno & "/COD" & settimana & dow & ".EPH.Z"

        ElseIf CInt(settimana) >= 1856 And CInt(settimana) < 2238 Then
            remotePath = "/CODE/" & anno & "_M/COD" & settimana & dow & ".CLK_M.Z"

        ElseIf CInt(settimana) >= 2238 Then
            remotePath = "/CODE/" & anno & "/COD0OPSFIN_" & anno & doy & "0000_01D_30S_CLK.CLK.gz"
        End If

        filename = remotePath.Split("/")(UBound(remotePath.Split("/")))
        filename_fin = "COM" & settimana & dow & ".CLK.gz"
        localPath = Environ("D") & "\COM\"

        If Not File.Exists(localPath & filename_fin) Then

            transferRes = WinSCP.WinSCP_dwn(remotePath, localPath, "yes", sessionOptions)
            If transferRes = "True" Then Rename(localPath & filename, localPath & filename_fin)
        End If

        Varie.Log_Verifica("Errore_Orologio", localPath & filename_fin, "Download")

    End Sub

    '''**********************************************************************
    ''' Nome:       MTerrestre
    ''' Scarica i file contenenti i dati sul moto terrestre.
    '''**********************************************************************
    Sub MTerrestre(doy As String, settimana As String,
                   anno As String, sessionOptions As SessionOptions)
        Dim filename, localPath, remotePath, filename_fin, transferRes As String

        If CInt(settimana) < 2238 Then
            remotePath = "/CODE/" & anno & "/COD" & settimana & "7.ERP.Z"

        ElseIf CInt(settimana) >= 2238 Then
            remotePath = "/CODE/" & anno & "/COD0OPSFIN_" & anno & doy & "0000_07D_01D_ERP.ERP.gz"
        End If

        filename = remotePath.Split("/")(UBound(remotePath.Split("/")))
        filename_fin = "COM" & settimana & "7.ERP.gz"
        localPath = Environ("D") & "\COM\"

        If Not File.Exists(localPath & filename_fin) Then

            transferRes = WinSCP.WinSCP_dwn(remotePath, localPath, "yes", sessionOptions)
            If transferRes = "True" Then Rename(localPath & filename, localPath & filename_fin)
        End If

        Varie.Log_Verifica("Moto_Terrestre", localPath & filename_fin, "Download")

    End Sub

    '''**********************************************************************
    ''' Nome:       Ionosfera
    ''' Scarica i file contenenti i dati sulla ionosfera.
    '''**********************************************************************
    Sub Ionosfera(dow As String, doy As String, settimana As String,
                  anno As String, sessionOptions As SessionOptions)
        Dim filename, remotePath, filename_fin, transferRes As String
        Dim localPath As String = Environ("D") & "\BSW52\"

        If CInt(settimana) < 2238 Then
            remotePath = "/CODE/" & anno & "/COD" & settimana & dow & ".ION.Z"

        ElseIf CInt(settimana) >= 2238 Then
            remotePath = "/CODE/" & anno & "/COD0OPSFIN_" & anno & doy & "0000_01D_01H_GIM.ION.gz"
        End If

        filename = remotePath.Split("/")(UBound(remotePath.Split("/")))
        filename_fin = "COD" & settimana & dow & ".ION.gz"

        If Not File.Exists(localPath & filename_fin) Then

            transferRes = WinSCP.WinSCP_dwn(remotePath, localPath, "yes", sessionOptions)
            If transferRes = "True" Then Rename(localPath & filename, localPath & filename_fin)
        End If

        Varie.Log_Verifica("Ionosfera", localPath & filename_fin, "Download")

    End Sub

    '''**********************************************************************
    ''' Nome:       DCB
    ''' Scarica i file contenenti i DCB.
    '''**********************************************************************
    Sub DCB(mese As String, anno As String, sessionOptions As SessionOptions)
        Dim remotePath, filename, localPath, remotePath_dcb, filename_dcb, transferRes As String
        Dim pc() As String = {"C1", "P2"}

        remotePath = "/CODE/" & anno & "/P1*" & Right(anno, 2) & mese & ".DCB.Z"
        filename = remotePath.Split("/")(UBound(remotePath.Split("/")))
        localPath = Environ("D") & "\BSW52\"

        For Each i In pc
            remotePath_dcb = Replace(remotePath, "*", i)
            filename_dcb = Replace(filename, "*", i)

            transferRes = WinSCP.WinSCP_dwn(remotePath_dcb, localPath, "yes", sessionOptions)

            Varie.Log_Verifica("DCB", localPath & filename_dcb, "Download")
        Next

    End Sub

    '''**********************************************************************
    ''' Nome:       CoordinateREF
    ''' Scarica ed adatta il file contenente le coordinate delle CORS di
    ''' riferimento.
    '''**********************************************************************
    Sub CoordinateREF(remotepath As String, settimana As String, data As Date, camp As String,
                      sessionOptions As SessionOptions, CRS As String, bin7z As String)
        Dim transferRes As String
        Dim filename_orig, filename_zip, filename As String
        Dim filename_fin = "ref" & settimana & "7.crd"
        Dim filename_all = "ref" & settimana & "7.crd_all"

        Dim localPath As String = Environ("D") & "\REF52\"
        Dim crdwrite As StreamWriter

        filename_orig = Path.GetFileName(remotepath)
        filename = Path.GetFileNameWithoutExtension(remotepath)

        If Not File.Exists(localPath & filename_fin) Then

            transferRes = WinSCP.WinSCP_dwn(remotepath, localPath, "yes", sessionOptions)
            If transferRes = "True" Then

                ' Decomprimo il file qualora sia di tipo archivio .gz o .Z
                Try
                    Select Case Path.GetExtension(filename_orig)

                        Case ".gz"
                            filename_zip = filename_orig

                            Dim compressedFileStream As FileStream = File.Open(localPath & filename_zip, FileMode.Open)
                            Dim outputFileStream As FileStream = File.Create(localPath & filename)
                            Dim decompressor As New GZipStream(compressedFileStream, CompressionMode.Decompress)

                            decompressor.CopyTo(outputFileStream)

                            compressedFileStream.Close()
                            outputFileStream.Close()
                            decompressor.Close()

                            File.Delete(localPath & filename_zip)

                        Case ".Z"
                            filename_zip = filename_orig

                            Dim p As New Process
                            Dim zip As New ProcessStartInfo("cmd.exe", String.Concat("/c " & bin7z & "\7z.exe e -aos ", localPath, filename_zip & " -o" & localPath))
                            p.StartInfo = zip
                            p.Start()
                            p.WaitForExit()

                            File.Delete(localPath & filename_zip)

                    End Select


                    ' Per i file di tipo SNX ne estraggo l'elenco delle coordinate stimate
                    If Path.GetExtension(filename) = ".SNX" Or Path.GetExtension(filename) = ".snx" Then

                        Rename(localPath & filename, localPath & "ref" & settimana & "7.snx")
                        filename = "ref" & settimana & "7.snx"

                        Varie.Prep_CRDfix(filename, localPath)
                        filename = "snx" & settimana & "7.crd"

                    End If
                Catch ex As Exception

                    frmPrincipale.txtLog.SelectionColor = Color.Red
                    frmPrincipale.txtLog.SelectedText = DateTime.Now & " [CoordinateREF] !!! Formato file sconosciuto!" & vbCrLf
                End Try


                'Creo una versione modificata del file appena scaricato lasciando sono le coordinate
                'delle stazioni permanenti di vincolo scritte nel file _.FIX
                Try

                    Rename(localPath & filename, localPath & filename_all)
                Catch ex As Exception

                    frmPrincipale.txtLog.SelectionColor = Color.Red
                    frmPrincipale.txtLog.SelectedText = DateTime.Now & " [CoordinateREF] !!! Formato file sconosciuto!" & vbCrLf
                End Try

                File.Create(localPath & filename_fin).Close()
                crdwrite = File.AppendText(localPath & filename_fin)
                Dim refList() As String = File.ReadAllLines(localPath & filename_all)
                Dim stazFIX() As String = File.ReadAllLines(Environ("D") & "\REF52\" & camp & ".FIX")


                'Intestazione di refWWWW7.crd
                crdwrite.WriteLine("EPN combined solution for week " & settimana & "                              ##-###-## ##:##" & vbCrLf &
                "--------------------------------------------------------------------------------" & vbCrLf &
                "LOCAL GEODETIC DATUM: " & CRS & "             EPOCH: " & Format(data.Year, "0000") & "-" & Format(data.Month, "00") & "-" & Format(data.Day, "00") & " 00:00:00" & vbCrLf &
                vbCrLf & "NUM  STATION NAME           X (M)          Y (M)          Z (M)     FLAG" & vbCrLf)


                For i = 6 To refList.Length() - 1
                    If refList(i) <> "" And stazFIX.Contains(Mid(refList(i), 6, 14)) Then 'Il rigo non deve essere vuoto

                        crdwrite.WriteLine(Left(refList(i), 66) & "    I")
                    End If
                Next

                crdwrite.Close()
                File.Delete(localPath & filename_all)
                File.Copy(localPath & filename_fin, Environ("P") & "\" & camp & "\STA\" & filename_fin)

            End If

        End If

        Varie.Log_Verifica("CoordinateREF", localPath & filename_fin, "Download")

    End Sub

    '''**********************************************************************
    ''' Nome:       Rinex
    ''' Scarica i file RINEX.
    '''**********************************************************************
    Sub Rinex(remotePath As String, anno As String, doy As String,
              sessionOptions As SessionOptions)
        Dim rinex As String
        Dim localPath = Environ("D") & "\RINEX3\"

        remotePath = Replace(remotePath, "YYYY", anno)
        remotePath = Replace(remotePath, "YY", Right(anno, 2))
        remotePath = Replace(remotePath, "DDD", doy)

        rinex = Path.GetFileName(remotePath)

        If Not File.Exists(localPath & rinex) Then WinSCP.WinSCP_dwn(remotePath, localPath, "no", sessionOptions)

        Varie.Log_Verifica("RINEX", localPath & rinex, "Download")

    End Sub

End Module


