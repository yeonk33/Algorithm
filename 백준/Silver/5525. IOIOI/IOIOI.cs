// 실패함수 생성
using System.Text;

int[] CreateFail(string pattern)
{
	int[] fail = new int[pattern.Length];
	int j = 0;

	for (int i = 1; i < pattern.Length; i++) {
		while (j > 0 && pattern[i] != pattern[j]) {
			j = fail[j - 1];
		}

		if (pattern[i] == pattern[j]) {
			j++;
			fail[i] = j;
		}
	}

	return fail;
}

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder pattern = new StringBuilder();

int N = Convert.ToInt32(sr.ReadLine());
int L = Convert.ToInt32(sr.ReadLine());
string str = sr.ReadLine();
pattern.Append("IOI");

// 패턴 생성
for (int i = 1; i < N; i++) {
	pattern.Append("OI");
}

// 검사
int[] fail = CreateFail(pattern.ToString());
int count = 0;
int j = 0;

for (int i = 0; i < str.Length; i++) {
	while (j > 0 && str[i] != pattern[j]) {
		j = fail[j - 1];
	}
	
	if (str[i] == pattern[j])
		j++;

	if (j == pattern.Length) {
		count++;
		j = fail[j - 1];
	}
}

Console.WriteLine(count);