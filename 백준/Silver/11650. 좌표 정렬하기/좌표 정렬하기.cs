using System.Security.Cryptography.X509Certificates;
using System.Text;

int coordinateNum = Convert.ToInt32(Console.ReadLine());
List<int[]> coordinates = new List<int[]>();
for (int i = 0; i < coordinateNum; i++) {
	string[] inputs = Console.ReadLine().Split(' ');
	coordinates.Add(
		new int[] { Convert.ToInt32(inputs[0]), Convert.ToInt32(inputs[1]) });
}

// 정렬
var temp = coordinates.OrderBy(c => c[0]).ThenBy(c=>c[1]).ToList<int[]>();
StringBuilder sb = new StringBuilder();
for (int i = 0; i < coordinateNum; i++) {
	sb.AppendLine($"{temp[i][0]} {temp[i][1]}");
}
System.Console.WriteLine(sb.ToString());