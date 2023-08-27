var testsCount = int.Parse(Console.ReadLine());
for (var t = 0; t < testsCount; t++)
{
    var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    int k = input[0], n = input[1], m = input[2];
    var map = new char[n, m];

    for (var x = 0; x < k; x++)
    {
        for (var i = 0; i < n; i++)
        {
            var j = 0;
            foreach (var symbol in Console.ReadLine())
            {
                if (map[i, j] == default || map[i, j] == '.')
                {
                    map[i, j] = symbol;
                }
                j++;
            }
        }

        if (x < k-1)
        {
            Console.ReadLine();
        }
    }

    for (var i = 0; i < n; i++)
    {
        for (var j = 0; j < m; j++)
        {
            Console.Write(map[i,j]);            
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}