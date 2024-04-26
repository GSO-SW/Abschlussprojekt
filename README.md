Das ist mein UML für mein Abschlussprojekt!

![Unbenanntes Diagramm (1)](https://github.com/GSO-SW/Abschlussprojekt/assets/112069525/9d99e839-86ca-4c2e-9a77-2c46f7874f59)


Akinci bester Lehrer :)

Wenn sie keine 1 geben, dann schicken wir sie Remmertz zu ihnen!!!

Remmertz wird dann sehr böse sein!


![GetImage (1)](https://github.com/GSO-SW/Abschlussprojekt/assets/112069525/845f5687-e7c3-4b40-83d5-55be3ab39e79)



	
Zeichnen Sie das Blockschaltbild des zu untersuchenden Mainboards sorgfältig auf Papier. 

Schreiben Sie alle relevanten internen und externen (I/O-Panel) Schnittstellen getrennt voneinander auf. Dies sind sämtliche auf PCIe basierten Schnittstellen als auch alle USB- SATA- und Monitorschnittstellen. 

 


 

Zeichnen Sie das Blockschaltbild des abgebildeten Mainboards bestehend aus CPU, RAM, Chipsatz, Grafikkartenslots, zusätzliche PCIe-Lanes, USB-, SATA-Anschlüsse und Netzwerkanschlüsse. Die Zeichnungen dürfen ohne Lineal gezeichnet werden, müssen aber mit größtmöglicher Sorgfalt angefertigt werden.  
 
Arbeitshinweise: Bitte beschriften Sie die Anschlüsse der internen Schnittstellen auf dem Blockschaltbild mit den entsprechenden Anschlussbezeichnungen (Buchstaben oder Zahlen wie _12 oder -B), die Sie vom Mainboard ablesen können. Externe Schnittstellen, die über das Backpanel von Außen erreicht werden können, werden im Blockschaltdiagramm einfach mit Extern beschriftet, falls die Infos nichts anderes vorgeben.  

 


Folgende Informationen konnten dem Handbuch entnommen werden: 

Auf dem Board ist Platz für 2 Grafikkarten, die über 16 Lanes gespeist werden.  

Auf diesem Hightech-Mainboard werden alle PCIe-Lanes, sowohl für die Grafikkarten als auch von der Southbridge abgehend, in der Version 3.0 ausgeführt. 

Auf dem Mainboard ist ein ASM1184e-Controller integriert. Dieser wird mit einer Lane in der 

Version 3.0 gespeist und verteilt diese auf alle vorhandenen (bis zu max. 4) PCIe x1 Schnittstellen in der Version 2.0. Die PCIe x1 Schnittstellen werden demnach nur in Version 2 ausgeführt. 

Auf dem Mainboard ist ein Alpine Ridge-Controller integriert. Dieser wird mit vier Lanes in der Version 3.0 gespeist und verteilt diese hier auf 2 USB 3.1 Gen.2 Anschlüsse am Backpanel. Der erste USB 3.1 Gen.2 Anschluss wird als Typ C ausgeführt und der zweite USB 3.1 Gen.2 Anschluss wird als Typ A ausgeführt und befindet sich unmittelbar neben dem Ersten. 

Die auf dem Board vorhandenen M.2-SchnittsteIlen werden jeweils nativ mit 4 Lanes gespeist. 

Jede SATA-Express Schnittstelle wird nativ durch 2 Lanes gespeist. Alternativ können jeweils die entsprechenden SATA3-SchnittsteIIen genutzt werden. 

1 x Renesas Hub: Für die 3 USB3.0-Anschlüsse auf dem Backpanel. Dieser Hub verteilt eine Lane auf bis zu vier USB3.0-Anschlüsse. 

Jeder netzwerkfähige Anschluss (Gigabit-Lan und Wlan-AC) wird mit einer kompletten Lane gespeist. 


 

Wie fang ich an und welche Reihenfolge ist sinnvoll? 

Welche Aufgaben gucke ich mir zur Wiederholung an?  

1 

Ich schreibe eine Liste aller Internen Schnittstellen. Diese Liste erhält die Überschrift INTERN 
- Zunächst werden alle PCIe-basierten Schnittstellen auf dem MB identifiziert und notiert 

- Anschließend wird das MB nach USB-basierten Schnittstellen abgesucht und notiert 
- Zum Schluss werden die SATA-Schnittstellen (Evtl. SATA-Express) der Liste hinzugefügt 
 

Anschließend schreibe ich eine Liste aller EXTERNEN Schnittstellen.  
- Wenn ein Typ-C Anschluss so alleine extern auftaucht, dann findet ihr in den Informationen  
   einen Hinweis dazu, um welche USB-Version es sich hierbei handelt. 
 

Mit Hilfe von Notizbuchseite "MA-🎬📃-Anleitung für Teil 1 (BD)" wird die Schreibweise und die Vorgehensweise geübt.  

Wichtig ist, sich wirklich an die vereinbarte Schreibweise zu halten. Die Namen der internen Schnittstellen bestehen aus der Anzahl der Schnittstellen, dem Namen der Schnittstelle inkl. der Version und der Nummerierung, die man  auf dem Mainboard ablesen kann.  

2 

Ich zeichne das Blockschaltdiagramm 
- Wir beginnen mit der Architektur. Aktuellere Boards werden in Architektur 3 ausgeführt.  
- Zur Architektur gehört auch die Grafikkarte.  
- Anschließend werden "Hinweise" bzw. "Zeicheninformationen" abgearbeiet.  
- Der Rest kann nativ an die Southbridge gezeichnet werden. 

Auch das Zeichnen wird mit obiger Notizbuchseite geübt:  "MA-🎬📃-Anleitung für Teil 1 (BD)" 
 

 



 

Interne Liste 

Externe Liste 

PCIe x1  

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

Bitte fügen Sie HIER ihr gezeichnetes Blockschaltdiagramm ein: 

 

 

 


