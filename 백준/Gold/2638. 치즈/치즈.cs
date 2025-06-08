using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

string[] input = sr.ReadLine().Split();
int N = int.Parse(input[0]);
int M = int.Parse(input[1]);

int[,] map = new int[N, M];
bool[,] visited = new bool[N, M];
int[] dx = { -1, 1, 0, 0 };
int[] dy = { 0, 0, -1, 1 };

for (int i = 0; i < N; i++)
{
    string[] line = sr.ReadLine().Split();
    for (int j = 0; j < M; j++)
    {
        map[i, j] = int.Parse(line[j]);
    }
}

int time = 0;

while (true)
{
    // 외부 공기 탐색
    visited = new bool[N, M];
    MarkOutsideAir();

    // 이번 턴에 녹일 치즈 찾기
    List<(int x, int y)> toMelt = new();

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            if (map[i, j] == 1 && ShouldMelt(i, j))
            {
                toMelt.Add((i, j));
            }
        }
    }

    if (toMelt.Count == 0)
        break;  // 종료

    // 치즈 녹이기
    foreach (var (x, y) in toMelt)
    {
        map[x, y] = 0;
    }

    time++;
}

sw.WriteLine(time);
sw.Flush();

void MarkOutsideAir()
{
    Queue<(int x, int y)> q = new();
    q.Enqueue((0, 0));
    visited[0, 0] = true;

    while (q.Count > 0)
    {
        var (x, y) = q.Dequeue();

        for (int dir = 0; dir < 4; dir++)
        {
            int nx = x + dx[dir];
            int ny = y + dy[dir];

            if (nx >= 0 && ny >= 0 && nx < N && ny < M)
            {
                if (!visited[nx, ny] && map[nx, ny] == 0)
                {
                    visited[nx, ny] = true;
                    q.Enqueue((nx, ny));
                }
            }
        }
    }
}

bool ShouldMelt(int x, int y)
{
    int count = 0;
    for (int dir = 0; dir < 4; dir++)
    {
        int nx = x + dx[dir];
        int ny = y + dy[dir];

        if (nx >= 0 && ny >= 0 && nx < N && ny < M)
        {
            if (visited[nx, ny] && map[nx, ny] == 0)
            {
                count++;
            }
        }
    }

    return count >= 2;
}
