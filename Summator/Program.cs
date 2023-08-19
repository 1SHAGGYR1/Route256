var inputRows = int.Parse(Console.ReadLine());
for (var i = 0; i < inputRows; i++)
{
    var input = Console.ReadLine();
    Console.WriteLine(input.Split(' ').Select(int.Parse).Sum());
}