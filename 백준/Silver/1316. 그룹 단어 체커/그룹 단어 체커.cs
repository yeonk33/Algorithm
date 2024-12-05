int inputNum = Convert.ToInt32(Console.ReadLine());

List<string> words = new List<string>();
bool isGroup = true;

for (int i = 0; i < inputNum; i++) {
	words.Add(Console.ReadLine());
}

foreach (string word in words) {
	isGroup = true;
	for (int i = 0; i < word.Length - 1; i++) {
		if (word[i] == word[i+1]) {
			continue;
		}
		for (int j = i+1; j < word.Length; j++) {
			if (word[i] == word[j]) {
				inputNum--;
				isGroup = false;
				break;
			}
			if (!isGroup) {
				break;
			}
		}
		if (!isGroup) {
			break;
		}
	}
}

System.Console.WriteLine(inputNum);