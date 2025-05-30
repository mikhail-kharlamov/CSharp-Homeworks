// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

namespace Algorithms;

using UndirectedGraph;

/// <summary>
/// Class for algorithm of Prim.
/// </summary>>
public class AlgorithmOfPrim
{
    /// <summary>
    /// Method for getting the minimum spanning tree of the undirected graph.
    /// </summary>>
    /// <param name="undirectedGraph">Graph fot getting minimum spanning tree.</param>
    /// <param name="reverse">Optional argument for finding the largest paths to the nearest vertices.</param>
    /// <returns>Minimum spanning tree as undirected graph data structure .</returns>
    public static UndirectedGraph GetMinimumSpanningTree(UndirectedGraph undirectedGraph, bool reverse = false)
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
            
            spanningTreeNearbyVertices.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            var minimalEdge = reverse ? spanningTreeNearbyVertices[^1] : spanningTreeNearbyVertices[0];
            tree.AddEdge(minimalEdge.Item1, minimalEdge.Item2, minimalEdge.Item3);
            
            spanningTreeNearbyVertices.Clear();
        }
        
        return tree;
    }
    
    
}