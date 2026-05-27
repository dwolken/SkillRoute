using Microsoft.EntityFrameworkCore;
using SkillRoute_BlazorApp.Model;

namespace SkillRoute_BlazorApp.Infrastructure;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(SkillRouteDbContext dbContext)
    {
        if (await dbContext.LearningBlocks.AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;

        var variables = CreateBlock(
            "Variablen",
            "Werte speichern und mit einfachen Datentypen arbeiten.",
            BlockStatus.Understood,
            now);
        var conditions = CreateBlock(
            "Bedingungen",
            "Mit if und else Entscheidungen im Programm treffen.",
            BlockStatus.Open,
            now);
        var loops = CreateBlock(
            "Schleifen",
            "Wiederholungen mit for und while umsetzen.",
            BlockStatus.Open,
            now);
        var csharpBasics = CreateBlock(
            "Grundlagen C#",
            "Erste wichtige Sprachkonzepte in C# verstehen.",
            BlockStatus.InProgress,
            now);
        var classes = CreateBlock(
            "Klassen",
            "Eigene Klassen als Bauplan für Objekte schreiben.",
            BlockStatus.Understood,
            now);
        var objects = CreateBlock(
            "Objekte",
            "Objekte aus Klassen erstellen und verwenden.",
            BlockStatus.Open,
            now);
        var properties = CreateBlock(
            "Eigenschaften",
            "Daten in Klassen über Properties lesbar machen.",
            BlockStatus.Open,
            now);
        var objectOrientation = CreateBlock(
            "Objektorientierung",
            "Klassen, Objekte und Beziehungen in C# verstehen.",
            BlockStatus.InProgress,
            now);
        var htmlBasics = CreateBlock(
            "HTML Grundlagen",
            "Einfache HTML-Strukturen für Webseiten aufbauen.",
            BlockStatus.Understood,
            now);
        var razorComponents = CreateBlock(
            "Razor Komponenten",
            "Blazor-Komponenten mit Razor erstellen und verwenden.",
            BlockStatus.Open,
            now);
        var blazorIntro = CreateBlock(
            "Blazor Einstieg",
            "Eine erste Blazor-Anwendung verstehen und erweitern.",
            BlockStatus.InProgress,
            now);
        var databaseBasics = CreateBlock(
            "Datenbank Grundlagen",
            "Tabellen, Datensätze und einfache Beziehungen verstehen.",
            BlockStatus.Understood,
            now);
        var dbContextBlock = CreateBlock(
            "DbContext",
            "Mit dem DbContext auf Daten zugreifen und Änderungen speichern.",
            BlockStatus.Open,
            now);
        var efCoreBasics = CreateBlock(
            "EF Core Grundlagen",
            "Daten mit Entity Framework Core in einer Anwendung verwenden.",
            BlockStatus.InProgress,
            now);

        csharpBasics.Parts.Add(new BlockPart { ChildBlock = variables });
        csharpBasics.Parts.Add(new BlockPart { ChildBlock = conditions });
        csharpBasics.Parts.Add(new BlockPart { ChildBlock = loops });

        objectOrientation.Parts.Add(new BlockPart { ChildBlock = classes });
        objectOrientation.Parts.Add(new BlockPart { ChildBlock = objects });
        objectOrientation.Parts.Add(new BlockPart { ChildBlock = properties });

        dbContext.LearningBlocks.AddRange(
            variables,
            conditions,
            loops,
            csharpBasics,
            classes,
            objects,
            properties,
            objectOrientation,
            htmlBasics,
            razorComponents,
            blazorIntro,
            databaseBasics,
            dbContextBlock,
            efCoreBasics);

        blazorIntro.Parts.Add(new BlockPart { ChildBlock = csharpBasics });
        blazorIntro.Parts.Add(new BlockPart { ChildBlock = htmlBasics });
        blazorIntro.Parts.Add(new BlockPart { ChildBlock = razorComponents });
        blazorIntro.Parts.Add(new BlockPart { ChildBlock = objectOrientation });

        efCoreBasics.Parts.Add(new BlockPart { ChildBlock = classes });
        efCoreBasics.Parts.Add(new BlockPart { ChildBlock = databaseBasics });
        efCoreBasics.Parts.Add(new BlockPart { ChildBlock = dbContextBlock });

        await dbContext.SaveChangesAsync();
    }

    private static LearningBlock CreateBlock(
        string title,
        string description,
        BlockStatus status,
        DateTime createdAt)
    {
        return new LearningBlock
        {
            Title = title,
            Description = description,
            Status = status,
            CreatedAt = createdAt,
            UpdatedAt = createdAt
        };
    }
}
