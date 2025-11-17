'*******************************************************************
' SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      *
' SPDX-License-Identifier: EUPL-1.2                                *
'*******************************************************************

Imports System.Math
Module Geog

    Public a As Double = 6378137.0                  'Semiasse maggiore ellissoide
    Public alpha As Double = 1.0 / 298.257223563    'Schiacciamento ellissoide
    Public CR As Double = 0.9996                    'Modulo di contrazione
    Public E0 As Double = 500000.0                  'Falsa origine Est UTM
    Public lon0 As Integer = 9.0                    'Longitudine di riferimento UTM fuso 32


    '''**********************************************************************
    ''' Nome:       I14toI20
    ''' Converte le coordinate geocentriche (X,Y,Z) dal sistema IGS14 al 
    ''' sistema IGS20 all'epoca corrente della settimana di compensazione.
    '''**********************************************************************
    Function I14toI20(X As Double, Y As Double, Z As Double, jd As Double, anno As Double)
        Dim T1, T2, T3, D, R1, R2, R3, T1dot, T2dot, T3dot, Ddot, R1dot, R2dot, R3dot As Double
        Dim T1_tc, T2_tc, T3_tc, D_tc, R1_tc, R2_tc, R3_tc As Double
        Dim tc As Double

        'Parametri da ITRF2014 a ITRF2020 (Boucher e Altamimi) - epoca 2015.0:
        T1 = 0.0014 'm
        T2 = 0.0009 'm
        T3 = -0.0014 'm
        D = 0.42 * Pow(10, -9)
        R1 = 0.0 'milli-arcseconds (mas)
        R2 = 0.0 'milli-arcseconds (mas)
        R3 = 0.0 'milli-arcseconds (mas)
        T1dot = 0.0 'm/yr
        T2dot = 0.0001 'm/yr
        T3dot = -0.0002 'm/yr
        Ddot = 0.0 * Pow(10, -9)
        R1dot = 0.0 'mas/yr
        R2dot = 0.0 'mas/yr
        R3dot = 0.0 'mas/yr

        'Conversione del tempo in "decimal year"
        tc = anno + (jd - 0.75) / 365.25

        'Propagazione all'epoca corrente dei parametri di Altamimi
        T1_tc = T1 + T1dot * (tc - 2015.0) 'm
        T2_tc = T2 + T2dot * (tc - 2015.0) 'm
        T3_tc = T3 + T3dot * (tc - 2015.0) 'm
        D_tc = D + Ddot * (tc - 2015.0) 'parts
        R1_tc = (R1 + R1dot * (tc - 2015.0)) * 0.001 * Math.PI / (360 * 1800) 'rad
        R2_tc = (R2 + R2dot * (tc - 2015.0)) * 0.001 * Math.PI / (360 * 1800) 'rad
        R3_tc = (R3 + R3dot * (tc - 2015.0)) * 0.001 * Math.PI / (360 * 1800) 'rad

        'Applicazione formula di Altamimi al tempo corrente: [XI00 = XI14 + T + RD x XI14]
        Dim XI14 = {X, Y, Z}
        Dim T = {T1_tc, T2_tc, T3_tc}
        Dim RD = {{D_tc, -R3_tc, R2_tc}, {R3_tc, D_tc, -R1_tc}, {-R2_tc, R1_tc, D_tc}}
        Dim XI20 = {0.0, 0.0, 0.0}
        Dim sum As Double
        Dim i, j As Integer

        'Operazione: [RD x XI14] + XI14 + T
        For i = 0 To 2
            sum = 0
            For j = 0 To 2
                sum += RD(i, j) * XI14(j)
            Next
            XI20(i) = sum + XI14(i) + T(i)
        Next

        'CRD In ITRF2020 Epoca tc
        Return XI20

    End Function


    '''**********************************************************************
    ''' Nome:       IGStoETRF
    ''' Converte le coordinate geocentriche (X,Y,Z) dal sistema IGS20 al 
    ''' sistema ETRF2000 all'epoca corrente della settimana di compensazione.
    '''**********************************************************************
    Function IGStoETRF(X As Double, Y As Double, Z As Double, jd As Double, anno As Double)
        Dim T1, T2, T3, D, R1, R2, R3, T1dot, T2dot, T3dot, Ddot, R1dot, R2dot, R3dot As Double
        Dim T1_tc, T2_tc, T3_tc, D_tc, R1_tc, R2_tc, R3_tc As Double
        Dim tc As Double

        'Parametri da ITRF2020 a ITRF2000 (Boucher e Altamimi) - epoca 2015.0:
        T1 = -0.0002 'm
        T2 = 0.0008 'm
        T3 = -0.0342 'm
        D = 2.25 * Pow(10, -9)
        R1 = 0.0 'milli-arcseconds (mas)
        R2 = 0.0 'milli-arcseconds (mas)
        R3 = 0.0 'milli-arcseconds (mas)
        T1dot = 0.0001 'm/yr
        T2dot = 0.0 'm/yr
        T3dot = -0.0017 'm/yr
        Ddot = 0.11 * Pow(10, -9)
        R1dot = 0.0 'mas/yr
        R2dot = 0.0 'mas/yr
        R3dot = 0.0 'mas/yr

        'Conversione del tempo in "decimal year"
        tc = anno + (jd - 0.75) / 365.25

        'Propagazione all'epoca corrente dei parametri di Altamimi
        T1_tc = T1 + T1dot * (tc - 2015.0) 'm
        T2_tc = T2 + T2dot * (tc - 2015.0) 'm
        T3_tc = T3 + T3dot * (tc - 2015.0) 'm
        D_tc = D + Ddot * (tc - 2015.0) 'parts
        R1_tc = (R1 + R1dot * (tc - 2015.0)) * 0.001 * Math.PI / (360 * 1800) 'rad
        R2_tc = (R2 + R2dot * (tc - 2015.0)) * 0.001 * Math.PI / (360 * 1800) 'rad
        R3_tc = (R3 + R3dot * (tc - 2015.0)) * 0.001 * Math.PI / (360 * 1800) 'rad

        'Applicazione formula di Altamimi al tempo corrente: [XI00 = XI14 + T + RD x XI14]
        Dim XI14 = {X, Y, Z}
        Dim T = {T1_tc, T2_tc, T3_tc}
        Dim RD = {{D_tc, -R3_tc, R2_tc}, {R3_tc, D_tc, -R1_tc}, {-R2_tc, R1_tc, D_tc}}
        Dim XI00 = {0.0, 0.0, 0.0}
        Dim sum As Double
        Dim i, j As Integer

        'Operazione: [RD x XI14] + XI14 + T
        For i = 0 To 2
            sum = 0
            For j = 0 To 2
                sum += RD(i, j) * XI14(j)
            Next
            XI00(i) = sum + XI14(i) + T(i)
        Next

        'Parametri da ITRF2000 a ETRF2000 (Boucher e Altamimi) - epoca 1989.0:
        T1 = 0.054 'm
        T2 = 0.051 'm
        T3 = -0.048 'm
        R1dot = 0.081 * 0.001 * Math.PI / (360 * 1800) 'rad
        R2dot = 0.49 * 0.001 * Math.PI / (360 * 1800) 'rad
        R3dot = -0.792 * 0.001 * Math.PI / (360 * 1800) 'rad

        'Applicazione formula di Altamimi al tempo corrente: [XE00 = XI00 + T + RD x XI00 x (tc-1989)]
        Dim XE00 = {0.0, 0.0, 0.0}
        T = {T1, T2, T3}
        RD = {{0, -R3dot, R2dot}, {R3dot, 0, -R1dot}, {-R2dot, R1dot, 0}}

        'Prodotto: [RD x XI00 x (tc-1989)] + XI00 + T
        For i = 0 To 2
            sum = 0
            For j = 0 To 2
                sum += RD(i, j) * XI00(j)
            Next
            XE00(i) = sum * (tc - 1989.0) + XI00(i) + T(i)
        Next

        'CRD In ETRF2000 Epoca tc
        Return XE00

    End Function

    '''**********************************************************************
    ''' Nome:       XYZtoGeo
    ''' Converte le coordinate geocentriche (X,Y,Z) in cordinate geografiche 
    ''' (Lat, Lon, hell).
    '''**********************************************************************
    Function XYZtoGeo(x As Double, y As Double, z As Double)
        Dim e2, elat, eht, p, lat, lon, h, dh, dlat, lat0, h0, v As Double

        e2 = 1.0 - Pow(1 - alpha, 2)
        elat = Pow(Math.E, -12)
        eht = Pow(Math.E, -5)
        p = Sqrt(Pow(x, 2.0) + Pow(y, 2))
        lat = Atan2(z, p / (1.0 - e2))
        h = 0.0
        dh = 1.0
        dlat = 1.0

        While (dlat > elat) Or (dh > eht)
            lat0 = lat
            h0 = h
            v = a / Sqrt(1 - e2 * Pow(Sin(lat), 2))
            h = p / Cos(lat) - v
            lat = Atan2(z, p * (1 - e2 * v / (v + h)))
            dlat = Abs(lat - lat0)
            dh = Abs(h - h0)
        End While

        lon = Atan2(y, x)
        Dim crdGeo() As Double = {lat, lon, h}

        Return crdGeo

    End Function

    '''**********************************************************************
    ''' Nome:       GeoToEN
    ''' Converte le coordinate geografiche (Lat, Lon, hell) in coordinate
    ''' cartografiche (Est, Nord, hell)
    '''**********************************************************************
    Function GeoToEN(lat As Double, lon As Double, hell As Double)
        Dim ep2, e2, A1, A2, A4, A6, c, Rp, v, z, v1, xi
        Dim est, nord As Double

        lon -= (lon0 * Math.PI / 180.0)

        e2 = 1.0 - Pow(1 - alpha, 2)
        ep2 = e2 / (1.0 - e2)
        A1 = 1.0 - e2 / 4.0 - 3.0 * Pow(e2, 2.0) / 64.0 - 5.0 * Pow(e2, 3.0) / 256.0
        A2 = 3.0 * e2 / 8.0 + 3.0 * Pow(e2, 2.0) / 32.0 + 45.0 * Pow(e2, 3.0) / 1024.0
        A4 = 15.0 * Pow(e2, 2.0) / 256.0 + 45.0 * Pow(e2, 3.0) / 1024.0
        A6 = 35.0 * Pow(e2, 3.0) / 3072.0

        c = a - alpha * a
        Rp = Pow(a, 2.0) / c

        v = Sqrt(1.0 + ep2 * Pow(Cos(lat), 2.0))
        z = Atan(Tan(lat) / Cos(lon * v))
        v1 = Sqrt(1.0 + ep2 * Pow(Cos(z), 2.0))
        xi = Cos(z) * Tan(lon) / v1
        est = Rp * Log(xi + Sqrt(Pow(xi, 2) + 1))
        nord = a * (A1 * z - A2 * Sin(2.0 * z) + A4 * Sin(4.0 * z) - A6 * Sin(6.0 * z))

        est = est * CR + E0
        nord *= CR
        Dim crdUTM() As Double = {est, nord, hell}

        Return crdUTM

    End Function

End Module
