# GardaNetGame

## Översikt

Detta projekt är en fullstack e-handelsplattform utvecklad som en gruppuppgift på en yrkeshögskola med ett halvårs erfarenhet om mjukvaruutveckling. Plattformen är byggd med .NET-ramverket och visar upp en mängd olika färdigheter, inklusive backend-utveckling, frontend-utveckling, databashantering och distribution. Målet med projektet var utöver att jobba agilt, tillämpa scrum och dela kunskaper inom teamet att skapa en fullt fungerande webshop där användare kan anmäla sig till event, bläddra bland produkter, lägga till dem i sin kundvagn och slutföra fiktiva köp.

## Funktioner

- **Användarautentisering**: Säker registrering och inloggning med ASP.NET Core Identity.
- **Eventkatalog**: Visa en lista över event med detaljerade beskrivningar och bilder samt eventhistorik.
- **Produktkatalog**: Visa en lista över produkter med detaljerade beskrivningar och bilder.
- **Administrationspanel**: Administrationsgränssnitt för att hantera event, produkter och kategorier.
- **Responsiv design**: Mobilvänlig design för att säkerställa en bra användarupplevelse på alla enheter.

## Tech Stack

### Frontend

- **Blazor**: För att bygga ett interaktivt webbgränssnitt med C#.
- **HTML & CSS**: För strukturering och styling av webbsidor.
- **Bootstrap**: För responsiv design och färdiga komponenter.

### Backend

- **ASP.NET Core**: Ramverket som applikationens delar är byggt på.
- **C#**: Programmeringsspråk som används för backend-utveckling.
- **FastEndpoints**: För att skapa ett effektivt modulärt REST-API kompatibelt med .NET.
- **MongoDB**: För NoSQL-databashantering.
- **ASP.NET Core Identity**: För användarautentisering och auktorisering.
- **SQL**: För säker lagring av användaruppgifter.

### Verktyg och Tjänster

- **Git**: Versionskontrollsystem för kodhantering.
- **Azure DevOps**: För källkodshantering, CI/CD-pipelines och samarbete inom teamet.
- **Azure**: För distribution och hosting av applikationen.
- **Visual Studio**: Huvudsaklig IDE som använts för utveckling.
- **MongoDB Compass**: För direktkontroll av databasens innehåll.
- **Postman**: För API-testning och utveckling.
- **Robot Framework**: Ett automatiseringsramverk för acceptans- och godkännande-testning.
- **Selenium Library**: Ett verktyg för att automatisera webbläsare, använt tillsammans med Robot Framework för att utföra tester.

## Roller och Ansvar

Projektet genomfördes i samarbete av tio studenter från fyra olika utbildningsprogram, där varje medlem använde sina unika kunskaper från respektive utbildning:

- **IT-Projektledare**: Agerade produktägare och scrum-master för att facilitera och effektivisera processer.
- **Mjukvarutestare**: Skrev och automatiserade flödestester för säkerställande av acceptanskrav och applikationsstabilitet.
- **.NET-Cloudutvecklare**: Utveckling med fokus på integration och distribution, satte upp CI/CD-pipelines och Azure-hosting.
- **.NET-Utvecklare**: Fullstack-utveckling med fokus på designmönster och struktur.

## Planerade förbättringar

(Förutsatt att vi haft tid för en tredje sprint. Vi hade bara tid i projektet för två sprintar.)

- **Kundvagn och orderhantering**: Reda ut problemen vi stötte på med ihopblandade entiteter och DTOer.
- **Användarrecensioner och betyg**: Tillåta användare att recensera och betygsätta produkter.
- **Sök och filtrering**: Implementera sökfunktion och filtreringsalternativ.
- **Prestandaoptimering**: Förbättra applikationens generella prestanda och skalbarhet.
