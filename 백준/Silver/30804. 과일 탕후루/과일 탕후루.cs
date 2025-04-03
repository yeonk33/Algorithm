using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int[] fruits = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

		int l = 0;
		int r = 0;
		int maxLen = 0;
		Dictionary<int, int> fruitCount = new Dictionary<int, int>();

		while (r < N) {
			if (fruitCount.ContainsKey(fruits[r]))
				fruitCount[fruits[r]]++;
			else
				fruitCount[fruits[r]] = 1;

			while (fruitCount.Count > 2) {
				fruitCount[fruits[l]]--;
				if (fruitCount[fruits[l]] == 0)
					fruitCount.Remove(fruits[l]);
				l++;
			}

			maxLen = Math.Max(maxLen, r - l + 1);
			r++;
		}

		Console.WriteLine(maxLen);
	}
}
