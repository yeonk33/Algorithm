StreamReader reader = new StreamReader(Console.OpenStandardInput());
int count = Convert.ToInt32(reader.ReadLine());
int[] ints = new int[10001];
for (int i = 0; i < count; i++) {
	ints[Convert.ToInt32(reader.ReadLine())]++;
}
using (StreamWriter writer = new StreamWriter(Console.OpenStandardOutput()))
{
	for (int i = 0; i < ints.Length; i++)
	{
		if (ints[i] != 0)
		{
			for (int j = 0; j < ints[i]; j++)
			{
				writer.WriteLine(i);
			}
		}
	}

}