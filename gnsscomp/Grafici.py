####################################################################
# SPDX-FileCopyrightText: (C) Copyright 2025 Regione Piemonte      #
# SPDX-License-Identifier: EUPL-1.2                                #
####################################################################

# Script per la generazione dei grafici e per il calcolo delle velocità
import os
import glob
from datetime import datetime
from scipy.interpolate import interp1d
import matplotlib.pyplot as plt
import numpy as np


# Directory principali
crdPath = "\\Coordinate\\"
graPath = "\\Grafici\\"


def main():
    crdList = glob.glob(os.getcwd() + crdPath + '*.crd')

    # Scrittura file delle velocità
    vel_file = (os.getcwd() + crdPath + 'VEL.txt')
    f = open(vel_file, 'w')
    f.write('{0:<9}{1:<74}{2:<8}\n'.format('STAZ', 'ITRF2020', 'ETRF2000'))
    f.write('{0:<6}{1:^12}{2:^12}{3:^12}{4:^12}{5:^10}{6:^12}    '
            '{7:^12}{8:^12}{9:^12}{10:^12}{11:^10}{12:^12}\n\n'.
            format('', 'Est(M)', 'v_Est(cm/Y)', 'Nord(M)', 'v_Nord(cm/Y)', 'Hell(M)', 'v_Hell(cm/Y)',
                       'Est(M)', 'v_Est(cm/Y)', 'Nord(M)', 'v_Nord(cm/Y)', 'Hell(M)', 'v_Hell(cm/Y)'))

    # Lettura dei file crd e evnt
    for crdFile in crdList:
        staz = crdFile[-8:-4]
        evntFile = os.getcwd() + graPath + staz + '.evnt'

        # Leggo file delle coordinate
        week, Est_I, Nord_I, H_I, Est_E, Nord_E, H_E = crdRead(crdFile)
        # Leggo file degli eventi di cambio antenna
        evnt = evntRead(evntFile)
        # Trovo coordinate medie delle stazioni
        crd_m = (np.mean(Est_I), np.mean(Nord_I), np.mean(H_I), np.mean(Est_E), np.mean(Nord_E), np.mean(H_E))

        dEst_I = []
        dNord_I = []
        dH_I = []
        dEst_E = []
        dNord_E = []
        dH_E = []

        for i in range(0, len(week)):
            # Spostamenti [cm]
            dEst_I.append((Est_I[i] - Est_I[0]) * 100)
            dNord_I.append((Nord_I[i] - Nord_I[0]) * 100)
            dH_I.append((H_I[i] - H_I[0]) * 100)
            dEst_E.append((Est_E[i] - Est_E[0]) * 100)
            dNord_E.append((Nord_E[i] - Nord_E[0]) * 100)
            dH_E.append((H_E[i] - H_E[0]) * 100)

        # Plottaggio serie temporali
        plotcrd(staz, week, dEst_I, dNord_I, dH_I, evnt, 'ITRF2020')
        plotcrd(staz, week, dEst_E, dNord_E, dH_E, evnt, 'ETRF2000')

        # Funzioni velocità [cm/sett]
        vEst_I = interp1d(week, dEst_I)
        vNord_I = interp1d(week, dNord_I)
        vH_I = interp1d(week, dH_I)
        vEst_E = interp1d(week, dEst_E)
        vNord_E = interp1d(week, dNord_E)
        vH_E = interp1d(week, dH_E)

        # Velocità [cm/Y]
        velEst_I = (vEst_I(week[-1]) - vEst_I(week[0])) / (week[-1] - week[0]) * (365.242 / 7)
        velNord_I = (vNord_I(week[-1]) - vNord_I(week[0])) / (week[-1] - week[0]) * (365.242 / 7)
        velH_I = (vH_I(week[-1]) - vH_I(week[0])) / (week[-1] - week[0]) * (365.242 / 7)
        velEst_E = (vEst_E(week[-1]) - vEst_E(week[0])) / (week[-1] - week[0]) * (365.242 / 7)
        velNord_E = (vNord_E(week[-1]) - vNord_E(week[0])) / (week[-1] - week[0]) * (365.242 / 7)
        velH_E = (vH_E(week[-1]) - vH_E(week[0])) / (week[-1] - week[0]) * (365.242 / 7)

        # Scrivo le velocità sul file VEL.txt
        f.write('{0:<6}{1:>12.2f}{2:>12.5f}{3:>12.2f}{4:>12.5f}{5:>10.2f}{6:>12.5f}    '
                '{7:>12.2f}{8:>12.5f}{9:>12.2f}{10:>12.5f}{11:>10.2f}{12:>12.5f}\n'.
                format(staz, crd_m[0], velEst_I, crd_m[1], velNord_I, crd_m[2], velH_I,
                       crd_m[3], velEst_E, crd_m[4], velNord_E, crd_m[5], velH_E))
    f.close()

    # Plottaggio grafico di velocità e coordinate
    plotmap(vel_file)
    

