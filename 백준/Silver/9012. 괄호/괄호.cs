using System.Runtime.CompilerServices;
using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] inputs = new string[Convert.ToInt32(sr.ReadLine())];
for (int i = 0; i < inputs.Length; i++) {
	inputs[i] = sr.ReadLine();
}
Stack<char> tokens = new Stack<char>();
string answer = "";
foreach (var item in inputs) {
	tokens.Clear();
	if (item.Length == 1 && item[0] >= '0' && item[0] <= '9') continue;
	if (item[0] == ')') {
		sb.AppendLine("NO");
		continue;
	}
	answer = "YES";
	foreach (var c in item) {
		if (c == '(') {
			tokens.Push(c);
		} else if (c == ')') { 
			if (!tokens.TryPop(out char result)) {
				answer = "NO";
				break;
			}
		}
	}
	if (tokens.Count != 0) answer = "NO";
	sb.AppendLine(answer);
}

Console.WriteLine(sb.ToString());