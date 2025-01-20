StreamReader sr = new StreamReader(Console.OpenStandardInput());

int[] mushroomScores = new int[10];
int sum = 0;
for (int i = 0; i < 10; i++) {
	mushroomScores[i] = Convert.ToInt32(sr.ReadLine());
}
for (int i = 0; i < 10; i++) {
	sum += mushroomScores[i];
	if (sum > 100) {
		sum = Math.Abs(sum - 100) <= Math.Abs(sum - mushroomScores[i] - 100) ? sum : sum - mushroomScores[i];
		break;
	}
}

Console.WriteLine(sum);
