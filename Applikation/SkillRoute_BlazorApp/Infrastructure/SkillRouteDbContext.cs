using Microsoft.EntityFrameworkCore;
using SkillRoute_BlazorApp.Model;

namespace SkillRoute_BlazorApp.Infrastructure;

public class SkillRouteDbContext(DbContextOptions<SkillRouteDbContext> options) : DbContext(options)
{
    public DbSet<LearningBlock> LearningBlocks => Set<LearningBlock>();

    public DbSet<BlockPart> BlockParts => Set<BlockPart>();

    public DbSet<BlockNote> BlockNotes => Set<BlockNote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlockPart>()
            .HasOne(part => part.ParentBlock)
            .WithMany(block => block.Parts)
            .HasForeignKey(part => part.ParentBlockId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BlockPart>()
            .HasOne(part => part.ChildBlock)
            .WithMany(block => block.UsedIn)
            .HasForeignKey(part => part.ChildBlockId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
