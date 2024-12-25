string inputStr = Console.ReadLine().ToLower();

int[] alphabets = new int[26];
foreach (char c in inputStr){
    alphabets[(c - 'a')] +=  1;
}
int maxVal = -1;
List<int> maxs = new List<int>();
for (int i = 0; i < alphabets.Length; i++) {
    if (alphabets[i] > maxVal) {
        maxVal = alphabets[i];
        maxs.Clear();
        maxs.Add(i);
    }
    else if (alphabets[i] == maxVal) {
        maxs.Add(i);
    }
}
if (maxs.Count > 1) {
    System.Console.WriteLine("?");
} else {
    System.Console.WriteLine((char)(maxs[0]+'A'));
}