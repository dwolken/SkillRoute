using SkillRoute_BlazorApp.Services;

namespace SkillRoute_UnitTests;

public class LearningPathLinkedListTests
{
    [Fact]
    public void AddLast_SingleNode_CountIsOne()
    {
        var list = new LearningPathLinkedList();
        var node = new LearningPathNode { BlockId = 1, Title = "Variablen", Status = "Offen" };

        list.AddLast(node);

        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void AddLast_MultipleNodes_CountIsCorrect()
    {
        var list = new LearningPathLinkedList();

        list.AddLast(new LearningPathNode { BlockId = 1, Title = "Variablen", Status = "Offen" });
        list.AddLast(new LearningPathNode { BlockId = 2, Title = "Bedingungen", Status = "Offen" });
        list.AddLast(new LearningPathNode { BlockId = 3, Title = "Schleifen", Status = "Verstanden" });

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void ToList_ReturnsNodesInCorrectOrder()
    {
        var list = new LearningPathLinkedList();

        list.AddLast(new LearningPathNode { BlockId = 1, Title = "Variablen", Status = "Offen" });
        list.AddLast(new LearningPathNode { BlockId = 2, Title = "Bedingungen", Status = "Offen" });
        list.AddLast(new LearningPathNode { BlockId = 3, Title = "Schleifen", Status = "Verstanden" });

        var result = list.ToList();

        Assert.Equal("Variablen", result[0].Title);
        Assert.Equal("Bedingungen", result[1].Title);
        Assert.Equal("Schleifen", result[2].Title);
    }

    [Fact]
    public void ToList_EmptyList_ReturnsEmptyList()
    {
        var list = new LearningPathLinkedList();

        var result = list.ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void Count_EmptyList_IsZero()
    {
        var list = new LearningPathLinkedList();

        Assert.Equal(0, list.Count);
    }
}