StreamReader sr = new StreamReader(Console.OpenStandardInput());
string[] inputs = new string[3];
int result = 0;
int index = 0;

for (index = 0; index < 3; index++) {
	inputs[index] = sr.ReadLine();
	if (int.TryParse(inputs[index], out result)) {
		break;
	}
}

result = result + 3 - index;

if (result % 3 == 0 && result % 5 == 0) {
	Console.WriteLine("FizzBuzz");
} else if (result % 3 == 0) {
	Console.WriteLine("Fizz");
} else if (result % 5 == 0) {
	Console.WriteLine("Buzz");
} else {
	Console.WriteLine(result);
}
