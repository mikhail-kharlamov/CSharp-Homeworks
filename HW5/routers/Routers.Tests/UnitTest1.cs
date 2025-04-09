namespace Routers.Tests;

using UndirectedGraph;
using Algorithms;

public class Tests
{
    [Test]
    public void UndirectedGraphSetAndGetAdjacencyListTest()
    {
        var graph = new UndirectedGraph();
        Dictionary<int, List<(int, int)>> adjacencyList = new();
        adjacencyList.Add(1, new List<(int, int)>() { (2, 10), (3, 5) });
        adjacencyList.Add(2, new List<(int, int)>() { (1, 10), (3, 1) });
        adjacencyList.Add(3, new List<(int, int)>() { (1, 5), (2, 1) });
        
        graph.SetAdjacencyList(adjacencyList);
        Assert.That(graph.GetAdjacencyList(), Is.EqualTo(adjacencyList));
    }
    
    [Test]
    public void UndirectedGraphSetAndGetVerticesTest()
    {
        var graph = new UndirectedGraph();
        List<int> originalVertices = new() { 1, 2, 3, 4, 5 };
        foreach (var vertex in originalVertices)
        {
            graph.AddVertex(vertex);
        }
        
        var graphVertices = graph.GetVertices();
        graphVertices.Sort();
        Assert.That(graphVertices, Is.EquivalentTo(originalVertices));
    }
    
    [Test]
    public void UndirectedGraphSetEdgesAndGetAdjacencyListTest()
    {
        var graph = new UndirectedGraph();
        List<(int, int, int)> edges = new() { (1, 2, 10), (1, 3, 5), (2, 3, 1)};
        foreach (var edge in edges)
        {
            graph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
        }
        
        Dictionary<int, List<(int, int)>> originalAdjacencyList = new();
        originalAdjacencyList.Add(1, new List<(int, int)>() { (2, 10), (3, 5) });
        originalAdjacencyList.Add(2, new List<(int, int)>() { (1, 10), (3, 1) });
        originalAdjacencyList.Add(3, new List<(int, int)>() { (1, 5), (2, 1) });
        
        var graphAdjacencyList = graph.GetAdjacencyList();
        Assert.That(originalAdjacencyList, Is.EquivalentTo(graphAdjacencyList));
    }
    
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