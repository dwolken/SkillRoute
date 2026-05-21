namespace SkillRoute_BlazorApp.Model;

public class LearningBlock
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public BlockStatus Status { get; set; } = BlockStatus.Open;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<BlockNote> Notes { get; set; } = [];

    public List<BlockPart> Parts { get; set; } = [];

    public List<BlockPart> UsedIn { get; set; } = [];
}
