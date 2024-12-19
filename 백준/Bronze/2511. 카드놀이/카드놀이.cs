string[] ACards = Console.ReadLine().ToString().Split(" ");
string[] BCards = Console.ReadLine().ToString().Split(" ");

int AScore = 0;
int BScore = 0;
char winner = '\0';

for (int i = 0; i < ACards.Length; i++) {
	if (Convert.ToInt32(ACards[i]) > Convert.ToInt32(BCards[i])) {
		AScore += 3;
		winner = 'A';
	} else if (Convert.ToInt32(ACards[i]) < Convert.ToInt32(BCards[i])) {
		BScore += 3;
		winner = 'B';
	} else {
		AScore++;
		BScore++;
	}
}

if (AScore > BScore) {
	winner = 'A';
} else if (AScore < BScore) { 
	winner = 'B';
} else if (winner == '\0') {
	winner = 'D';
}
System.Console.WriteLine($"{AScore} {BScore}\n{winner}");