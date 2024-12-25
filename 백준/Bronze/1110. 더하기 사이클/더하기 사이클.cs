var n = int.Parse(Console.ReadLine()!);

    if (n == 0) Console.WriteLine(1);
    else {
        int lenCycle = 0;
        var num = n;
        while (true) {
            var sumDigits = num / 10 + num % 10;
            num = (num % 10) * 10 + sumDigits % 10;
            lenCycle++;

            if (num == n) break ;
        }

        Console.WriteLine(lenCycle);
    }