string inputString = Console.ReadLine();

string[] croatiaAlphabets = { "c=", "c-", "dz=", "d-", "lj", "nj", "s=", "z=" };

foreach (string croatia in croatiaAlphabets) {
	inputString = inputString.Replace(croatia, " ");
}

System.Console.WriteLine(inputString.Length);