bool[] selfNumbers = new bool[10001];

for (int i = 0; i <= 10001; i++) {
	int tenThousand = i / 10000;   // 만의 자리
	int thousand = (i / 1000) % 10; // 천의 자리
	int hundred = (i / 100) % 10;   // 백의 자리
	int ten = (i / 10) % 10;        // 십의 자리
	int one = i % 10;               // 일의 자리
	
int selfNumber = i + tenThousand + thousand + hundred + ten + one;

	if (selfNumber <= 10000) {
		selfNumbers[selfNumber] = true;
	}
}

for (int i = 0; i < selfNumbers.Length; i++) {
	if (!selfNumbers[i]) {
		System.Console.WriteLine(i);
	}
}
