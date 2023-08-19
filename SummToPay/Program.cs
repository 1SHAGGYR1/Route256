var testCount = int.Parse(Console.ReadLine());
var pricesDictionary = new Dictionary<int, int>();
for (var i = 0; i < testCount; i++)
{
    Console.ReadLine();
    foreach (var price in Console.ReadLine().Split(' ').Select(int.Parse))
    {
        if (pricesDictionary.ContainsKey(price))
        {
            pricesDictionary[price]++;
        }
        else
        {
            pricesDictionary.Add(price, 1);
        }
    }

    Console.WriteLine(pricesDictionary.Sum(pair => pair.Key * (pair.Value - pair.Value / 3)));
    pricesDictionary.Clear();
}