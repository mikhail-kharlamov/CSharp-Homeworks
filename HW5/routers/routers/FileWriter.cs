namespace FileWriter;

using UndirectedGraph;

public class FileWriter
{
    public static void WriteUndirectedGraphToFile(string filename, UndirectedGraph undirectedGraph)
    {
        var adjacencyList = undirectedGraph.GetAdjacencyList();
        var edges = undirectedGraph.GetEdges();
        foreach (var vertex in adjacencyList.Keys)
        {
            
        }
    }
    //TODO дописать логику записи в файл
}