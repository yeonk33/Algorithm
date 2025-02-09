using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
int peopleNum = Convert.ToInt32(sr.ReadLine());
Size[] people = new Size[peopleNum];

for (int i = 0; i < peopleNum; i++) {
	string[] info = sr.ReadLine().Split(' ');
	people[i] = new Size { weight = Convert.ToInt32(info[0]), height = Convert.ToInt32(info[1]) };
}

for (int i = 0; i < peopleNum; i++) {
	people[i].rank = 1;
	for (int j = 0; j < peopleNum; j++) {
		if (i == j) continue;
		if (people[i].weight < people[j].weight && people[i].height < people[j].height) {
			people[i].rank++;
		}
	}
}

foreach (var item in people) {
	sb.Append(item.rank + " ");
}
Console.WriteLine(sb.ToString());

public class Size
{
	public int weight;
	public int height;
	public int rank = 99;
}