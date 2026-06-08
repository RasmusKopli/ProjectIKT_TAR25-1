# ProjectIKT_TAR25-1

Ülevaade
ProjektIKT_TAR25-1 on veebirakendus, mis on loodud platvormiga ASP.NET Core ja programmeerimiskeelega C#. Rakendus on ühendatud kohaliku SQL Serveri andmebaasiga ning demonstreerib, kuidas hallata töökohti, takistades samal ajal mitmel töötajal sama ametikohta täitmast.
Põhifunktsionaalsus tagab, et kui töökoht on juba töötajale määratud, märgitakse see automaatselt kättesaamatuks ning seda ei saa teisele töötajale määrata.

Kasutatud tehnoloogiad
C#

ASP.NET Core

Entity Framework Core

SQL Server Express (kohalik andmebaas)

Funktsioonid
Töötajate loomine ja haldamine.

Töökohtade loomine ja haldamine.

Töökohtade automaatne märkimine kättesaamatuks, kui need on määratud.

Mitme töötaja sama töökoha hõivamise takistamine.

Vabadele töökohtadele kandideerimine rakenduse liidese kaudu.

Töötajate andmete ja määratud töökohtade uuendamine.

Andmebaasi seoste ja valideerimisloogika demonstreerimine.

Andmebaasi seadistamine
Enne rakenduse käivitamist seadistage andmebaasi ühendussõne failis appsettings.json.
Ühendussõne näide:

JSON:

"ConnectionStrings": {
    "WorkplaceContext": "Server=.\\SQLEXPRESS;Database=WorkplaceDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

Nõuded:

SQL Server Express on paigaldatud.

SQLEXPRESS-i instants töötab.

Andmebaas on loodud või migratsioonid on rakendatud.

Paigaldamine
Kloonige hoidla (repository).

Avage lahendus (solution) Visual Studios.

Seadistage ühendussõne failis appsettings.json.

Veenduge, et SQL Server Express töötab.

Rakendage vajalikud Entity Frameworki migratsioonid.

Ehitage lahendus (Build solution).

Rakenduse käivitamine
Käivitage projekt Visual Studios:

Ctrl + F5  või F5 (debuggimiseks)

Rakendus käivitub kohalikult teie veebibrauseris.

Testimine
Hetkel ei ole rakenduses automatiseeritud teste.
Funktsionaalsuse kontrollimiseks:

Kasutage Visual Studio silumispunkte (breakpoints).

Jälgige koodi täitmist siluja (debugger) kaudu.

Kontrollige rakenduse käitumist töökohtade määramisel ja eemaldamisel.

Teadaolevad piirangud
Töökoha kustutamisel võib töötajale siiski jääda viide kustutatud ametikohale.

Andmebaasi järjepidevuse (consistency) tagamiseks võib vaja minna täiendavat valideerimis- ja puhastusloogikat.

Autor
Projekti autor: ainult mina

Projekti eesmärk
See projekt demonstreerib, kuidas hallata töötajate ja töökohtade vahelisi seoseid andmebaasipõhises veebirakenduses, jõustades samal ajal töökohtade saadavuse reegleid ja takistades topeltmääramisi.
