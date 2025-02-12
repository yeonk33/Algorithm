using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
string inputStr;
List<string> strings = new List<string>();
Stack<char> brackets = new Stack<char>();
string result = "";

while (true) {
	inputStr = sr.ReadLine();
	if (inputStr == ".") break;
	strings.Add(inputStr);
}

foreach (var str in strings) {
	result = "yes";
	foreach (var c in str) {
		switch (c) {
			case '(':
			case '[':
				brackets.Push(c);
				break;

			case ')':
				if (brackets.Count == 0) { result = "no"; break; }
				if (brackets.Pop() != '(') { result = "no"; break; }
				break;
			case ']':
				if (brackets.Count == 0) { result = "no"; break; }
				if (brackets.Pop() != '[') { result = "no"; break; }
				break;

			default:
				break;
		}

		if (result == "no") break;
	}

	if (brackets.Count > 0) result = "no";

	sb.AppendLine(result);
	brackets.Clear();
}

Console.WriteLine(sb.ToString());