using System;
using System.Collections.Generic;
using System.IO;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
int V = int.Parse(sr.ReadLine());

NodeInfo[] nodes = new NodeInfo[V + 1]; // 1-based index
for (int i = 1; i <= V; i++)
{
    nodes[i] = new NodeInfo { Node = i, Edges = new List<(int dest, int weight)>() };
}

for (int i = 0; i < V; i++)
{
    string[] tokens = sr.ReadLine().Split();
    int from = int.Parse(tokens[0]);
    int idx = 1;

    while (tokens[idx] != "-1")
    {
        int to = int.Parse(tokens[idx]);
        int weight = int.Parse(tokens[idx + 1]);
        nodes[from].Edges.Add((to, weight));
        idx += 2;
    }
}

// DFS 두 번으로 트리 지름 구하기
bool[] visited = new bool[V + 1];
int maxDist = 0;
int farthestNode = 0;

// 1차 DFS
DFS(1, 0);
visited = new bool[V + 1]; // 방문 초기화
maxDist = 0;

// 2차 DFS (가장 먼 노드에서 다시 시작)
DFS(farthestNode, 0);

// 출력
Console.WriteLine(maxDist);

void DFS(int current, int dist)
{
    visited[current] = true;

    if (dist > maxDist)
    {
        maxDist = dist;
        farthestNode = current;
    }

    foreach (var edge in nodes[current].Edges)
    {
        int next = edge.dest;
        int weight = edge.weight;

        if (!visited[next])
        {
            DFS(next, dist + weight);
        }
    }
}

public class NodeInfo
{
    public int Node;
    public List<(int dest, int weight)> Edges;
}
