using System;
using System.IO;
using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
int N = int.Parse(sr.ReadLine());
int[,] apt = new int[N, N];

for (int i = 0; i < N; i++) {
	string line = sr.ReadLine();
	for (int j = 0; j < N; j++) {
		apt[i, j] = line[j] - '0'; // '0'~'1' 문자 → 정수로 변환
	}
}
List<int> blocks = new List<int>();

// 블록 찾기
for (int i = 0; i < N; i++) {
	for (int j = 0; j < N; j++) {
		if (apt[i,j] == 1) {
			blocks.Add(FindBlock(i, j));
		}
	}
}

blocks.Sort();
sb.AppendLine(blocks.Count.ToString());
foreach (int b in blocks) {
	sb.AppendLine(b.ToString());
}
Console.WriteLine(sb.ToString());

int FindBlock(int i, int j)
{
	if (apt[i, j] == 0) return 0;

	apt[i, j] = 0; // 방문한 곳 0으로 지우기
	int count = 1;

	// 상
	if (i - 1 >= 0 && apt[i - 1, j] == 1)
		count += FindBlock(i - 1, j);

	// 하
	if (i + 1 < N && apt[i + 1, j] == 1)
		count += FindBlock(i + 1, j);

	// 좌
	if (j - 1 >= 0 && apt[i, j - 1] == 1)
		count += FindBlock(i, j - 1);

	// 우
	if (j + 1 < N && apt[i, j + 1] == 1)
		count += FindBlock(i, j + 1);

	return count;
}