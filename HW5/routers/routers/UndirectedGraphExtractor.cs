namespace UndirectedGraphExtractor;

using UndirectedGraph;

using System;
using System.Text.RegularExpressions; //TODO исправить добавление путей

public class UndirectedGraphExtractor
{
    public static UndirectedGraph Extract(List<string> fileLines)
    {
        var undirectedGraph = new UndirectedGraph();
        
        var pattern1 = @"(\d+):";
        var pattern2 = @"\s*(\d+)\s*\((\d+)\)";

        foreach (var line in fileLines)
        {
            var matchesForVertices = Regex.Matches(line, pattern1);
            var matchesForEdges = Regex.Matches(line, pattern2);
            
            var vertex1 = int.Parse(matchesForVertices[0].Groups[1].Value);
            
            foreach (Match match in matchesForEdges)
            {
                var vertex2 = int.Parse(match.Groups[1].Value);
                var weight = int.Parse(match.Groups[2].Value);
                
                undirectedGraph.AddEdge(vertex1, vertex2, weight);
            }
        }
        
        return undirectedGraph;
    }
}