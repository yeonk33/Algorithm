using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
string answer = "";
foreach (var item in inputs) {
	if (item == "0") break;
	answer = "yes";
	for (int i = 0; i < item.Length / 2; i++) {
		if (item[i] != item[item.Length -1 - i]) {
			answer = "no";
			break;
		}
	}
	sb.AppendLine(answer);
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