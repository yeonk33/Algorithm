using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());

int[] allNumber = new int[20000001];
int[] myCards = Array.ConvertAll(inputs[1].Split(' '), int.Parse);
foreach (var item in myCards) {
	allNumber[item + 10000000] += 1;
}
int[] questions = Array.ConvertAll(inputs[3].Split(' '), int.Parse);
foreach (var item in questions) {
	sb.Append(allNumber[item + 10000000].ToString() + " ");
}

Console.WriteLine(sb.ToString());

/* 사용법
 * string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
 * 예제 복붙하고 엔터로 빈 줄 만든담에 컨Z하고 엔터
 */
string[] InputsToStringArray(string allInput)
{
	return allInput.Replace("\r", "").Split('\n');
}