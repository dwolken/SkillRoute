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

        var csharpBasics = CreateBlock(
            "Grundlagen C#",
            "Grundlagen der Sprache C#.",
            now);
        var objectOrientation = CreateBlock(
            "Objektorientierung",
            "Klassen, Objekte und Beziehungen verstehen.",
            now);
        var razorComponents = CreateBlock(
            "Razor Komponenten",
            "Komponenten mit Razor aufbauen.",
            now);
        var blazorIntro = CreateBlock(
            "Blazor Einstieg",
            "Erste Schritte mit Blazor.",
            now);

        blazorIntro.Parts.Add(new BlockPart { ChildBlock = csharpBasics });
        blazorIntro.Parts.Add(new BlockPart { ChildBlock = objectOrientation });
        blazorIntro.Parts.Add(new BlockPart { ChildBlock = razorComponents });

        dbContext.LearningBlocks.AddRange(
            csharpBasics,
            objectOrientation,
            razorComponents,
            blazorIntro);

        await dbContext.SaveChangesAsync();
    }

    private static LearningBlock CreateBlock(string title, string description, DateTime createdAt)
    {
        return new LearningBlock
        {
            Title = title,
            Description = description,
            CreatedAt = createdAt,
            UpdatedAt = createdAt
        };
    }
}
