using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int line = Convert.ToInt32(sr.ReadLine());
string[] operations;
HashSet<int> S = new HashSet<int>();
for (int i = 0; i < line; i++) {
	operations = sr.ReadLine().Split(' ');
	switch (operations[0]) {
		case "add":
			S.Add(Convert.ToInt32(operations[1]));
			break;

		case "remove":
			S.Remove(Convert.ToInt32(operations[1]));
			break;

		case "check":
			string result = S.Contains(Convert.ToInt32(operations[1])) ? "1" : "0";
			sb.AppendLine(result);
			break;

		case "toggle":
			if (S.Contains(Convert.ToInt32(operations[1]))) {
				S.Remove(Convert.ToInt32(operations[1]));
			} else {
				S.Add(Convert.ToInt32(operations[1]));
			}
			break;

		case "all":
			S = new HashSet<int>(Enumerable.Range(1, 20));
			break;

		case "empty":
			S = new HashSet<int>();
			break;

		default:
			break;
	}
}

Console.WriteLine(sb.ToString());

