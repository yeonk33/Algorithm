using System;
using System.Collections.Generic;

var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
int n = input[0];
int k = input[1];

const int MAX = 100001;
int[] dist = new int[MAX];
int[] cnt = new int[MAX];

for (int i = 0; i < MAX; i++) dist[i] = -1;

var q = new Queue<int>();
q.Enqueue(n);
dist[n] = 0;
cnt[n] = 1;

while (q.Count > 0)
{
    int cur = q.Dequeue();

    foreach (int nxt in new int[] { cur - 1, cur + 1, cur * 2 })
    {
        if (nxt < 0 || nxt >= MAX) continue;

        if (dist[nxt] == -1)
        {
            dist[nxt] = dist[cur] + 1;
            cnt[nxt] = cnt[cur];
            q.Enqueue(nxt);
        }
        else if (dist[nxt] == dist[cur] + 1)
        {
            cnt[nxt] += cnt[cur];
        }
    }
}

Console.WriteLine($"{dist[k]}\n{cnt[k]}");
