int inputNum = Convert.ToInt32(Console.ReadLine());

int[] numbers = new int[inputNum];

for (int i = 0; i < inputNum; i++) {
	numbers[i] = Convert.ToInt32(Console.ReadLine());
}

Array.Sort(numbers);

Console.WriteLine(string.Join("\n", numbers));