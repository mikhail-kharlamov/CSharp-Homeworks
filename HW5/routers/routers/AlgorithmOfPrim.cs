namespace Algorithms;

using UndirectedGraph;

public class AlgorithmOfPrim
{
    public static UndirectedGraph GetMinimumSpanningTree(UndirectedGraph undirectedGraph)
    {
        var tree = new UndirectedGraph();
        
        var adjacencyList = undirectedGraph.GetAdjacencyList();

        List<(int, int)> spanningTreeNearbyVertices = new();

        //var vertex = undirectedGraph.GetVertices()[0];

        var vertex = 3;
        
        tree.AddVertex(vertex);
        
        for (var i = 0; i < adjacencyList.Count; i++)
        {
            foreach (var addedVertex in tree.GetVertices())
            {
                spanningTreeNearbyVertices.RemoveAll(x => x.Item1 == addedVertex);
            }
            var nearbyVertices  = adjacencyList[vertex];
            spanningTreeNearbyVertices.AddRange(nearbyVertices);
            vertex = spanningTreeNearbyVertices.Aggregate((first, second) => 
                first.Item2 < second.Item2 && !undirectedGraph.GetVertices().Contains(first.Item1)? first : second).Item1;
            
            tree.AddVertex(vertex); //TODO уточнить алгоритм
        }
        
        return tree;
    }
}