using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int[,] graph;
int[,] result;
bool[] visited;

int N = Convert.ToInt32(sr.ReadLine());
graph = new int[N, N];
result = new int[N, N];
visited = new bool[N];

// 입력 받기
for (int i = 0; i < N; i++) {
	string[] inputs = sr.ReadLine().Split(' ');
	for (int j = 0; j < inputs.Length; j++) {
		graph[i,j] = Convert.ToInt32(inputs[j]);
	}
}

for (int i = 0; i < N; i++) {
	visited = new bool[N];
	DFS(i, i);
}

for (int i = 0; i < N; i++) {
	for (int j = 0; j < N; j++) {
		sb.Append(result[i, j] + " ");
	}
	sb.Append("\n");
}

Console.WriteLine(sb.ToString());

void DFS(int start, int current)
{
	for (int next = 0; next < N; next++) {
		if (graph[current, next] == 1 && !visited[next]) {
			visited[next] = true;
			result[start, next] = 1;
			DFS(start, next);
		}
	}
}