using System.IO;

using StringReader sr = new StringReader(Console.ReadLine());
string[] inputs = sr.ReadLine().Split(' ');
int numA = Convert.ToInt32(inputs[0]);
int numB = Convert.ToInt32(inputs[1]);
int gcd = 1, lcm = 1;

int minNum = Math.Min(numA, numB);
// 최대공약수
for (int i = minNum; i > 0; i--) {
	if (numA % i == 0 && numB % i == 0) {
		gcd = i;
		break;
	}
}
// 최소공배수
lcm = (numA / gcd) * (numB / gcd) * gcd;
Console.WriteLine(gcd+"\n"+lcm);