var nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
var n = nm[0];
var m = nm[1];

var energyConsumption = Console.ReadLine().Split(' ').Select(uint.Parse).OrderBy(t => t).ToArray();
var previousTasksStartUpdate = new int[n];
var busySeconds = new int[n];
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
            busySeconds[j] -= Math.Max(t - previousTasksStartUpdate[j], 0);
            previousTasksStartUpdate[j] = t;
        }

        if (busySeconds[j] <= 0)
        {
            firstNonNegativeIndex = j;
            break;
        }
    }

    if (firstNonNegativeIndex == -1)
    {
        continue;
    }

    busySeconds[firstNonNegativeIndex] = l;
    previousTasksStartUpdate[firstNonNegativeIndex] = t;
    totalConsumption += (ulong) l * energyConsumption[firstNonNegativeIndex];
}

Console.WriteLine(totalConsumption);