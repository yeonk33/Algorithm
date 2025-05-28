using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());

string[] input = sr.ReadLine().Split();
int N = int.Parse(input[0]); // 사이즈
int r = int.Parse(input[1]); // 행
int c = int.Parse(input[2]); // 열

int size = 1 << N; // 2^N

Console.WriteLine(Z(size, r, c));

int Z(int n, int r, int c)
{
	int result = 0;
	int section = n / 2;

	if (n == 1) return 0;

	if (c < section && r < section) { // 1구역
		result += 0;

	} else if (c >= section && r < section) { // 2구역
		result += section * section;
		c -= section;
	} else if (c < section && r >= section) { // 3구역
		result += section * section * 2;
		r -= section;
	} else { // 4구역
		result += section * section * 3;
		c -= section;
		r -= section;
	}

	result += Z(section, r, c);

	return result;
}
