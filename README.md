# SkillRoute

SkillRoute ist eine Blazor-Webanwendung zur Verwaltung von Lernblöcken.

Ein Lernblock kann alleine stehen oder aus anderen Lernblöcken bestehen. Dadurch können größere Themen in kleinere Bestandteile zerlegt werden. Die Anwendung zeigt außerdem, wie Lernblöcke miteinander verbunden sind und welche Reihenfolge beim Lernen sinnvoll sein kann.

## Funktionen

- Lernblöcke erstellen, bearbeiten und löschen
- Status eines Lernblocks verwalten
- Bestandteile zu einem Lernblock hinzufügen
- Anzeigen, in welchen anderen Lernblöcken ein Baustein verwendet wird
- Übersicht über die Beziehungen zwischen Lernblöcken
- Lernpfad auf Basis der vorhandenen Bestandteile
- Beispiel-Daten über einen Seeder
- Unit Tests für die eigene LinkedList-Struktur und Datenbankbeziehungen

## Verwendete Technologien

- C#
- Blazor
- Entity Framework Core
- SQLite
- xUnit

## Projektstruktur

```text
Applikation/
├─ SkillRoute_BlazorApp/
│  ├─ Components/
│  ├─ Infrastructure/
│  ├─ Model/
│  └─ Services/
├─ SkillRoute_UnitTests/
└─ SkillRoute.slnx
```

## Starten

In den Ordner `Applikation` wechseln:

```powershell
cd Applikation
```

Projekt starten:

```powershell
dotnet run --project .\SkillRoute_BlazorApp\SkillRoute_BlazorApp.csproj
```

Danach die angezeigte lokale Adresse im Browser öffnen.

## Datenbank neu erstellen

Die lokale SQLite-Datenbank wird beim Start automatisch erstellt, wenn sie noch nicht existiert.

Zum Neu-Erstellen kann die lokale Datenbankdatei gelöscht werden:

```powershell
Remove-Item .\SkillRoute_BlazorApp\skillroute.db -ErrorAction SilentlyContinue
Remove-Item .\SkillRoute_BlazorApp\skillroute.db-wal -ErrorAction SilentlyContinue
Remove-Item .\SkillRoute_BlazorApp\skillroute.db-shm -ErrorAction SilentlyContinue
```

Beim nächsten Start wird die Datenbank wieder mit Beispiel-Daten erstellt.

## Tests ausführen

In den Ordner `Applikation` wechseln:

```powershell
cd Applikation
```

Tests ausführen:

```powershell
dotnet test .\SkillRoute.slnx
```
