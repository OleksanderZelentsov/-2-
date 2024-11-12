using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_перероб_
{
    public class Graph
    {
        private int vertices;
        private List<int>[] adjList;

        public Graph(int v)
        {
            vertices = v;
            adjList = new List<int>[v];
            for (int i = 0; i < v; i++)
                adjList[i] = new List<int>();
        }

        public void AddEdgeDirected(int v, int b)
        {
            adjList[v].Add(b);
        }

        public void AddEdgeUndirected(int v, int b)
        {
            adjList[v].Add(b);
            adjList[b].Add(v);
        }

        private void RecursionDFS(int v, bool[] visited, List<int> result)
        {
            visited[v] = true;
            result.Add(v);

            foreach (int adj in adjList[v])
            {
                if (!visited[adj])
                    RecursionDFS(adj, visited, result);
            }
        }

        public List<int> DFS(int first)
        {
            bool[] visited = new bool[vertices];
            List<int> result = new List<int>();

            RecursionDFS(first, visited, result);
            return result; 
        }


        public List<int> BFS(int first)
        {
            bool[] visited = new bool[vertices];
            Queue<int> queue = new Queue<int>();
            List<int> result = new List<int>();

            visited[first] = true;
            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                first = queue.Dequeue();
                result.Add(first);

                foreach (int adj in adjList[first])
                {
                    if (!visited[adj])
                    {
                        visited[adj] = true;
                        queue.Enqueue(adj);
                    }
                }
            }

            return result;
        }
    }
}
