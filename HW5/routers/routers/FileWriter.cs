namespace FileWriter;

using UndirectedGraph;

/// <summary>
/// Class for record data to text file.
/// </summary>>
public class FileWriter
{
    /// <summary>
    /// Method for recording undirected graph data structure as adjacency list.
    /// </summary>>
    /// <param name="filename">Way to output file.</param>
    /// /// <param name="undirectedGraph">Undirected graph for record.</param>
    /// <returns>Nothing.</returns>
    public static void WriteUndirectedGraphToFile(string filename, UndirectedGraph undirectedGraph)
    {
        var adjacencyList = undirectedGraph.GetAdjacencyList();
        var vertices = undirectedGraph.GetVertices();
        vertices.Sort();
        
        List<(int, int)> addedEdges = new();
        List<string> lines = new();
        
        var line = string.Empty;
        var countOfWroteEdges = 0;
        
        foreach (var vertex in vertices)
        {
            var nearestVertices = adjacencyList[vertex];
            for (var i = 0; i < nearestVertices.Count; i++)
            {
                var nearestVertex = nearestVertices[i];
                
                if (addedEdges.Contains((vertex, nearestVertex.Item1)))
                {
                    continue;
                }

                if (i == 0)
                {
                    line += $"{vertex}: ";
                }
                
                line += $"{nearestVertex.Item1} ({nearestVertex.Item2})";
                countOfWroteEdges++;
                
                if (i != nearestVertices.Count - 1)
                {
                    line += ", ";
                }
                addedEdges.Add((vertex, nearestVertex.Item1));
                addedEdges.Add((nearestVertex.Item1, vertex));
            }

            if (countOfWroteEdges > 0)
            {
                lines.Add(line);
            }

            countOfWroteEdges = 0;
        }
        
        File.WriteAllLines(filename, lines);
    }
}