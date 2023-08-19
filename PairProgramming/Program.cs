var testsCount = int.Parse(Console.ReadLine());
var ranksDistribution = Enumerable.Range(1, 100).Select(_ => new Queue<int>()).ToArray();
for (var i = 0; i < testsCount; i++)
{
    var developersCount = int.Parse(Console.ReadLine());
    var currentDevNumber = 1;
    var developersRanks = new int[developersCount];
    foreach (var rank in  Console.ReadLine().Split(' ').Select(int.Parse))
    {
        developersRanks[currentDevNumber - 1] = rank;
        ranksDistribution[rank - 1].Enqueue(currentDevNumber++);
    }

    currentDevNumber = 1;
    foreach (var rank in developersRanks)
    {
        if (rank == 0)
        {
            currentDevNumber++;
            continue;
        }

        ranksDistribution[rank - 1].Dequeue();
        developersRanks[currentDevNumber - 1] = 0;
        
        var deviation = 0;
        int? loverRank = rank;
        int? higherRank = rank;
        var lowerRankDevExist = ranksDistribution[rank - 1].TryPeek(out var lowerDevId);
        var higherRankDevExists = ranksDistribution[rank - 1].TryPeek(out var higherDevId);

        while (!(lowerRankDevExist || higherRankDevExists))
        {
            
            deviation++;
            loverRank = rank - deviation > 0 ? rank - deviation : null;
            higherRank = rank + deviation <= 100 ? rank + deviation : null;
            lowerDevId = 0;
            higherDevId = 0;
            lowerRankDevExist = loverRank.HasValue && ranksDistribution[loverRank.Value - 1].TryPeek(out lowerDevId);
            higherRankDevExists = higherRank.HasValue && ranksDistribution[higherRank.Value - 1].TryPeek(out higherDevId);
        }

        if (!lowerRankDevExist)
        {
           Console.WriteLine($"{currentDevNumber++} {ranksDistribution[higherRank!.Value - 1].Dequeue()}");
           developersRanks[higherDevId - 1] = 0;
           continue;
        }

        if (!higherRankDevExists)
        {
            Console.WriteLine($"{currentDevNumber++} {ranksDistribution[loverRank!.Value - 1].Dequeue()}");
            developersRanks[lowerDevId - 1] = 0;
            continue;
        }

        if (lowerDevId < higherDevId)
        {
            Console.WriteLine($"{currentDevNumber++} {ranksDistribution[loverRank!.Value - 1].Dequeue()}");
            developersRanks[lowerDevId - 1] = 0;
        }
        else
        {
            Console.WriteLine($"{currentDevNumber++} {ranksDistribution[higherRank!.Value - 1].Dequeue()}");
            developersRanks[higherDevId - 1] = 0;
        }
    }

    if (i != testsCount - 1)
    {
        Console.WriteLine();
    }
}