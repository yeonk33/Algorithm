int seriesNum = Convert.ToInt32(Console.ReadLine());
int num = 0;
while (seriesNum != 0) {
	num++;
	if (num.ToString().Contains("666")) {
		seriesNum--;
	}
}
Console.WriteLine(num);