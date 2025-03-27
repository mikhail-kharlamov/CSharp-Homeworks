namespace Routers;

public class AdjacencyListExtractor
{
    public static Dictionary<int, List<Dictionary<int, int>>> ExtractAdjacencyList(List<string> fileLines)
    {
        Dictionary<int, List<Dictionary<int, int>>> adjacencyList = new();

        foreach (var line in fileLines)
        {
            var lineParts = line.Split(": ");
            List<Dictionary<int, int>> relations = new();
            var vertices = lineParts[1].Split(", ");
            foreach (var vertex in vertices)
            {
                Dictionary<int, int> relation = new();
                var vertexParts = vertex.Split(" ");
                var vertexId = int.Parse(vertexParts[0]);
                var vertexWeight = int.Parse(vertexParts[1]);
                relation.Add(vertexId, vertexWeight);
                relations.Add(relation);
            }
            
            adjacencyList.Add(int.Parse(lineParts[0]), relations);
        }
        
        return adjacencyList;
    }
}