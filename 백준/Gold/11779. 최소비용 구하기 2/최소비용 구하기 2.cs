using System;
using System.Collections.Generic;


int N, M;
List<(int to, int cost)>[] graph;
int[] dist;      // 최소 비용을 저장할 배열
int[] prev;      // 경로 추적을 위한 배열

// 도시 개수와 버스 개수 입력
N = int.Parse(Console.ReadLine());
M = int.Parse(Console.ReadLine());

graph = new List<(int to, int cost)>[N + 1];
dist = new int[N + 1];
prev = new int[N + 1];

// 그래프 초기화
for (int i = 1; i <= N; i++)
	graph[i] = new List<(int to, int cost)>();

// 버스 정보 입력 (출발 도시, 도착 도시, 비용)
for (int i = 0; i < M; i++) {
	var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	int from = input[0];
	int to = input[1];
	int cost = input[2];
	graph[from].Add((to, cost));
}

// 시작 도시와 도착 도시 입력
var se = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int start = se[0];
int end = se[1];

// 다익스트라 알고리즘 실행
Dijkstra(start);

// 도착 도시까지의 최소 비용 출력
Console.WriteLine(dist[end]);

// 경로 추적 (prev 배열을 이용해 역추적)
List<int> path = new List<int>();
for (int i = end; i != 0; i = prev[i])
	path.Add(i);

path.Reverse();

// 경로에 포함된 도시 수 출력
Console.WriteLine(path.Count);

// 경로 출력
Console.WriteLine(string.Join(" ", path));


// 다익스트라 알고리즘 구현
void Dijkstra(int start)
{
	// 거리 배열 초기화 (무한대 값으로 설정)
	for (int i = 1; i <= N; i++)
		dist[i] = int.MaxValue;
	dist[start] = 0;

	// 우선순위 큐 사용 (도시 번호, 현재까지 비용)
	var pq = new PriorityQueue<int, int>();
	pq.Enqueue(start, 0);

	while (pq.Count > 0) {
		pq.TryDequeue(out int cur, out int curCost);

		// 이미 더 짧은 경로가 존재하면 건너뜀
		if (curCost > dist[cur]) continue;

		// 인접한 도시들 확인
		foreach (var (next, cost) in graph[cur]) {
			int nextCost = dist[cur] + cost;

			if (nextCost < dist[next]) {
				dist[next] = nextCost;
				prev[next] = cur;
				pq.Enqueue(next, nextCost);
			}
		}
	}
}


