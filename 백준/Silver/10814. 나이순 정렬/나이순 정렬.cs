using System.Text;
using Member;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int input = Convert.ToInt32(sr.ReadLine());
Info[] members = new Info[input];
for (int i = 0; i < input; i++) {
	string[] temp = sr.ReadLine().Split(' ');
	members[i] = new Info { Age = Convert.ToInt32(temp[0]), 
							Name = temp[1], Order = i };
}
var orderedMem = members.OrderBy(x => x.Age).ThenBy(x=>x.Order).ToArray();
foreach (var item in orderedMem) {
	sb.AppendLine(item.Age + " " + item.Name);
}
Console.WriteLine(sb.ToString());

namespace Member
{
	public class Info
	{
		public int Age;
		public string Name;
		public int Order;
	}
}