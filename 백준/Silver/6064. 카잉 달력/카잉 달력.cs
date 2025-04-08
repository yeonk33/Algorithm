using System;
using System.Text;
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
int T = Convert.ToInt32(sr.ReadLine());
List<int[]> inputs = new List<int[]>();
for (int i = 0; i < T; i++) {
	inputs.Add(Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse));
}
foreach (var item in inputs) {
	int i = 0;
	int M = item[0];
	int N = item[1];
	int x = item[2];
	int y = item[3];
	int quit = (M * N) / gcd(M, N);
	int num;
	while (true) {
		num = i * M + x;

		if ((num - 1) % N + 1 == y) {
			sb.AppendLine(num.ToString());
			break;
		}

		i++;
		if (num > quit) {
			sb.AppendLine("-1");
			break;
		}
	}
}
Console.WriteLine(sb.ToString());

int gcd(int n, int m)
{
	//두 수 n, m 이 있을 때 어느 한 수가 0이 될 때 까지 재귀함수 반복
	if (m == 0) return n;
	else return gcd(m, n % m);
}