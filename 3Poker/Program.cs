internal class Program
{
    private static readonly CardValComparer comparer = new();
    
    private static char[] Suits = {'S', 'C', 'D', 'H'};

    public static void Main(string[] args)
    {
        var testsCount = int.Parse(Console.ReadLine());
        for (var test = 0; test < testsCount; test++)
        {
            var n = int.Parse(Console.ReadLine());
            var winningCards = new List<string>(52 - n * 2);
            var playersCards = new List<string>[n];
            var deck = GenerateCards();
            for (var i = 0; i < n; i++)
            {
                var playerCards = Console.ReadLine().Split(' ').ToList();
                deck.Remove(playerCards[0]);
                deck.Remove(playerCards[1]);
                playersCards[i] = new List<string>(playerCards);
            }
            
            foreach (var card in deck)
            {
                var isWinner = true;
                var myCombination = new Combination(new List<string>{ card, playersCards[0][0], playersCards[0][1]});

                for (var i = 1; i < playersCards.Length; i++)
                {
                    var combination =  new Combination(new List<string> {card, playersCards[i][0], playersCards[i][1]});
                    if (combination.CompareTo(myCombination) > 0)
                    {
                        isWinner = false;
                        break;
                    }
                }

                if (isWinner)
                {
                    winningCards.Add(card);
                }
            }

            Console.WriteLine(winningCards.Count);
            if (winningCards.Count == 0) continue;
            foreach (var winningCard in winningCards)
            {
                Console.WriteLine(winningCard);
            }
        }
    }
    
    static HashSet<string> GenerateCards()
    {
        var result = new HashSet<string>();
        foreach (var cardVal in CardValComparer.CardVals)
        {
            foreach (var suit in Suits)
            {
                result.Add(new string(new[] {cardVal, suit}));
            }
        }

        return result;
    }

    class CardValComparer : IComparer<char>
    {
        public static readonly char[] CardVals = {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A',};

        public int Compare(char x, char y)
        {
            var xIndex = Array.IndexOf(CardVals, x);
            var yIndex = Array.IndexOf(CardVals, y);
            return xIndex.CompareTo(yIndex);
        }
    }

    class Combination : IComparable<Combination>
    {
        public Combination(List<string> cards)
        {
            var cardVals = cards
                .Select(card => card.First())
                .GroupBy(c => c)
                .Select(g => new {g.Key, Count = g.Count()})
                .OrderByDescending(x => x.Count)
                .ThenByDescending(x => x.Key, comparer)
                .First();
            Type = (Type) cardVals.Count;
            Value = cardVals.Key;
        }

        public Type Type { get; set; }

        public char Value { get; set; }

        public int CompareTo(Combination? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var typeComparison = Type.CompareTo(other.Type);
            return typeComparison != 0 ? typeComparison : comparer.Compare(Value, other.Value);
        }
    }

    enum Type
    {
        HighCard = 1,
        Pair,
        Set
    }
}