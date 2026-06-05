using Microsoft.EntityFrameworkCore;
using SkillRoute_BlazorApp.Model;

namespace SkillRoute_UnitTests;

public class SkillRouteDbContextTests : DatabaseTest
{
    [Fact]
    public async Task AddLearningBlock_SavesBlock()
    {
        var block = new LearningBlock { Title = "Variablen", Description = "Test", Status = BlockStatus.Open };
        DbContext.LearningBlocks.Add(block);
        await DbContext.SaveChangesAsync();

        var loaded = await DbContext.LearningBlocks.FindAsync(block.Id);

        Assert.NotNull(loaded);
        Assert.Equal("Variablen", loaded.Title);
    }

    [Fact]
    public async Task AddBlockPart_SavesParentChildConnection()
    {
        var parent = new LearningBlock { Title = "Blazor Einstieg" };
        var child = new LearningBlock { Title = "Grundlagen C#" };
        DbContext.LearningBlocks.AddRange(parent, child);
        await DbContext.SaveChangesAsync();

        var part = new BlockPart { ParentBlockId = parent.Id, ChildBlockId = child.Id };
        DbContext.BlockParts.Add(part);
        await DbContext.SaveChangesAsync();

        var loaded = await DbContext.BlockParts.FindAsync(part.Id);

        Assert.NotNull(loaded);
        Assert.Equal(parent.Id, loaded.ParentBlockId);
        Assert.Equal(child.Id, loaded.ChildBlockId);
    }

    [Fact]
    public async Task LoadBlockWithParts_ReturnsChildBlock()
    {
        var parent = new LearningBlock { Title = "Blazor Einstieg" };
        var child = new LearningBlock { Title = "Grundlagen C#" };
        DbContext.LearningBlocks.AddRange(parent, child);
        await DbContext.SaveChangesAsync();

        DbContext.BlockParts.Add(new BlockPart { ParentBlockId = parent.Id, ChildBlockId = child.Id });
        await DbContext.SaveChangesAsync();

        var loaded = await DbContext.LearningBlocks
            .Include(b => b.Parts)
            .ThenInclude(p => p.ChildBlock)
            .FirstAsync(b => b.Id == parent.Id);

        Assert.Single(loaded.Parts);
        Assert.Equal("Grundlagen C#", loaded.Parts[0].ChildBlock.Title);
    }

    [Fact]
    public async Task LoadChildWithUsedIn_ReturnsParentBlock()
    {
        var parent = new LearningBlock { Title = "Blazor Einstieg" };
        var child = new LearningBlock { Title = "Grundlagen C#" };
        DbContext.LearningBlocks.AddRange(parent, child);
        await DbContext.SaveChangesAsync();

        DbContext.BlockParts.Add(new BlockPart { ParentBlockId = parent.Id, ChildBlockId = child.Id });
        await DbContext.SaveChangesAsync();

        var loaded = await DbContext.LearningBlocks
            .Include(b => b.UsedIn)
            .ThenInclude(p => p.ParentBlock)
            .FirstAsync(b => b.Id == child.Id);

        Assert.Single(loaded.UsedIn);
        Assert.Equal("Blazor Einstieg", loaded.UsedIn[0].ParentBlock.Title);
    }

    [Fact]
    public async Task DeleteChildBlock_RemovesConnectionButKeepsParentBlock()
    {
        var parent = new LearningBlock { Title = "Blazor Einstieg" };
        var child = new LearningBlock { Title = "Grundlagen C#" };
        DbContext.LearningBlocks.AddRange(parent, child);
        await DbContext.SaveChangesAsync();

        DbContext.BlockParts.Add(new BlockPart { ParentBlockId = parent.Id, ChildBlockId = child.Id });
        await DbContext.SaveChangesAsync();

        DbContext.LearningBlocks.Remove(child);
        await DbContext.SaveChangesAsync();

        var parentStillExists = await DbContext.LearningBlocks.FindAsync(parent.Id);
        var partsCount = await DbContext.BlockParts.CountAsync();

        Assert.NotNull(parentStillExists);
        Assert.Equal(0, partsCount);
    }
}