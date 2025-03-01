using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int[] cases = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
Dictionary<int, string> pokedex = new Dictionary<int, string>();
Dictionary<string, int> pokedexR = new Dictionary<string, int>();
for (int i = 0; i < cases[0]; i++) {
	pokedex.Add(i, inputs[i]);
	pokedexR.Add(inputs[i], i);
}
for (int i = cases[0]; i < cases[0]+cases[1]; i++) {
	if (int.TryParse(inputs[i], out int num)) {
		sb.AppendLine(pokedex[num - 1]);
	} else {
		sb.AppendLine((pokedexR[inputs[i]] + 1).ToString());
	}
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