using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

public class GraphConnectedComponents
{
    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
        //isVisited = new bool[graph.Length];
        //DFS(0);
        //Console.WriteLine();
    }

    static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries).
            Select(int.Parse).ToList();
        }

        return graph;
    }

    static void FindGraphConnectedComponents()
    {
        isVisited = new bool[graph.Length];

        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!isVisited[startNode])
            {
                Console.Write("Connected component:");
                DFS(startNode);
                Console.WriteLine();
            }
        }
    }

    static bool[] isVisited;

    static void DFS(int node)
    {
        if (!isVisited[node])
        {
            isVisited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            Console.Write(" " + node);
        }
    }

    static new List<int>[] graph = new List<int>[]
        {
            new List<int>() {3, 6},
            new List<int>() {3, 3,5,6},
            new List<int>() {8},
            new List<int>() {0,1,5},
            new List<int>() {1,6},
            new List<int>() {1,3},
            new List<int>() {0,1,4},
            new List<int>() {3, 6},
            new List<int>() {2},
        };
}
