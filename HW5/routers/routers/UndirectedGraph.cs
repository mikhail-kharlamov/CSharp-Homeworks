// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

namespace UndirectedGraph;

/// <summary>
/// Class for undirected graph data structure.
/// </summary>>
public class UndirectedGraph
{
    private HashSet<int> Vertices { get; set; } = new();
    
    private Dictionary<(int, int), int> Edges { get; set; } = new();
    
    private Dictionary<int, List<(int, int)>> AdjacencyList { get; set; } = new();

    /// <summary>
    /// Method for setting graph by adjacency list.
    /// </summary>>
    /// <param name="list">Adjacency list.</param>
    /// <returns>Nothing.</returns>
    public void SetAdjacencyList(Dictionary<int, List<(int, int)>> list)
    {
        this.AdjacencyList = list;
        this.Vertices = list.Keys.ToHashSet();
        this.Edges = new();

        foreach (var vertex in this.Vertices)
        {
            var nearbyVertices = this.AdjacencyList[vertex];
            foreach (var nearbyVertex in nearbyVertices)
            {
                this.Edges[(vertex, nearbyVertex.Item1)] = nearbyVertex.Item2;
            }
        }
    }

    /// <summary>
    /// Method for getting adjacency list.
    /// </summary>>
    /// <returns>Adjacency list.</returns>
    public Dictionary<int, List<(int, int)>> GetAdjacencyList()
    {
        return this.AdjacencyList;
    }

    /// <summary>
    /// Method for adding vertex to graph.
    /// </summary>>
    /// <param name="vertex">Vertex as int number.</param>
    /// <returns>Nothing.</returns>
    public void AddVertex(int vertex)
    {
        this.Vertices.Add(vertex);
        if (!this.AdjacencyList.ContainsKey(vertex))
        {
            this.AdjacencyList.Add(vertex, new List<(int, int)>());
        }
    }

    /// <summary>
    /// Method for adding edge to graph.
    /// </summary>>
    /// <param name="vertex1">The first vertex as int number.</param>
    /// <param name="vertex2">The second vertex as int number.</param>
    /// <param name="weight">Weight of the edge.</param>
    /// <returns>Nothing.</returns>
    public void AddEdge(int vertex1, int vertex2, int weight)
    {
        if (!this.Vertices.Contains(vertex1) || !this.Vertices.Contains(vertex2))
        {
            this.AddVertex(vertex1);
            this.AddVertex(vertex2);
        }
        
        this.Edges[(vertex1, vertex2)] = weight;
        this.Edges[(vertex2, vertex1)] = weight;
        
        this.AdjacencyList[vertex1].Add((vertex2, weight));
        this.AdjacencyList[vertex2].Add((vertex1, weight));
    }

    /// <summary>
    /// Method for getting neighbours of vertex.
    /// </summary>>
    /// <param name="vertex">Vertex as int number.</param>
    /// <returns>List of the pairs of nearby vertices and weights of the edges with them.</returns>
    public List<(int, int)> GetNeighbors(int vertex)
    {
        HashSet<(int, int)> neighbors = new();
        foreach (var edge in this.Edges.Keys)
        {
            if (edge.Item1 == vertex)
            {
                neighbors.Add((edge.Item2, this.Edges[edge]));
            }
            else if (edge.Item2 == vertex)
            {
                neighbors.Add((edge.Item1, this.Edges[edge]));
            }
        }
        
        return neighbors.ToList();
    }

    /// <summary>
    /// Method for getting graph vertices.
    /// </summary>>
    /// <returns>List of vertices.</returns>
    public List<int> GetVertices()
    {
        return this.Vertices.ToList();
    }

    /// <summary>
    /// Method for getting graph edges.
    /// </summary>>
    /// <returns>Dictionary that maps tha pair of vertices to weight of the edge between them.</returns>
    public Dictionary<(int, int), int> GetEdges()
    {
        return this.Edges;
    }
}