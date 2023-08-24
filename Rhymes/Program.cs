var wordsCount = int.Parse(Console.ReadLine());
var trie = new Trie(26);
for (var i = 0; i < wordsCount; i++)
{
    var word = Console.ReadLine();
    trie.AddWord(word, word.Length - 1);
}

var queriesCount = int.Parse(Console.ReadLine());
for (var i = 0; i < queriesCount; i++)
{
    var query = Console.ReadLine();
    Console.WriteLine(trie.FindClosestRhyme(query, query.Length - 1));
}

public class Trie
{
    private Trie[] Next { get; set; }

    private List<string> Words { get; set; }
    
    public Trie(int alphabetSize)
    {
        Next = new Trie[alphabetSize];
        Words = new List<string>();
    }

    public void AddWord(string word, int i)
    {
        Words.Add(word);
        if (i < 0)
        {
            return;
        }
        
        var letterIndex = word[i] - 'a';
        var next = Next[letterIndex] ??= new Trie(26);
        next.AddWord(word, --i);
    }

    public string FindClosestRhyme(string word, int i)
    {
        if (i < 0)
        {
            return Words.First(w => w != word);
        }
        
        var letterIndex = word[i] - 'a';
        var next = Next[letterIndex];
        if (next is null || next.Words.Count == 1 && next.Words.First() == word)
        {
            return Words.First(w => w != word);
        }

        return next.FindClosestRhyme(word, --i);
    }
}