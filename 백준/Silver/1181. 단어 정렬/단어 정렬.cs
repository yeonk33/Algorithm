int wordNum = Convert.ToInt32(Console.ReadLine());
List<string> words = new List<string>();
for (int i = 0; i < wordNum; i++) {
	words.Add(Console.ReadLine().ToString());
}
words = words.Distinct().OrderBy(x=>x.Length).ThenBy(x=>x).ToList();
Console.WriteLine(string.Join("\n",words));