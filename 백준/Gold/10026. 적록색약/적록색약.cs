using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());
char[,] map = new char[n, n];
bool[,] visited = new bool[n, n];

for (int i = 0; i < n; i++)
{
    var line = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        map[i, j] = line[j];
    }
}

int[] dx = { -1, 1, 0, 0 };
int[] dy = { 0, 0, -1, 1 };

// BFS 함수
void BFS(int x, int y, char color)
{
    Queue<(int, int)> q = new();
    q.Enqueue((x, y));
    visited[x, y] = true;

    while (q.Count > 0)
    {
        var (cx, cy) = q.Dequeue();
        for (int dir = 0; dir < 4; dir++)
        {
            int nx = cx + dx[dir];
            int ny = cy + dy[dir];

            if (nx < 0 || ny < 0 || nx >= n || ny >= n) continue;
            if (visited[nx, ny]) continue;
            if (map[nx, ny] != color) continue;

            visited[nx, ny] = true;
            q.Enqueue((nx, ny));
        }
    }
}

// 일반인 기준
int normalCount = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (!visited[i, j])
        {
            BFS(i, j, map[i, j]);
            normalCount++;
        }
    }
}

// 적록색약 기준 맵 변환
visited = new bool[n, n]; // 방문 배열 초기화
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (map[i, j] == 'G') map[i, j] = 'R';
    }
}

int colorWeakCount = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (!visited[i, j])
        {
            BFS(i, j, map[i, j]);
            colorWeakCount++;
        }
    }
}

Console.WriteLine($"{normalCount} {colorWeakCount}");
