using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int n = int.Parse(sr.ReadLine());
List<(int, int)> meetings = new List<(int, int)>();

for (int i = 0; i < n; i++) {
	string[] input = sr.ReadLine().Split();
	int start = int.Parse(input[0]);
	int end = int.Parse(input[1]);
	meetings.Add((start, end));
}

sb.AppendLine(Meeting(meetings).ToString());

Console.WriteLine(sb.ToString());

int Meeting(List<(int, int)> m)
{
	m.Sort(CompareMeeting); // 끝나는 시간 순으로 정렬

	int count = 0;
	int endTime = 0;

	foreach (var item in m) {
		if (item.Item1 >= endTime) { // 앞 회의 끝난 이후면 회의 시작
			count++;
			endTime = item.Item2;
		}
	}

	return count;
}

int CompareMeeting((int, int) x, (int, int) y)
{
	// 끝나는 시간 비교
	if (x.Item2 == y.Item2) { // 같으면 시작시간 비교
		return x.Item1.CompareTo(y.Item1); // x>y:1 x==y:0 x<y:-1
	}
	return x.Item2.CompareTo(y.Item2);
}