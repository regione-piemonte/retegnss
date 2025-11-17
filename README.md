# Project Title
Rete Stazioni Permanenti GNSS

# Project Description
Il progetto permette di svolgere la compensazione geodetica di una rete di stazioni permanenti in modo automatico.
I risultati prodotti dal software GNSSCOMP sono le coordinate cartografiche, di elevata precisione, di una rete di stazioni GNSS definita dall'operatore ad una o più epoche di calcolo anch'esse definite a priori.
Il software produce inoltre i grafici delle serie storiche delle stazioni permanenti che mostrano il loro spostamento nel tempo in planimetria ed altimetria. Dalle serie storiche vengono infine ricavate e graficizzate le velocità di spostamento.
Il calcolo geodetico è eseguito nei sistemi di riferimento (SR) IGS14 o IGS20. Le coordinate ottenute dal calcolo vengono convertite nel SR nazionale ETRF2000 e nel SR internazionale ITRF2020, e proiettate nel sistema UTM-32. 

Il software è rivolto ad operatori specializzati che si occupano della gestione di una rete di stazioni permanenti.

Il software GNSSCOMP presenta un’interfaccia grafica che consente di inserire i parametri preliminari al calcolo di compensazione (come ad esempio, selezionare le epoche di calcolo e definire le stazioni GNSS coinvolte nel calcolo) prima di lanciare il processo di calcolo vero e proprio. È tuttavia possibile lanciare il software anche in modalità batch tramite linea di comando o task schedulato, poiché la definizione dei parametri viene trascritta all’interno di determinati file testuali di configurazione. Sono previste inoltre diverse personalizzazioni come ad esempio la possibilità di attivare la selezione automatica dell'epoca di calcolo, l'attivazione della notifica tramite email che informa l'operatore della conclusione della procedura di compensazione, ed altre. I risultati prodotti dal software, tra cui anche la reportistica, sono visualizzabili tramite interfaccia, ma vengono automaticamente salvati anche all'interno di specifiche directory da cui possono essere visionati direttamente. 

L'interfaccia è composta dalle pagine 'Opzioni' e 'Avanzate' in cui è necessario definire la parametrizzazione e personalizzazione della procedura di compensazione; dalle pagine 'Risultati' in cui è possibile visionare i risultati testuali e grafici nei diversi sistemi di riferimento; e in ultimo dalla pagina 'Calcola' nella quale vengono riportati i messaggi di log che qualificano la riuscita o meno delle varie operazioni che costituiscono l’intero processo, dalla preparazione dei dati di input, alla loro elaborazione, e infine alla produzione dei risultati finali.


# Getting Started
Il prodotto RETEGNSS è diviso nelle seguenti componenti:
[GNSSCOMP](https://github.com/regione-piemonte/retegnss/tree/master/gnsscomp) (Procedure a supporto della Compensazione della Rete GNSS)

Il manuale utente del software GNSSCOMP è disponibile al link:
(https://github.com/regione-piemonte/retegnss/tree/master/gnsscomp/doc/ManualeUtente.pdf)

# Prerequisites
I prerequisiti per la compilazione ed esecuzione del prodotto sono:
- Compilatore VB.NET (ad esempio Visual Studio)
- Framework .NET 6.0
- Python 3.8

Il programma è concepito per eseguire script in Perl del software Bernese GNSS 5.2

# Versioning
Per la gestione del codice sorgente viene utilizzata Git. Per la gestione del versioning si fa riferimento alla metodologia [Semantic Versioning](https://semver.org/) 

# Copyrights
(C) Copyright 2025 Regione Piemonte

# License
Questo software è distribuito con licenza EUPL-1.2
Consultare il file EUPL v1_2 IT-LICENSE.txt e EUPL v1_2 EN-LICENSE.txt  per i dettagli sulla licenza.