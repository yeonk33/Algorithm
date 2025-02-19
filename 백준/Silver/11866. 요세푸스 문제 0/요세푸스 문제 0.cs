using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
string[] strs = sr.ReadLine().Split(' ');
int N = Convert.ToInt32(strs[0]);
int K = Convert.ToInt32(strs[1]);

List<int> numbers = new List<int>(Enumerable.Range(1,N));
sb.Append("<");
int count = 1;
while (numbers.Count > 1) {
	if (count < K) {
		numbers.Add(numbers[0]);
		numbers.RemoveAt(0);
	} else {
		sb.Append(numbers[0] + ", ");
		numbers.RemoveAt(0);
		count = 1;
		continue;
	}
	count++;
}
sb.Append(numbers[0] + ">");
Console.WriteLine(sb.ToString());