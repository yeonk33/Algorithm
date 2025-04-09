using System.Collections;
using System.Text;
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

int[] NM = Array.ConvertAll((sr.ReadLine().Split(' ')), int.Parse);
int N = NM[0];
int M = NM[1];
Hashtable hashtable = new Hashtable();
string name;
List<string> answers = new List<string>();
for (int i = 0; i < N; i++) {   // 듣도 못한 사람 해시테이블에 저장
	name = sr.ReadLine();
	hashtable.Add(name, name);
}
for (int i = 0; i < M; i++) {   // 보도 못한 사람 입력 받으며 중복 찾기
	name = sr.ReadLine();
	if (hashtable.ContainsKey(name)) {
		answers.Add(name);
	}
}
answers.Sort();
sb.AppendLine(answers.Count.ToString());
foreach (var item in answers) {
	sb.AppendLine(item);
}
Console.WriteLine(sb.ToString());
