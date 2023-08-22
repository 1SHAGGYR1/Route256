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
        if (friendsLists[friend].Contains())
    }
    var friendsOfI = new List<int>();
}
