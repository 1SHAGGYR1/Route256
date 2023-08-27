using System.Text;

var pr = Console.ReadLine();
var n = int.Parse(Console.ReadLine());
var charArray = pr.ToCharArray();
for (var i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split(' ');
    var start = int.Parse(input[0]) - 1;
    var end = int.Parse(input[1]);
    var content = input[2];
    for (var j = start; j < end; j++)
    {
        charArray[j] = content[j - start];
    }
}
Console.WriteLine(new string(charArray));