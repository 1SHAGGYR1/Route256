var testsCount = int.Parse(Console.ReadLine());

for (var test = 0; test < testsCount; test++)
{
    var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    var n = input[0];
    var m = input[1] % 2 == 0 ? input[1] / 2 : input[1] / 2 + 1;
    var map = new char[n, m];
    var unseen = new bool[n, m];
    var regions = new HashSet<char>();
    for (var i = 0; i < n; i++)
    {
        var row = Console.ReadLine().Trim('.').Split('.').Select(char.Parse);
        var j = 0;
        foreach (var region in row)
        {
            map[i, j] = region;
            unseen[i, j++] = true;
            regions.Add(region);
        }
    }

    var actualRegionsCount = CountRegions(map, unseen, n, m);
    Console.WriteLine(actualRegionsCount == regions.Count ? "YES" : "NO");
}

int CountRegions(char[,] map, bool[,] unseen, int n, int m)
{
    var result = 0;
    for (var i = 0; i < n; i++)
    {
        for (var j = 0; j < m; j++)
        {
            if (ByPassCurrentRegion(map, unseen, i, j, map[i, j], n, m))
            {
                result++;
            }
        }
    }

    return result;
}

bool ByPassCurrentRegion(char[,] map, bool[,] unseen, int i, int j, char region, int n, int m)
{
    if (i < 0 || i >= n || j < 0 || j >= m ||
        region == default || 
        !unseen[i,j] ||
        map[i, j] != region)
    {
        return false;
    }

    unseen[i, j] = false;
    ByPassCurrentRegion(map, unseen, i - 1, j, map[i, j], n, m);
    ByPassCurrentRegion(map, unseen, i + 1, j, map[i, j], n, m);
    ByPassCurrentRegion(map, unseen, i, j - 1, map[i, j], n, m);
    ByPassCurrentRegion(map, unseen, i, j + 1, map[i, j], n, m);
    if (i % 2 == 0)
    {
        ByPassCurrentRegion(map, unseen, i - 1, j - 1, map[i, j], n, m);
        ByPassCurrentRegion(map, unseen, i + 1, j - 1, map[i, j], n, m);
    }
    else
    {
        ByPassCurrentRegion(map, unseen, i - 1, j + 1, map[i, j], n, m);
        ByPassCurrentRegion(map, unseen, i + 1, j + 1, map[i, j], n, m);
    }

    return true;
}

