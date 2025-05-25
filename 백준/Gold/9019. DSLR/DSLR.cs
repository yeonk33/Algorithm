int T = int.Parse(Console.ReadLine());

for (int i = 0; i < T; i++) {
    string[] input = Console.ReadLine().Split();
    int A = int.Parse(input[0]);
    int B = int.Parse(input[1]);

    string result = BFS(A, B);
    Console.WriteLine(result);
}

string BFS(int A, int B) 
{
    bool[] visited = new bool[10000];
    Queue<(int num, string ops)> queue = new Queue<(int, string)>();

    queue.Enqueue((A, ""));
    visited[A] = true;

    while (queue.Count > 0) {
        var (current, ops) = queue.Dequeue();

        if (current == B) return ops;

        // D
        int d = (current * 2) % 10000;
        if (!visited[d]) {
            visited[d] = true;
            queue.Enqueue((d, ops + "D"));
        }

        // S
        int s = current == 0 ? 9999 : current - 1;
        if (!visited[s]) {
            visited[s] = true;
            queue.Enqueue((s, ops + "S"));
        }

        // L
        int l = (current % 1000) * 10 + (current / 1000);
        if (!visited[l]) {
            visited[l] = true;
            queue.Enqueue((l, ops + "L"));
        }

        // R
        int r = (current % 10) * 1000 + (current / 10);
        if (!visited[r]) {
            visited[r] = true;
            queue.Enqueue((r, ops + "R"));
        }
    }

    return "";
}