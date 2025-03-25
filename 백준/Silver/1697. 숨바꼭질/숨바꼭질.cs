StreamReader sr = new StreamReader(Console.OpenStandardInput());

int[] inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int subin = inputs[0];
int target = inputs[1];

Console.WriteLine(BFS(subin, target));

int BFS(int start, int target)
{
	if (start == target) return 0;

	bool[] visited = new bool[100001];
	Queue<int> queue = new Queue<int>();
	int[] depth = new int[100001];

	queue.Enqueue(start);
	visited[start] = true;

	while (queue.Count > 0) {
		int cur = queue.Dequeue();

		// 3가지 이동 방법: -1, +1, *2
		int[] nextPositions = { cur - 1, cur + 1, cur * 2 };

		foreach (int next in nextPositions) {
			// 유효한 위치인지 체크하고, 아직 방문하지 않았다면
			if (next >= 0 && next <= 100000 && !visited[next]) {
				visited[next] = true;
				queue.Enqueue(next);
				depth[next] = depth[cur] + 1;

				if (next == target)
					return depth[next];
			}
		}
	}

	return -1;
}
