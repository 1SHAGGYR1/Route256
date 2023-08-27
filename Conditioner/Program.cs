var testsCount = int.Parse(Console.ReadLine());
for (var i = 0; i < testsCount; i++)
{
    var n = int.Parse(Console.ReadLine());
    var lowest = 15;
    var highest = 30;
    for (var j = 0; j < n; j++)
    {
        var input = Console.ReadLine().Split(' ');
        var tempRequest = int.Parse(input[1]);
        if (input[0].First() == '>')
        {
            if (tempRequest > lowest)
            {
                lowest = tempRequest;
            }
        }
        else
        {
            if (tempRequest < highest)
            {
                highest = tempRequest;
            }
        }
        Console.WriteLine(highest >= lowest ? highest : -1);
    }

    Console.WriteLine();
}