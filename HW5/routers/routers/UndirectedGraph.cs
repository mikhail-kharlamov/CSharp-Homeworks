namespace UndirectedGraph;

public class UndirectedGraph
{
    private HashSet<int> Vertices { get; set; } = new();
    
    private Dictionary<(int, int), int> Edges { get; set; } = new();
    
    private Dictionary<int, List<(int, int)>> AdjacencyList { get; set; } = new();

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

    public Dictionary<int, List<(int, int)>> GetAdjacencyList()
    {
        return this.AdjacencyList;
    }

    public void AddVertex(int vertex)
    {
        this.Vertices.Add(vertex);
        if (!this.AdjacencyList.ContainsKey(vertex))
        {
            this.AdjacencyList.Add(vertex, new List<(int, int)>());
        }
    }

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

    public List<int> GetVertices()
    {
        return this.Vertices.ToList();
    }

    public Dictionary<(int, int), int> GetEdges()
    {
        return this.Edges;
    }
}