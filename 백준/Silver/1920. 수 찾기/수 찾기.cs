using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int N, M;
HashSet<string> A = new HashSet<string>();
List<string> B;
N = Convert.ToInt32(sr.ReadLine());
A = sr.ReadLine().Split(' ').ToHashSet();


M = Convert.ToInt32(sr.ReadLine());
B = sr.ReadLine().Split(' ').ToList();
foreach (var b in B) {
	if (A.Contains(b)) {	// A에 있는 값
		sb.AppendLine("1");
	} else {				// A에 없는 값
		sb.AppendLine("0");
	}
}

Console.WriteLine(sb.ToString());
