namespace DeijkstraAlgorithm;

public class DeijkstraAlgorithmForMapInGame
{
    public List<(int, int)> GetShortestPath((int, int) startNode, (int, int) endNode, int map_x, int map_y)
    {
        var mapInfo = new (int, (int, int))[map_x, map_y];
        for (int x = 0; x < map_x; x++)
        {
            for (int y = 0; y < map_y; y++)
            {
                mapInfo[x, y].Item1 = map_x * map_y + 1;
                mapInfo[x, y].Item2 = (0, 0);
            }
        }
        
        var marked = new bool[map_x, map_y];
        
        PriorityQueue<(int, int), int> queue = new();
        queue.Enqueue(startNode, 0);
        mapInfo[startNode.Item1, startNode.Item2].Item1 = 0;

        while (queue.Count != 0)
        {
            var vertex = queue.Dequeue();
            var x = vertex.Item1;
            var y = vertex.Item2;
            if (marked[x, y])
            {
                continue;
            }
            marked[x, y] = true;
            var neighbors = new [] {(x - 1, y), (x, y - 1), (x + 1, y), (x, y + 1)};
            foreach (var neighbor in neighbors)
            {
                var nx = neighbor.Item1;
                var ny = neighbor.Item2;
                if (nx == -1 || ny == -1 || nx == map_x || ny == map_y)
                {
                    continue;
                }

                if (mapInfo[nx, ny].Item1 > mapInfo[x, y].Item1 + 1)
                {
                    mapInfo[nx, ny].Item1  = mapInfo[x, y].Item1 + 1;
                    mapInfo[nx, ny].Item2 = (x, y);
                    queue.Enqueue((nx, ny), mapInfo[nx, ny].Item1);
                }
            }
        }
        
        List<(int, int)> path = new();
        var point = mapInfo[endNode.Item1, endNode.Item2].Item2;
        while (point != startNode)
        {
            path.Add(point);
            point = mapInfo[point.Item1, point.Item2].Item2;
        }
        
        path.Reverse();
        return path;
    }
}