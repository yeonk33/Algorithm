using System.Linq;
int c = Convert.ToInt32(Console.ReadLine());
string[] results = new string[c];
for (int i = 0; i < c; i++) {
    List<int> cases = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
    int n = cases[0];
    cases.RemoveAt(0);
    double avg = cases.Average();
    double upper = cases.Where(x => x > avg).Count();
    results[i] = (upper/n*100).ToString("F3")+"%";
}
System.Console.WriteLine(string.Join("\n", results));