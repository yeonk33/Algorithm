StreamReader sr = new StreamReader(Console.OpenStandardInput());

string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
int[] numbers = Array.ConvertAll(inputs, int.Parse);
int[] remainders = new int[10];
Array.Fill(remainders, -1);
int answer = 0;
int remainder;

for (int i = 0; i < 10; i++) {
	remainder = numbers[i] % 42;
	if (!remainders.Contains(remainder)) {
		remainders[i] = remainder;
		answer++;
	}
}

Console.WriteLine(answer);


/* 사용법
 * string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
 * 예제 복붙하고 엔터로 빈 줄 만든담에 컨Z하고 엔터
 */
string[] InputsToStringArray(string allInput)
{
	return allInput.Split(new[] { '\n' });
}