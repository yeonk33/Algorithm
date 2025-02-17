StreamReader sr = new StreamReader(Console.OpenStandardInput());

int N, answer, sum=0;

string[] temp = sr.ReadLine().Split(' ');
N = Convert.ToInt32(temp[0]);
answer = Convert.ToInt32(temp[1]);

int[] cards = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
for (int i = 0; i < cards.Length-2; i++) {
	for (int j = i+1; j<cards.Length-1; j++) {
		for (int k = j + 1; k < cards.Length; k++) {
			if (cards[i] + cards[j] + cards[k] <= answer) {
				sum = Math.Max(sum, cards[i] + cards[j] + cards[k]);
			}
		}
	}
}

Console.WriteLine(sum);