def crdRead(crdFile):
    f = open(crdFile, 'r')
    # Lettura header
    f.readline()
    f.readline()
    f.readline()

    week = []
    estI = []
    nordI = []
    hellI = []
    estE = []
    nordE = []
    hellE = []

    # Lettura delle coordinate per settimana GPS
    line = f.readline()
    while len(line) > 0:
        week.append(int(line[0:5]))
        estI.append(float(line[9:22].replace(",", ".")))
        nordI.append(float(line[26:40].replace(",", ".")))
        hellI.append(float(line[44:55].replace(",", ".")))
        estE.append(float(line[63:76].replace(",", ".")))
        nordE.append(float(line[80:94].replace(",", ".")))
        hellE.append(float(line[98:108].replace(",", ".")))
        line = f.readline()
    f.close()

    return week, estI, nordI, hellI, estE, nordE, hellE


def evntRead(evntFile):
    f = open(evntFile, 'r')
    # Lettura header
    f.readline()

    evnt = []

    # Lettura epoca delle coordinate
    line = f.readline()
    while len(line) > 0:
        data = datetime.strptime(line[0:8], "%d\\%m\\%y")
        data0 = datetime.strptime('06/01/1980', "%d/%m/%Y")

        evnt.append(((data - data0) / 7).days)
        line = f.readline()
    f.close()

    return evnt


def plotcrd(staz, t, dest, dnord, dhell, evnt, crs):

    if crs == "ITRF2020":
        csrlbl = "I20"
    if crs == "ETRF2000":
        csrlbl = "E00"

    enlim = 1
    hlim = 5

    fig = plt.figure(num=None, figsize=[15, 7])
    ax1 = fig.add_subplot(311)
    plt.title("STAZ. ID: " + staz + " - CRS: " + crs)

    # Grafico h
    plt.axis([np.min(t), np.max(t), -hlim, hlim])
    ax1.tick_params(axis="x", direction="in")
    plt.grid(linestyle=":")
    plt.ylabel('Delta h [cm]')
    plt.yticks([-4, -2, 0, 2, 4])
    plt.plot(t, dhell, 'b.')
    plt.text(min(t) + 0.1, hlim - 1, 'Hmin= ' + '%.3f' % min(dhell) + ' , Hmax= ' + '%.3f' % max(dhell) + ' , Hmean= ' +
             '%.3f' % np.mean(dhell) + ' , Hstd= ' + '%.3f' % np.std(dhell), ha='left', va='bottom')
    for e in evnt:
        if t[-1] > e > t[0]:
            xe = [e, e]
            ye = [-hlim, hlim]
            plt.plot(xe, ye, 'r-', alpha=0.5)

    ax2 = plt.subplot(312)
    # Grafico Est
    plt.axis([np.min(t), np.max(t), -enlim, enlim])
    ax2.tick_params(axis="x", direction="in")
    plt.grid(linestyle=":")
    plt.ylabel('Delta Est [cm]')
    plt.yticks([-1, -0.5, 0, 0.5, 1])
    plt.plot(t, dest, 'b.')
    plt.text(min(t) + 0.1, enlim - 0.2, 'Emin= ' + '%.3f' % min(dest) + ' , Emax= ' + '%.3f' % max(dest) + ' , Emean= '
             + '%.3f' % np.mean(dest) + ' , Estd= ' + '%.3f' % np.std(dest), ha='left', va='bottom')
    for e in evnt:
        if t[-1] > e > t[0]:
            xe = [e, e]
            ye = [-enlim, enlim]
            plt.plot(xe, ye, 'r-', alpha=0.5)

    ax3 = plt.subplot(313)
    # Grafico Nord
    plt.axis([np.min(t), np.max(t), -enlim, enlim])
    ax3.tick_params(axis="x", direction="in")
    plt.grid(linestyle=":")
    plt.ylabel('Delta Nord [cm]')
    plt.yticks([-1, -0.5, 0, 0.5, 1])
    plt.plot(t, dnord, 'b.')
    plt.text(min(t) + 0.1, enlim - 0.2, 'Nmin= ' + '%.3f' % min(dnord) + ' , Nmax= ' + '%.3f' % max(dnord) +
             ' , Nmean= ' + '%.3f' % np.mean(dnord) + ' , Nstd= ' + '%.3f' % np.std(dnord), ha='left', va='bottom')
    i = 0
    for e in evnt:
        if t[-1] > e > t[0]:
            xe = [e, e]
            ye = [-enlim, enlim]
            ev, = plt.plot(xe, ye, 'r-', alpha=0.5)
            if i == 0:
                ev.set_label('Cambio Antenna')
                plt.legend(loc='lower right')
        i = i + 1

    plt.subplots_adjust(left=0.10, right=0.95, bottom=0.05, top=0.95)
    plt.savefig(os.getcwd() + graPath + staz + '_' + csrlbl + '.png', dpi=300)
    plt.close()


