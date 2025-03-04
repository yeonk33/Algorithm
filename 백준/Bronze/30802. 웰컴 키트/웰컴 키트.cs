using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
int N = int.Parse(inputs[0]);
int[] sizes = Array.ConvertAll(inputs[1].Split(' '), int.Parse);
int[] bundles = Array.ConvertAll(inputs[2].Split(' '), int.Parse);
int T = bundles[0];
int P = bundles[1];

int shirt = sizes.Sum(size => (size + T - 1) / T);
sb.AppendLine(shirt.ToString());

int pen = N / P;
int remainPen = N % P;
sb.AppendLine($"{pen} {remainPen}");

Console.WriteLine(sb.ToString());

/* 사용법
 * string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
 * 예제 복붙하고 엔터로 빈 줄 만든담에 컨Z하고 엔터
 */
string[] InputsToStringArray(string allInput)
{
	return allInput.Replace("\r", "").Split('\n');
}