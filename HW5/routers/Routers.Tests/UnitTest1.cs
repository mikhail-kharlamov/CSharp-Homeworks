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
    public void UndirectedGraphGetNeighboursTest()
    {
        var graph = new UndirectedGraph();
        List<(int, int, int)> edges = new() { (1, 2, 10), (1, 4, 13), (1, 5, 16), (2, 4, 12), (3, 2, 11), 
            (3, 5, 15), (1, 5, 16), (3, 4, 14)};
        
        foreach (var edge in edges)
        {
            graph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
        }
        
        Assert.That(graph.GetNeighbors(1), Is.EquivalentTo(new List<(int, int)> { (2, 10), 
            (4, 13), (5, 16) }));
        Assert.That(graph.GetNeighbors(2), Is.EquivalentTo(new List<(int, int)> { (1, 10), 
            (4, 12), (3, 11) }));
        Assert.That(graph.GetNeighbors(3), Is.EquivalentTo(new List<(int, int)> { (2, 11), 
            (4, 14), (5, 15) }));
        Assert.That(graph.GetNeighbors(4), Is.EquivalentTo(new List<(int, int)> { (2, 12), 
            (1, 13), (3, 14) }));
        Assert.That(graph.GetNeighbors(5), Is.EquivalentTo(new List<(int, int)> { (1, 16), 
            (3, 15)}));
    }
    
    [Test]
    public void AlgorithmOfPrimBaseDataTest()
    {
        var graph = new UndirectedGraph();
        graph.AddEdge(0, 1, 7);
        graph.AddEdge(1, 2, 8);
        graph.AddEdge(0, 3, 5);
        graph.AddEdge(3, 1, 9);
        graph.AddEdge(3, 4, 15);
        graph.AddEdge(2, 4, 5);
        graph.AddEdge(1, 4, 7);
        graph.AddEdge(3, 5, 6);
        graph.AddEdge(5, 4, 8);
        graph.AddEdge(5, 6, 11);
        graph.AddEdge(4, 6, 9);

        var originalTree = new UndirectedGraph();
        originalTree.AddEdge(5, 3, 6);
        originalTree.AddEdge(3, 0, 5);
        originalTree.AddEdge(0, 1, 7);
        originalTree.AddEdge(1, 4, 7);
        originalTree.AddEdge(4, 2, 5);
        originalTree.AddEdge(4, 6, 9);
        
        var treeAfterAlgorithm = AlgorithmOfPrim.GetMinimumSpanningTree(graph);

        var verticesOfMinimumSpanningTree = treeAfterAlgorithm.GetVertices();
        verticesOfMinimumSpanningTree.Sort();
        Assert.That(verticesOfMinimumSpanningTree, Is.EquivalentTo(new List<int> { 0, 1, 2, 3, 4, 5, 6 }));
        Assert.That(treeAfterAlgorithm.GetEdges(), Is.EquivalentTo(originalTree.GetEdges()));
    }
    
    [Test]
    public void AlgorithmOfPrimReverseBaseDataTest()
    {
        var graph = new UndirectedGraph();
        
        Dictionary<int, List<(int, int)>> adjacencyList = new();
        adjacencyList.Add(1, new List<(int, int)>() { (2, 10), (3, 5) });
        adjacencyList.Add(2, new List<(int, int)>() { (1, 10), (3, 1) });
        adjacencyList.Add(3, new List<(int, int)>() { (1, 5), (2, 1) });
        graph.SetAdjacencyList(adjacencyList);

        var treeAfterAlgorithm = AlgorithmOfPrim.GetMinimumSpanningTree(graph, true);

        var originalTree = new UndirectedGraph();
        List<(int, int, int)> edges = new() { (1, 2, 10), (1, 3, 5) };
        foreach (var edge in edges)
        {
            originalTree.AddEdge(edge.Item1, edge.Item2, edge.Item3);
        }
        
        Assert.That(treeAfterAlgorithm.GetAdjacencyList(), Is.EquivalentTo(originalTree.GetAdjacencyList()));
    }
}