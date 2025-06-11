using System;
using System.Collections.Generic;

var s = Console.ReadLine().Split();
int n = int.Parse(s[0]);
int m = int.Parse(s[1]);
int x = int.Parse(s[2]) - 1;

var g = new List<(int, int)>[n];
var rg = new List<(int, int)>[n];
for (int i = 0; i < n; i++)
{
    g[i] = new();
    rg[i] = new();
}

for (int i = 0; i < m; i++)
{
    s = Console.ReadLine().Split();
    int a = int.Parse(s[0]) - 1;
    int b = int.Parse(s[1]) - 1;
    int t = int.Parse(s[2]);
    g[a].Add((b, t));
    rg[b].Add((a, t)); // 역방향
}

int[] Dijkstra(List<(int, int)>[] gr, int start)
{
    var d = new int[n];
    Array.Fill(d, int.MaxValue);
    d[start] = 0;

    var pq = new PriorityQueue<int, int>();
    pq.Enqueue(start, 0);

    while (pq.Count > 0)
    {
        pq.TryDequeue(out int cur, out int cost);

        if (d[cur] < cost) continue;

        foreach (var (nxt, w) in gr[cur])
        {
            if (d[nxt] > d[cur] + w)
            {
                d[nxt] = d[cur] + w;
                pq.Enqueue(nxt, d[nxt]);
            }
        }
    }

    return d;
}

var go = Dijkstra(g, x);
var back = Dijkstra(rg, x);

int ans = 0;
for (int i = 0; i < n; i++)
    ans = Math.Max(ans, go[i] + back[i]);

Console.WriteLine(ans);
