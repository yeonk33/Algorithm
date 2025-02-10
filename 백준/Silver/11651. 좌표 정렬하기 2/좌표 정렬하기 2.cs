using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();
int num = Convert.ToInt32(sr.ReadLine());
List<Coordinate> coors = new List<Coordinate>();

for (int i = 0; i < num; i++) {
	string[] userInput = sr.ReadLine().Split(' ');
	coors.Add(new Coordinate { x = Convert.ToInt32(userInput[0]), y = Convert.ToInt32(userInput[1]) });
}

coors = coors.OrderBy(r => r.y).ThenBy(r => r.x).ToList();
foreach (var item in coors) {
	sb.AppendLine(item.x + " " + item.y);
}

Console.WriteLine(sb.ToString());

public class Coordinate
{
	public int x;
	public int y;
}