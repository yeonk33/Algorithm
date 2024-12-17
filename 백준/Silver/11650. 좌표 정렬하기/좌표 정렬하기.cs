using System.Security.Cryptography.X509Certificates;
int coordinateNum = Convert.ToInt32(Console.ReadLine());
List<int[]> coordinates = new List<int[]>();
for (int i = 0; i < coordinateNum; i++) {
	string[] inputs = Console.ReadLine().Split(' ');
	coordinates.Add(
		new int[] { Convert.ToInt32(inputs[0]), Convert.ToInt32(inputs[1]) });
}

// 정렬
var temp = coordinates.OrderBy(c => c[0]).ThenBy(c=>c[1]).ToList<int[]>();
Console.WriteLine(string.Join("\n",temp.Select(c => string.Join(" ", c))));