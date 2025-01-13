using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
string input = sr.ReadLine();
StringBuilder sb = new StringBuilder();

int[] counts = new int[10];
for (int i = 0; i < input.Length; i++) {
	counts[input[i]-48]++;
}
for (int i = 9; i >= 0; i--) {
	for (int j = 0; j < counts[i]; j++) {
		sb.Append(i); 
	}
}

Console.WriteLine(sb.ToString());