var testsCount = int.Parse(Console.ReadLine());
for (var i = 0; i < testsCount; i++)
{
    Console.ReadLine();
    var nm = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
    var n = nm.First();
    var m = nm.Last();
    var firstRow = new TableRow(m);
    var row = firstRow;
    for (var rowNumber = 0; rowNumber < n; rowNumber++)
    {
        row.Row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        if (rowNumber < n - 1)
        {
            row.Next = new TableRow(m);
            row = row.Next;
        }
    }

    Console.ReadLine();
    foreach (var columnId in Console.ReadLine().Split(' ').Select(int.Parse))
    {
        firstRow = OrderByColumnId(firstRow, columnId - 1);
    }

    PrintTable(firstRow);
}

TableRow OrderByColumnId(TableRow head, int columnId)
{
    if (head?.Next == null)
    {
        return head;
    }
    
    TableRow prev = head, slow = head, fast = head;
    while (fast?.Next != null)
    {
        prev = slow;
        slow = slow.Next;
        fast = fast.Next.Next;
    }

    prev.Next = null;
    
    var left = OrderByColumnId(head, columnId);
    var right = OrderByColumnId(slow, columnId);

    return Merge(left, right, columnId);
}

TableRow Merge(TableRow row1, TableRow row2, int columnId)
{
    TableRow temp = new(0), result = temp;
    while (row1 is not null && row2 is not null)
    {
        if (row1.Row[columnId] <= row2.Row[columnId])
        {
            temp.Next = row1;
            row1 = row1.Next;
        }
        else
        {
            temp.Next = row2;
            row2 = row2.Next;
        }

        temp = temp.Next;
    }

    if (row1 is null)
    {
        temp.Next = row2;
    }
    
    if (row2 is null)
    {
        temp.Next = row1;
    }

    return result.Next;
}

void PrintTable(TableRow tableRow)
{
    while (tableRow is not null)
    {
        Console.WriteLine(string.Join(' ', tableRow.Row));
        tableRow = tableRow.Next;
    }
}

public class TableRow
{
    public TableRow(int rowLenght)
    {
        Row = new int[rowLenght];
    }
    
    public int[] Row { get; set; }

    public TableRow Next { get; set; }
}