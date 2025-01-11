using System.Text;

int num = int.Parse(Console.ReadLine());
StringBuilder sb = new StringBuilder();

if (num > 1) {
	for (int i = 2; i <= num; i++) {
		if (num % i == 0) {
			sb.Append(i + "\n");
			num /= i;
			i--;
		}
	}
	if (sb.Length <= 0 && num != 1) {
		sb.Append(num);
	}
}

Console.WriteLine(sb);
sb.Clear();