namespace Routers;

using UndirectedGraphExtractor;
using Algorithms;
using FileWriter;

public class Routers
{
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: routers <file_to_read> <file_to_write>");
            return;
        }
        
        var fileToRead = args[0];
        var fileToWrite = args[1];

        try
        {
            var undirectedGraph = UndirectedGraphExtractor.Extract(fileToRead);
            var minimumSpanningTree = AlgorithmOfPrim.GetMinimumSpanningTree(undirectedGraph);
            FileWriter.WriteUndirectedGraphToFile(fileToWrite, minimumSpanningTree);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}