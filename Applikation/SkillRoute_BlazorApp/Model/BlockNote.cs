namespace SkillRoute_BlazorApp.Model;

public class BlockNote
{
    public int Id { get; set; }

    public int LearningBlockId { get; set; }

    public LearningBlock LearningBlock { get; set; } = null!;

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
