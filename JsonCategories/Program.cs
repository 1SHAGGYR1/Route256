using System.Text;
using System.Text.Json;

var result = new StringBuilder("[");
var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, MaxDepth = 1000 };
var testsCount = int.Parse(Console.ReadLine());
for (var testNum = 0; testNum < testsCount; testNum++)
{
    var input = new StringBuilder();
    var n = int.Parse(Console.ReadLine());
    for (var i = 0; i < n; i++)
    {
        input.AppendLine(Console.ReadLine());
    }

    var jsonString = input.ToString();
    var deserialized = JsonSerializer.Deserialize<List<Category>>(jsonString, options);

    var categoriesDict = new Dictionary<uint, OutputCategory>();
    var parentsDict = new Dictionary<uint, List<uint>>();
    uint parentId = 0;
    foreach (var item in deserialized)
    {
        categoriesDict[item.Id] = ToOutput(item);

        if (item.Parent.HasValue)
        {
            if (!parentsDict.TryGetValue(item.Parent.Value, out var list))
            {
                list = new List<uint>();
                parentsDict[item.Parent.Value] = list;
            }
            list.Add(item.Id);
        }
        else
        {
            parentId = item.Id;
        }
    }
    SetChildren(categoriesDict, parentsDict);
    result.Append(JsonSerializer.Serialize(categoriesDict[parentId], options));
    if (testNum < testsCount - 1)
    {
        result.AppendLine(",");
    }
}

result.Append("]");
Console.WriteLine(result.ToString());

OutputCategory ToOutput(Category model) => new() {Id = model.Id, Name = model.Name, Next = new List<OutputCategory>()};

void SetChildren(Dictionary<uint, OutputCategory> result, Dictionary<uint, List<uint>> parents)
{
    foreach (var pair in parents)
    {
        foreach (var child in pair.Value)
        {
            result[pair.Key].Next.Add(result[child]);
        }
    }
}

class Category
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public uint? Parent { get; set; }
}

class OutputCategory
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public List<OutputCategory> Next { get; set; }
}