def velread(velfile):
    f = open(velfile, 'r')
    # Lettura header
    f.readline()
    f.readline()
    f.readline()

    # Creazione dizionario
    velo = {}

    # Lettura file velocita' e scrittura nel dizionario
    line = f.readline()
    while len(line) > 0:
        staz = line.split()[0]
        Est_I = float(line.split()[1])
        vEst_I = float(line.split()[2])
        Nord_I = float(line.split()[3])
        vNord_I = float(line.split()[4])
        H_I = float(line.split()[5])
        vH_I = float(line.split()[6])
        Est_E = float(line.split()[7])
        vEst_E = float(line.split()[8])
        Nord_E = float(line.split()[9])
        vNord_E = float(line.split()[10])
        H_E = float(line.split()[11])
        vH_E = float(line.split()[12])
        velo[staz] = (Est_I, vEst_I, Nord_I, vNord_I, H_I, vH_I, Est_E, vEst_E, Nord_E, vNord_E, H_E, vH_E)
        line = f.readline()
    f.close()
    return velo


def plotvel(vel_file):
    from mpl_toolkits.basemap import Basemap
    import pyproj

    # BASEMAP OPTIONS
    # llcrnrlat,llcrnrlon,urcrnrlat,urcrnrlon
    # are the lat/lon values of the lower left and upper right corners
    # of the map.
    # resolution = 'i' means use intermediate resolution coastlines.
    # lon_0, lat_0 are the central longitude and latitude of the projection.

    velo = velread(vel_file)

    llh = pyproj.Proj('+proj=latlong +datum=WGS84 +no_defs')
    utm = pyproj.Proj('+proj=utm +zone=32 +datum=WGS84 +units=m +no_defs')

    staz = []
    Est_I = []
    vEst_I = []
    Nord_I = []
    vNord_I = []
    H_I = []
    vH_I = []
    Est_E = []
    vEst_E = []
    Nord_E = []
    vNord_E = []
    H_E = []
    vH_E = []

    buf = 1000

    lbl_I = 'ITRF2020'
    lbl_E = 'ETRF2000'

    for c in velo:
        staz.append(c)

        est_I = float(velo.get(c)[0])
        nord_I = float(velo.get(c)[2])
        lon_I, lat_I = pyproj.transform(utm, llh, est_I, nord_I)
        Est_I.append(lon_I)
        Nord_I.append(lat_I)
        H_I.append(float(velo.get(c)[4]))
        vEst_I.append(float(velo.get(c)[1]))
        vNord_I.append(float(velo.get(c)[3]))
        vH_I.append(float(velo.get(c)[5]))

        est_E = float(velo.get(c)[6])
        nord_E = float(velo.get(c)[8])
        lon_E, lat_E = pyproj.transform(utm, llh, est_E, nord_E)
        Est_E.append(lon_E)
        Nord_E.append(lat_E)
        H_E.append(float(velo.get(c)[10]))
        vEst_E.append(float(velo.get(c)[7]))
        vNord_E.append(float(velo.get(c)[9]))
        vH_E.append(float(velo.get(c)[11]))

    # -- Grafico velocita' 2D [ITRF] --
    mI = Basemap(llcrnrlon=6.5, llcrnrlat=44, urcrnrlon=11.5, urcrnrlat=47,
                 resolution='i', projection='merc', lon_0=0.0, lat_0=0.0)
    x, y = mI(Est_I, Nord_I)
    QI = mI.quiver(x, y, vEst_I, vNord_I, color='navy', pivot='tail')
    # QI = mI.quiver(x, y, 0, vH_I, color='firebrick', pivot='tail')
    plt.title('Velocità - CRS: ' + lbl_I)
    plt.quiverkey(QI, 0.9, 0.03, 4, r'$4 \frac{cm}{yr}$')

    for n in range(len(staz)):
        plt.text(x[n] + 3 * buf, y[n] - buf, staz[n], verticalalignment='top', size='small')

    mI.drawcoastlines()
    mI.drawcountries()
    mI.fillcontinents(color='coral', lake_color='aqua', zorder=-10)
    mI.drawmapboundary(fill_color='aqua')

    plt.savefig(os.getcwd() + graPath + 'VEL_2D_' + lbl_I + '.PNG', dpi=300)
    plt.close()

    # -- Grafico velocita' 2D [ETRF] --
    mE = Basemap(llcrnrlon=6.5, llcrnrlat=44, urcrnrlon=11.5, urcrnrlat=47,
                 resolution='i', projection='merc', lon_0=0.0, lat_0=0.0)
    x, y = mE(Est_E, Nord_E)
    QE = mE.quiver(x, y, vEst_E, vNord_E, color='navy', pivot='tail')
    # QE = mE.quiver(x, y, 0, vH_E, color='firebrick', pivot='tail')
    plt.title('Velocità - CRS: ' + lbl_E)

    plt.quiverkey(QE, 0.9, 0.03, 0.4, r'$2 \frac{mm}{yr}$')
    for n in range(len(staz)):
        plt.text(x[n] + 3 * buf, y[n] - buf, staz[n], verticalalignment='top', size='small')

    mE.drawcoastlines()
    mE.drawcountries()
    mE.fillcontinents(color='coral', lake_color='aqua', zorder=-10)
    mE.drawmapboundary(fill_color='aqua')

    plt.savefig(os.getcwd() + graPath + 'VEL_2D_' + lbl_E + '.PNG', dpi=300)
    plt.close()


if '__main__' == __name__:
    main()
