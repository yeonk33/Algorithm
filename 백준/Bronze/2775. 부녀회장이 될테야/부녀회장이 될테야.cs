using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sw = new StringBuilder();
int testCase = int.Parse(sr.ReadLine());
int[,] apt = new int[15, 15];

for (int i = 0; i < 15; i++) {
	apt[i, 1] = 1;
	apt[0, i] = i;
}
for (int i = 1; i < 15; i++) {
	for (int j = 2; j < 15; j++) {
		apt[i, j] = apt[i, j - 1] + apt[i - 1, j];
	}
}
for (int i = 0; i < testCase; i++) {
	int floor = int.Parse(sr.ReadLine());
	int num = int.Parse(sr.ReadLine());
	sw.Append(apt[floor, num] + "\n");
}
Console.WriteLine(sw.ToString());
