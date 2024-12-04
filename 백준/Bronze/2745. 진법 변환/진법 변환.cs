string[] str = Console.ReadLine().Split(' ');
int B = Convert.ToInt32(str[1]);
double decimalNum = 0;
int n = 0;
for (int i = 0; i < str[0].Length; i++)
{
	if ('A' <= str[0][i] && str[0][i] <= 'Z')
	{
		n = Convert.ToInt32(str[0][i]) - 55;
	}
    else
    {
		n = Convert.ToInt32(str[0][i]) - 48;
	}

	decimalNum +=  Math.Pow(B, (str[0].Length - i - 1)) * n;
}

Console.WriteLine(decimalNum);