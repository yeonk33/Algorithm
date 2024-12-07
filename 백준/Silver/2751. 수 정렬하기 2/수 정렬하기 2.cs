int inputNum = Convert.ToInt32(Console.ReadLine());

List<int> numbers = new List<int>();

for (int i = 0; i < inputNum; i++) {
	numbers.Add(Convert.ToInt32(Console.ReadLine()));
}

numbers.Sort();

Console.WriteLine(string.Join("\n", numbers));