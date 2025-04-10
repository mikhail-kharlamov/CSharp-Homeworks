namespace Routers;

using UndirectedGraphExtractor;
using Algorithms;
using FileWriter;

/// <summary>
/// Class for main program with console interface.
/// </summary>>
public class Routers
{
    /// <summary>
    /// Main method
    /// </summary>>
    /// <param name="args">Arguments from command line.</param>
    /// <returns>Nothing.</returns>
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
            var minimumSpanningTree = AlgorithmOfPrim.GetMinimumSpanningTree(undirectedGraph, true);
            FileWriter.WriteUndirectedGraphToFile(fileToWrite, minimumSpanningTree);
            Console.WriteLine("The response was recorded successfully");
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