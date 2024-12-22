int inputNum = Convert.ToInt32(Console.ReadLine());
float[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), item => float.Parse(item));

float M = scores.Max();
for (int i = 0; i < scores.Length; i++) {
    scores[i] = scores[i] / M * 100;
}
Console.WriteLine(scores.Average());