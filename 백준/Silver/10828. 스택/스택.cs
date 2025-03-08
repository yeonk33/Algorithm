using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
string[] str;
Stack<int> ints = new Stack<int>();

foreach (var item in inputs) {
	str = item.Split(' ');
	switch (str[0]) {
		case "push":
			ints.Push(int.Parse(str[1]));
			break;

		case "pop":
			sb.AppendLine(ints.Count != 0 ? ints.Pop().ToString() : "-1");
			break;

		case "size":
			sb.AppendLine(ints.Count.ToString());
			break;
			
		case "empty":
			sb.AppendLine(ints.Count == 0 ? "1" : "0");
			break;

		case "top":
			sb.AppendLine(ints.Count != 0 ? ints.Peek().ToString() : "-1");
			break;

		default:
			break;
	}
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