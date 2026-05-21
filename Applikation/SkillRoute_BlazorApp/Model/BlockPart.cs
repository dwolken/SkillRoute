namespace SkillRoute_BlazorApp.Model;

public class BlockPart
{
    public int Id { get; set; }

    public int ParentBlockId { get; set; }

    public LearningBlock ParentBlock { get; set; } = null!;

    public int ChildBlockId { get; set; }

    public LearningBlock ChildBlock { get; set; } = null!;
}
