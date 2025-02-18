StreamReader sr = new StreamReader(Console.OpenStandardInput());

int N = Convert.ToInt32(sr.ReadLine());

if (N > 0 && (N & (N - 1)) == 0) { 
	Console.WriteLine(Math.Pow(2, (int)Math.Log2(N)));
} else {
	int lowerExp = (int)Math.Floor(Math.Log2(N)); 
	Console.WriteLine((N - Math.Pow(2, lowerExp)) * 2); 
}