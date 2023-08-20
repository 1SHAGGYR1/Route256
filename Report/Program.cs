var testsCount = int.Parse(Console.ReadLine());
for (var i = 0; i < testsCount; i++)
{
    var metReports = new HashSet<int>();
    Console.ReadLine();
    var match = true;
    var previous = 0;
    foreach (var report in Console.ReadLine().Split(' ').Select(int.Parse))
    {
        if (previous != report)
        {
            metReports.Add(previous);
            if (metReports.Contains(report))
            {
                match = false;
                break;
            }
        }

        previous = report;
    }

    Console.WriteLine(match ? "YES" : "NO");
    metReports.Clear();
}