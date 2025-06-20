StreamReader sr = new StreamReader(Console.OpenStandardInput());

string[] input = sr.ReadLine().Split(' ');
int N = int.Parse(input[0]);
int M = int.Parse(input[1]);
int[,] map = new int[N, M];
bool[,,] visited = new bool[N, M, 2];
bool breakWall = false;
int[] dx = { -1, 1, 0, 0 }; // 상하좌우
int[] dy = { 0, 0, -1, 1 }; // 상하좌우
int step = 0;


for (int i = 0; i < N; i++)
{
    var line = sr.ReadLine();

    for (int j = 0; j < M; j++)
        map[i, j] = line[j] - '0';
}
sr.Close();

Console.WriteLine(BFS()); 

int BFS()
{
    var q = new Queue<(int x, int y, int used, int dist)>();
    visited[0, 0, 0] = true;
    q.Enqueue((0, 0, 0, 1));  // 시작은 거리 1

    while (q.Count > 0)
    {
        var (x, y, used, dist) = q.Dequeue();
        if (x == N - 1 && y == M - 1) return dist;

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i], ny = y + dy[i];
            if (nx < 0 || ny < 0 || nx >= N || ny >= M) continue;

            // 통로
            if (map[nx, ny] == 0 && !visited[nx, ny, used])
            {
                visited[nx, ny, used] = true;
                q.Enqueue((nx, ny, used, dist + 1));
            }
            // 벽이고, 아직 벽을 부수지 않은 경우
            else if (map[nx, ny] == 1 && used == 0 && !visited[nx, ny, 1])
            {
                visited[nx, ny, 1] = true;
                q.Enqueue((nx, ny, 1, dist + 1));
            }
        }
    }
    return -1;
}