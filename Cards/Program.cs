var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
int n = input[0], m = input[1];
var friendsCards = new SortedDictionary<int, List<int>>();
var result = new int[n];
var i = 0;
foreach (var friendCard in Console.ReadLine().Split(' ').Select(int.Parse))
{
    if (!friendsCards.TryGetValue(friendCard, out var list))
    {
        list = new List<int>();
        friendsCards.Add(friendCard, list);
    }
    list.Add(i++);
}

var pairs = friendsCards.ToList();
var success = true;
for (i = pairs.Count - 1; i >=0 ; i--)
{

    foreach (var index in pairs[i].Value)
    {
        if (pairs[i].Key >= m)
        {
            success = false;
            break;
        }
        result[index] = m--;
    }
}

Console.WriteLine(success ? string.Join(' ', result) : "-1");