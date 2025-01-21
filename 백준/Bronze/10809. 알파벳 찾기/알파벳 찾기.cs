using System.Text;

string word = Console.ReadLine();
int[] location = new int[26];
int index = 0;
StringBuilder sb = new StringBuilder();

for (int i = 0; i < location.Length; i++) {
	location[i] = -1;
}

foreach (char c in word) {
	if (location[c-'a'] == -1) {
		location[c - 'a'] = index;
	}
	index++;
}

for (int i = 0; i<location.Length; i++) {
	sb.Append(location[i] + " ");
}

Console.WriteLine(sb.ToString());