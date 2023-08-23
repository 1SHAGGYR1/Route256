var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
var usersCount = input[0];
var friendsLists = Enumerable.Range(1, usersCount).Select(_ => new List<int>(5)).ToArray();

var pairsCount = input[1];
for (var i = 0; i < pairsCount; i++)
{
    var pair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    friendsLists[pair[0] - 1].Add(pair[1] - 1);
    friendsLists[pair[1] - 1].Add(pair[0] - 1);
}

var possibleFriends = new Dictionary<int, Dictionary<int, int>>(usersCount);
for (var i = 0; i < usersCount; i++)
{
    foreach (var friend in friendsLists[i])
    {
        foreach (var other in friendsLists[i].Except(new List<int>{ friend }))
        {
            if (!friendsLists[friend].Contains(other))
            {
                if (!possibleFriends.TryGetValue(friend, out var userPossibleFriends))
                {
                    userPossibleFriends = new Dictionary<int, int>();
                    possibleFriends.Add(friend, userPossibleFriends);
                }
                if (userPossibleFriends.ContainsKey(other))
                {
                    userPossibleFriends[other]++;
                }
                else
                {
                    userPossibleFriends[other] = 1;
                }
            }
        }
    }
}

for (var i = 0; i < usersCount; i++)
{
    if (possibleFriends.TryGetValue(i, out var resultPossibleFriends))
    {
        var maxValue = 0;
        var result = new SortedSet<int>();
        foreach (var pair in resultPossibleFriends)
        {
            if (pair.Value > maxValue)
            {
                result.Clear();
                result.Add(pair.Key + 1);
                maxValue = pair.Value;
            } else if (pair.Value == maxValue)
            {
                result.Add(pair.Key + 1);
            }
        }
        Console.WriteLine(string.Join(' ', result));
    }
    else
    {
        Console.WriteLine("0");
    }
}
