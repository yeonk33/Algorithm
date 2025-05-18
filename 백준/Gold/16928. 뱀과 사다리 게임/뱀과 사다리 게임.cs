using System;
using System.Collections.Generic;

int[] board = new int[101];
bool[] visited = new bool[101];

var input = Console.ReadLine().Split();
int n = int.Parse(input[0]);
int m = int.Parse(input[1]);

for (int i = 0; i < n + m; i++)
{
    var line = Console.ReadLine().Split();
    int from = int.Parse(line[0]);
    int to = int.Parse(line[1]);
    board[from] = to;
}

Queue<(int pos, int cnt)> q = new();
q.Enqueue((1, 0));
visited[1] = true;

while (q.Count > 0)
{
    var (cur, cnt) = q.Dequeue();
    if (cur == 100)
    {
        Console.WriteLine(cnt);
        return;
    }

    for (int i = 1; i <= 6; i++)
    {
        int next = cur + i;
        if (next > 100) continue;

        if (board[next] != 0)
            next = board[next];

        if (!visited[next])
        {
            visited[next] = true;
            q.Enqueue((next, cnt + 1));
        }
    }
}
