namespace Algorithms;

using UndirectedGraph;

public class AlgorithmOfPrim
{
    public static UndirectedGraph GetMinimumSpanningTree(UndirectedGraph undirectedGraph)
    {
        var tree = new UndirectedGraph();
        var vertices = undirectedGraph.GetVertices();
        
        if (vertices.Count == 0) return tree;

        List<(int, int, int)> spanningTreeNearbyVertices = new();
        
        tree.AddVertex(vertices[0]);

        while (tree.GetVertices().Count < vertices.Count)
        {
            foreach (var vertex in tree.GetVertices())
            {
                foreach (var edge in undirectedGraph.GetNeighbors(vertex))
                {
                    if (!tree.GetVertices().Contains(edge.Item1))
                    {
                        spanningTreeNearbyVertices.Add((vertex, edge.Item1, edge.Item2));
                    }
                }
            }
            
            if (!spanningTreeNearbyVertices.Any()) break;
            
            var minimalEdge = spanningTreeNearbyVertices.OrderBy(x => x.Item3).First();
            tree.AddEdge(minimalEdge.Item1, minimalEdge.Item2, minimalEdge.Item3);
            
            spanningTreeNearbyVertices.Clear();
        }
        
        return tree;
    }
}