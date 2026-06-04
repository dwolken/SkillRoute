namespace SkillRoute_BlazorApp.Services;

public class LearningPathLinkedList
{
    private LearningPathNode? head;

    public int Count { get; private set; }

    public void AddLast(LearningPathNode node)
    {
        if (head is null)
        {
            head = node;
        }
        else
        {
            var current = head;
            while (current.NextNode is not null)
            {
                current = current.NextNode;
            }
            current.NextNode = node;
        }
        Count++;
    }

    public List<LearningPathNode> ToList()
    {
        var result = new List<LearningPathNode>();
        var current = head;
        while (current is not null)
        {
            result.Add(current);
            current = current.NextNode;
        }
        return result;
    }
}