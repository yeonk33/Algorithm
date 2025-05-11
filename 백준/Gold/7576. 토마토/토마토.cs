using System;
using System.Collections.Generic;
using System.IO;

class Program
{
	static int row, col;
	static int[,] box;
	static bool[,] visited;
	static Queue<(int y, int x)> queue = new Queue<(int, int)>();

	static void Main()
	{
		StreamReader sr = new StreamReader(Console.OpenStandardInput());

		string[] sizes = sr.ReadLine().Split(' ');
		col = Convert.ToInt32(sizes[0]);
		row = Convert.ToInt32(sizes[1]);

		box = new int[row, col];
		visited = new bool[row, col];

		//토마토 담기
		for (int i = 0; i < row; i++) {
			string[] line = sr.ReadLine().Split(' ');
			for (int j = 0; j < col; j++) {
				box[i, j] = Convert.ToInt32(line[j]);
				if (box[i, j] == 1) {
					queue.Enqueue((i, j));
					visited[i, j] = true;
				}
			}
		}

		int result = BFS();

		// 안익은거 있으면 -1
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				if (box[i, j] == 0) {
					result = -1;
					break;
				}
			}
		}

		Console.WriteLine(result);
	}

	static int BFS()
	{
		int[] dr = { -1, 1, 0, 0 };
		int[] dc = { 0, 0, -1, 1 };
		int day = -1;

		while (queue.Count > 0) {
			int count = queue.Count;
			day++;

			for (int c = 0; c < count; c++) {
				var (y, x) = queue.Dequeue();

				for (int i = 0; i < 4; i++) {
					int ny = y + dr[i];
					int nx = x + dc[i];

					if (ny >= 0 && ny < row && nx >= 0 && nx < col) {
						if (!visited[ny, nx] && box[ny, nx] == 0) {
							visited[ny, nx] = true;
							box[ny, nx] = 1;
							queue.Enqueue((ny, nx));
						}
					}
				}
			}
		}

		return day;
	}
}
