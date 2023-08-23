var nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
var n = nm[0];
var m = nm[1];

var energyConsumption = Console.ReadLine().Split(' ').Select(uint.Parse).OrderBy(t => t).ToArray();
var busySeconds = new int[n];
var previousTaskStart = 0;
ulong totalConsumption = 0;
for (var i = 0; i < m; i++)
{
    var tl = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    var t = tl[0];
    var l = tl[1];

    var firstNonNegativeIndex = -1;
    for (var j = 0; j < n; j++)
    {
        if (busySeconds[j] > 0)
        {
            busySeconds[j] -= Math.Max(t - previousTaskStart, 0) ;
        }

        if (firstNonNegativeIndex == -1 && busySeconds[j] <= 0)
        {
            firstNonNegativeIndex = j;
        }
    }

    previousTaskStart = t;
    if (firstNonNegativeIndex == -1)
    {
        continue;
    }

    busySeconds[firstNonNegativeIndex] = l;
    totalConsumption += (ulong) l * energyConsumption[firstNonNegativeIndex];
}

Console.WriteLine(totalConsumption);