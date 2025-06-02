public class Shark
    {
        int y, x;
        int exp, size, time;
        public Shark((int, int) position, int remainTime = 0)
        {
            exp = 0;
            size = 2;
            time = remainTime;
            (y, x) = position;
        }
        // 새로운 위치에 객체 복사 생성, 시간 갱신
        public Shark((int, int) position, Shark another)
        {
            (y, x) = position;
            exp = another.Exp;
            size = another.Size;
            time = another.Time + 1;
        }
        public int Exp { get { return exp; } }
        public int Size { get { return size; } }
        public int Time { get { return time; } }
        public (int, int) Pos
        {
            get { return (y, x); }
            set { (y, x) = value; }
        }
        // 경험치를 올리는데, 크기와 같으면 크기 추가
        public void AddExp()
        {
            exp++;
            if(exp == size)
            {
                exp = 0;
                size++;
            }
        }
    }
    internal class Program
    {
        static readonly int[] dx = { 0, -1, 0, 1 };
        static readonly int[] dy = { -1, 0, 1, 0 };

        static int n;
        static int[,] grid;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine()!);
            grid = new int[n, n];

            var shark = new Shark((0, 0));
            for(int i = 0; i < n; i++)
            {
                var input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                for(int j = 0; j < n; j++)
                {
                    grid[i, j] = input[j];
                    if (grid[i, j] == 9)
                    {
                        shark.Pos = (i, j);
                        grid[i, j] = 0;
                    }
                }
            }
            var answer = 0;
            while(true)
            {
                // BFS로 먹을 수 있는 모든 물고기 탐색
                var sharks = BFS(shark);
                // 먹을 물고기가 없으면 탈출
                if (sharks.Count == 0) 
                    break;

                // Time 순으로 계산하고, 제일 시간이 적은 경우들만 남기기
                sharks.Sort((a, b) => a.Time.CompareTo(b.Time));
                var minTime = sharks.First().Time;
                sharks = sharks.Where(x => x.Time == minTime).ToList();

                // Time이 같은 경우를 y, x가 가장 적은 경우로 정렬하고 첫번째 요소 선택
                shark = sharks.OrderBy(s => s.Pos.Item1).ThenBy(s => s.Pos.Item2).First();
                // 해당 경우의 시간으로 갱신 + 물고기 먹은 처리
                answer = shark.Time;
                grid[shark.Pos.Item1, shark.Pos.Item2] = 0;
                shark.AddExp();
            }
            Console.WriteLine(answer);
        }
        static List<Shark> BFS(Shark shark)
        {
            var sharks = new List<Shark>();
            var visited = new bool[n, n];
            var q = new Queue<Shark>();
            visited[shark.Pos.Item1, shark.Pos.Item2] = true;
            q.Enqueue(shark);
            while (q.Count > 0)
            {
                var curShark = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    var (curY, curX) = (curShark.Pos.Item1 + dy[i], curShark.Pos.Item2 + dx[i]);
                    if (curY >= 0 && curY < n && curX >= 0 && curX < n)
                    {
                        if (visited[curY, curX]) continue;
                        if (curShark.Size < grid[curY, curX]) continue;

                        visited[curY, curX] = true;
                        var newShark = new Shark((curY, curX), curShark);
                        if (curShark.Size == grid[curY, curX] || grid[curY, curX] == 0)
                        {
                            q.Enqueue(newShark);
                        }
                        // 먹을 수 있는 경우 따로 처리
                        else if(curShark.Size > grid[curY, curX])
                        {
                            sharks.Add(newShark);
                        }
                    }
                }
            }
            return sharks;
        }
    }