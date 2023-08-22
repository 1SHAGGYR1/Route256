var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
var usersCount = input[0];
var pairsCount = input[1];
var friendsGraph = new int[usersCount, usersCount];

for (var i = 0; i < pairsCount; i++)
{
    var pair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    friendsGraph[pair[0] - 1, pair[1] - 1] = -1;
}

for (var i = 0; i < usersCount; i++)
{
    var friendsOfI = new List<int>();
    for (var j = 0; j < usersCount; j++)
    {
        if (friendsGraph[i, j] == -1)
        {
            friendsOfI.Add(j);
        }
    }
}
