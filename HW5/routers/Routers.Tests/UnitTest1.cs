namespace Routers.Tests;

using UndirectedGraphExtractor;
using UndirectedGraph;
using Algorithms;

public class Tests
{
    /*[Test]
    public void UndirectedGraphExtractorTest()
    {
        List<string> file = new();
        file.Add("1: 2 (10), 3 (5)");
        file.Add("1: 2 (10), 3 (5), 4 (11)");
        var graph = UndirectedGraphExtractor.Extract(file);
        Assert.Pass();
    }
*/
    [Test]
    public void AlgorithmOfPrimBaseDataTest()
    {
        var graph = new UndirectedGraph();
        graph.AddEdge(0, 1, 7); // A B
        graph.AddEdge(1, 2, 8); // B D
        graph.AddEdge(0, 3, 5); // A D
        graph.AddEdge(3, 1, 9); // D B
        graph.AddEdge(3, 4, 15); // D E
        graph.AddEdge(2, 4, 5); // C E
        graph.AddEdge(1, 4, 7); // B E
        graph.AddEdge(3, 5, 6); // D F
        graph.AddEdge(5, 4, 8); // F E
        graph.AddEdge(5, 6, 11); // F G
        graph.AddEdge(4, 6, 9); // E G
        
        var tree = AlgorithmOfPrim.GetMinimumSpanningTree(graph);

        var verticesOfMinimumSpanningTree = tree.GetVertices();
        verticesOfMinimumSpanningTree.Sort();
        Assert.That(verticesOfMinimumSpanningTree, Is.EquivalentTo(new List<int> { 0, 1, 2, 3, 4, 5, 6 }));
    }
}