using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int T = Convert.ToInt32(sr.ReadLine());

for (int i = 0; i < T; i++) {
	string operation = sr.ReadLine();
	int length = Convert.ToInt32(sr.ReadLine());
	string str = sr.ReadLine();
	List<int> ints = new List<int>();
	if (str.Length >= 3)
		ints = str.Substring(1, str.Length - 2).Split(',').Select(int.Parse).ToList<int>();
	
		

	int index = 0;
	bool reversed = false;
	bool isError = false;

	foreach (var o in operation) {
		if (o == 'R') { // 뒤집기
			index = index == 0 ? ints.Count-1 : 0;
			reversed = !reversed;
		} else { // 버리기
			if (ints.Count == 0) {
				isError = true;
				break;
			}
			
			ints.RemoveAt(index);
			index = index > ints.Count-1 ? ints.Count-1 : 0;
		}
	}

	if (ints.Count == 0 && !isError) {
		sb.AppendLine("[]");
		continue;
	} else if (isError) {
		sb.AppendLine("error");
		continue;
	}

	if (reversed) {
		ints.Reverse();
	}

	sb.Append("[");
	foreach (var n in ints) {
		sb.Append($"{n},");
	}
	sb.Remove(sb.Length-1, 1);
	sb.Append("]");
	sb.AppendLine();
}

Console.WriteLine(sb.ToString());