using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] sizes = sr.ReadLine().Split(' ');
int height = Convert.ToInt32(sizes[0]);
int width = Convert.ToInt32(sizes[1]);

// 맵 생성
// 0은 갈 수 없는 땅이고 1은 갈 수 있는 땅, 2는 목표지점이다.
int[,] map = new int[height,width];
int[,] resultMap = new int[height,width];
int[,] visited = new int[height, width]; // true=1 false=0
string[] inputs;
int[] target = new int[2];  // 2의 좌표
int[] current = new int[2]; // 현재 좌표
for (int i = 0; i < height; i++) {
	inputs = sr.ReadLine().Split(' ');
	for (int j = 0; j < width; j++) {
		map[i, j] = Convert.ToInt32(inputs[j]);
		if (map[i, j] == 2) target = new int[]{ i, j };
		if (map[i, j] == 1) resultMap[i, j] = -1; // -1로 초기화
	}
}

Queue<int[]> nodes = new Queue<int[]>(); // 방문 예정 좌표들
int depth = 0;
current = new int[] { target[0], target[1], 0 }; // start point
nodes.Enqueue(current);
visited[target[0], target[1]] = 1;
while (nodes.Count > 0) {
	Search();
}

// 결과출력
for (int i = 0; i < height; i++) {
	for (int j = 0; j < width; j++) {
		sb.Append(resultMap[i, j] + " ");
	}
	sb.AppendLine();
}

Console.WriteLine(sb.ToString());

void Search()
{
	int[] current = nodes.Dequeue();
	depth = current[2] + 1;
	if (current[1] + 1 < width && map[current[0], current[1] + 1] != 0 
		&& visited[current[0], current[1] + 1] == 0) {
		nodes.Enqueue(new int[] { current[0], current[1] + 1, depth });
		visited[current[0], current[1] + 1] = 1;
	}

	if (current[0] + 1 < height && map[current[0] + 1, current[1]] != 0
		 && visited[current[0] + 1, current[1]] == 0) {
		nodes.Enqueue(new int[] { current[0] + 1, current[1], depth });
		visited[current[0] + 1, current[1]] = 1;
	}

	if (current[1] - 1 >= 0 && map[current[0], current[1] - 1] != 0
		 && visited[current[0], current[1] - 1] == 0) {
		nodes.Enqueue(new int[] { current[0], current[1] - 1, depth });
		visited[current[0], current[1] - 1] = 1;
	}

	if (current[0] - 1 >= 0 && map[current[0] - 1, current[1]] != 0
		 && visited[current[0] - 1, current[1]] == 0) {
		nodes.Enqueue(new int[] { current[0] - 1, current[1], depth });
		visited[current[0] - 1, current[1]] = 1;
	}

	resultMap[current[0], current[1]] = current[2];
}