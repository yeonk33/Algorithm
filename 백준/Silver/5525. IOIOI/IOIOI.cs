StreamReader sr = new StreamReader(Console.OpenStandardInput());

int N = Convert.ToInt32(sr.ReadLine());
int length = Convert.ToInt32(sr.ReadLine());
string inputStr = sr.ReadLine();
string str = "IOI";
int count = 0;
for (int i = 1; i < N; i++) {
	str += "OI";
}
for (int i = 0; i <= length-str.Length; i++) {
	if (inputStr.Substring(i, str.Length) == str) {
		count++;
	}
}

Console.WriteLine(count);