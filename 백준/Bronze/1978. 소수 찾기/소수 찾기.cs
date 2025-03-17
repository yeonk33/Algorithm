using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());

int N = Convert.ToInt32(sr.ReadLine());
int[] ints = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int count = 0;

foreach (var i in ints) {
	count += Check(i);
}

Console.WriteLine(count);

int Check(int i)
{
	if (i == 1) return 0;
	for (int j = 2; j < 1000; j++) {
		if (i % j == 0 && i != j) return 0;
	}
	return 1;
}