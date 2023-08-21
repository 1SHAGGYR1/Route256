var testsCount = int.Parse(Console.ReadLine());

for (var i = 0; i < testsCount; i++)
{
    var isValid = true;
    var segmentsCount = int.Parse(Console.ReadLine());
    var sortedSegments = new List<TimeSegment>(segmentsCount);
    for (var j = 0; j < segmentsCount; j++)
    {
        var inputs = Console.ReadLine().Split('-');
        if (!TimeOnly.TryParseExact(inputs[0], "HH:mm:ss", out var left))
        {
            isValid = false;
        }
        
        if (!TimeOnly.TryParseExact(inputs[1], "HH:mm:ss", out var right))
        {
            isValid = false;
        }

        if (left > right)
        {
            isValid = false;
        }

        if (!isValid)
        {
            continue;
        }
        
        var position = 0;
        using var enumerator = sortedSegments.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var candidate = enumerator.Current;
            if (left > candidate.Finish)
            {
                position++;
            }
            else
            {
                if (right >= candidate.Start)
                {
                    isValid = false;
                }
                break;
            }
        }

        if (isValid)
        {
            sortedSegments.Insert(position, new TimeSegment(left, right));
        }
    }

    Console.WriteLine(isValid ? "YES" : "NO");
}

public class TimeSegment
{
    public TimeSegment(TimeOnly start, TimeOnly finish)
    {
        Start = start;
        Finish = finish;
    }

    public TimeOnly Start { get; set; }
    
    public TimeOnly Finish { get; set; }
}
