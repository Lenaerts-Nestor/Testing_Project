# CarDecisionApp

## **Projectoverzicht**
CarDecisionApp is een consoletoepassing die:
1. Autogegevens ophaalt van een externe API (merken en modellen).
2. Snelle auto's filtert op basis van een minimaal aantal pk's (paardenkracht).
3. Belangrijke informatie en fouten logt naar een bestand.

Dit project volgt de Test-Driven Development (TDD) aanpak en bevat unit tests, integratietests en acceptatietests om de functionaliteit te controleren.

---

## **Structuur van de Applicatie**

### **1. Modules en Componenten**

#### **Beslissingsmodule**
- **Doel**: Logica implementeren om snelle auto's te filteren.
- **Klasse**: `CarDecisionModule`
- **Methodes**:
  - `GetHighPerformanceCars(List<CarModel> cars, int minHorsepower)`:
    - Filtert auto's met minstens het opgegeven aantal pk's.
    - Geeft een `ArgumentException` bij een negatieve pk-waarde.

#### **Informatieverstrekker**
- **Doel**: Autogegevens ophalen van externe APIs.
- **Klassen**:
  - `CarModelApi`: Haalt automodellen op.
  - `CarBrandApi`: Haalt automerken op.
- **Interfaces**:
  - `ICarModelApi`
  - `ICarBrandApi`
- **API-integratie**: Ondersteunt Bearer-token authenticatie.

#### **Actieklassen**
- **Doel**: Acties uitvoeren op basis van de uitkomsten van de beslissingsmodule.
- **Klasse**: `FileLogger`
  - Logt informatieve berichten, waarschuwingen en fouten naar een bestand.

### **2. Foutafhandeling**
- De applicatie bevat robuuste foutafhandeling:
  - Ongeldige invoer in de beslissingsmodule.
  - API-fouten (bijv. ongeldige tokens, netwerkfouten).

---

## **Testaanpak**

### **1. Unit Tests**
- **Methode**: Test-Driven Development (TDD).
- **Framework**: MSTest.
- **Tools**: Moq voor het mocken van dependencies.
- **Testcases**:
  - Controleer of de beslissingsmodule auto's correct filtert.
  - Controleer of de beslissingsmodule ongeldige invoer goed afhandelt.
  - Mock API-aanroepen om de logica voor het ophalen van gegevens te testen.

### **2. ZOMBIES Methode**
- **Zero**: Test gedrag met lege of null inputs.
- **One**: Test scenario's met één item.
- **Many**: Test meerdere datapunten.
- **Boundaries**: Controleer randgevallen (bijv. pk-drempelwaarden).
- **Interfaces**: Mock dependencies zoals `ILogger` en API-interfaces.
- **Exceptions**: Zorg ervoor dat uitzonderingen worden gegenereerd en goed afgehandeld.
- **Scenarios**: Test end-to-end workflows.

### **3. Integratietests**
- **Doel**: Controleer de interactie tussen componenten.
- **Tools**: Mockoon voor het simuleren van APIs.
- **Status**: Integratietests zijn in ontwikkeling.

### **4. Acceptatietests**
- **Framework**: `xunit.Gherkin.Quick`.
- **Status**: Gherkin-scenario's en stapdefinities zijn gepland.

---

## **Hoe de Applicatie Uitvoeren**
1. Clone de repository.
2. Open de oplossing in Visual Studio.
3. Stel het project `CarDecisionApp` in als opstartproject.
4. Voer de applicatie uit.
5. Logs worden geschreven naar `application.log` in de applicatiemap.

---
