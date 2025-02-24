using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

Queue<int> intq = new Queue<int>();
string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());

foreach (var item in inputs) {
	string[] operations = item.Split(' ');

	switch (operations[0]) {
		case "push":
			intq.Enqueue(Convert.ToInt32(operations[1])); break;

		case "pop":
			if (intq.TryDequeue(out int num))
				sb.AppendLine(num.ToString());
			else sb.AppendLine("-1");
			break;

		case "size":
			sb.AppendLine(intq.Count.ToString()); break;

		case "empty":
			if (intq.Count > 0) sb.AppendLine("0");
			else sb.AppendLine("1");
			break;

		case "front":
			if (intq.TryPeek(out int frontNum))
				sb.AppendLine(frontNum.ToString());
			else sb.AppendLine("-1");
			break;

		case "back":
			if (intq.Count > 0) sb.AppendLine(intq.Last().ToString());
			else sb.AppendLine("-1");
			break;

		default:
			break;
	}
}

Console.WriteLine(sb.ToString());

string[] InputsToStringArray(string allInput)
{
	return allInput.Split(new[] { '\n', '\r' });
}