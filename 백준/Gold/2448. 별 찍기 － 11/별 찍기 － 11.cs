using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());

char[,] star = new char[n, 2 * n - 1];
for (int i = 0; i < n; i++)
    for (int j = 0; j < 2 * n - 1; j++)
        star[i, j] = ' ';

DrawStar(0, n - 1, n);

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < 2 * n - 1; j++)
        sb.Append(star[i, j]);
    sb.AppendLine();
}

Console.WriteLine(sb.ToString());
sb.Clear();

void DrawStar(int x, int y, int size)
{
    // 삼각형의 최소 단위 (높이 3짜리 삼각형 그리기)
    if (size == 3)
    {
        star[x, y] = '*';
        star[x + 1, y - 1] = '*';
        star[x + 1, y + 1] = '*';
        for (int i = -2; i <= 2; i++)
            star[x + 2, y + i] = '*';
    }
    else
    {
        int half = size / 2;

        // 위쪽 삼각형
        DrawStar(x, y, half);

        // 아래 왼쪽 삼각형
        DrawStar(x + half, y - half, half);

        // 아래 오른쪽 삼각형
        DrawStar(x + half, y + half, half);
    }
}

