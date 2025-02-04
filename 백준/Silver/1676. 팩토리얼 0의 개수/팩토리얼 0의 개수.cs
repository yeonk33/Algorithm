using System.Numerics;

int N = Convert.ToInt32(Console.ReadLine());
BigInteger Nf = 1;
string Nfstr;
for (int i = 1; i <= N; i++) {
	Nf *= i;
}
Nfstr = Nf.ToString();
int index = 0;
for (index = Nfstr.Length-1; index >= 0; index--) {
	if (Nfstr[index] != '0') {
		Console.WriteLine(Nfstr.Length - index - 1);
		break;
	}
}