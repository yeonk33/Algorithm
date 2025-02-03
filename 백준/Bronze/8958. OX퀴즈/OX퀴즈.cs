using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
int count = Convert.ToInt32(sr.ReadLine());
string[] tcs = new string[count];
int total = 0;	// 총합
int score = 1;	// 더해질 점수

for (int i = 0; i < count; i++) {
	tcs[i] = sr.ReadLine();
}

foreach (var item in tcs) {
	if (item[0] == 'O') {
		total += score;
		score++;
	}
	for (int i = 1; i < item.Length; i++) {
		if (item[i] == 'O') {
			total += score;
			score++;

		} else if (item[i] == 'X') {
			score = 1;
		}
	
	}
	sb.AppendLine(total.ToString());
	total = 0;
	score = 1;
}

Console.WriteLine(sb);