namespace SkillRoute_BlazorApp.Services;

public class LearningPathNode
{
    public int BlockId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public LearningPathNode? NextNode { get; set; }
}