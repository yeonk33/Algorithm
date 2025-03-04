using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
int[] lengths;
int hypotenuse, width, height;

foreach (var item in inputs) {
	lengths = Array.ConvertAll(item.Split(' '), int.Parse);
	
	if (lengths[0] == 0 && lengths[1] == 0 && lengths[2] == 0) break;

	Array.Sort(lengths);
	width = lengths[0];
	height = lengths[1];
	hypotenuse = lengths[2];

	if (Math.Pow(hypotenuse, 2) == Math.Pow(width, 2) + Math.Pow(height, 2))
		sb.AppendLine("right");
	else
		sb.AppendLine("wrong");
}

Console.WriteLine(sb.ToString());

/* 사용법
 * string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
 * 예제 복붙하고 엔터로 빈 줄 만든담에 컨Z하고 엔터
 */
string[] InputsToStringArray(string allInput)
{
	return allInput.Replace("\r", "").Split('\n');
}