namespace BlackJackSimulation
{

    public class Player : PlayerFunctionality
    {
        public string Name { get; set; }
        public int PowerTotal { get; set; } = 0;
        public bool IsHolding { get; set; } = false;
        public List<Dictionary<string, string>> PlayerHand { get; set; }

        public Player(string name)
        {
            Name = name;
            PlayerHand = new List<Dictionary<string, string>>();
        }

        public bool takeTurn(CardsDeck gameDeck)
        {
            Console.WriteLine($"{Name}'s current total:{PowerTotal}");
            Console.WriteLine($"{Name} to Draw another card press '1', to hold press '2'");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                bool correctRange = DrawCard(gameDeck);
                if (!correctRange)
                {
                    return false;
                }
            }
            else
            {
                IsHolding = true;
                Console.WriteLine($"{Name} holds.");
            }
            return true;
        }


        public bool DrawCard(CardsDeck deck)
        {
            var card = deck.GameDeck[0];
            // need to remove card drawn from deck
            PlayerHand.Add(card);
            deck.GameDeck.Remove(card);
            var cardPowerString = card.Values.ToList()[0];
            var cardPowerKey = card.Keys.ToList()[0];
            Console.WriteLine($"{Name} draws a card..\n it's a {cardPowerString} of {cardPowerKey}");
            PowerTotal += DetermineCardPower(cardPowerString);
            Console.WriteLine($"{Name}'s new total:{PowerTotal}\n");

            if (DetermineBust())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int DetermineCardPower(string cardPower)
        {
            try
            {
                int intCardPower = int.Parse(cardPower);
                return intCardPower;
            }
            catch (FormatException)
            {
                if (cardPower == "Ace")
                {
                    return 10;
                }
                else if (cardPower == "Jack")
                {
                    return 11;
                }
                else if (cardPower == "Queen")
                {
                    return 12;
                }
                else if (cardPower == "King")
                {
                    return 13;
                }

            }
            return -1;
        }

        public bool DetermineBust()
        {
            if (PowerTotal > 21)
            {
                if (PlayerHand.Any(dict => dict.ContainsKey("Ace")))
                {
                    // ace's initial value of 10 gets reduced to 1.
                    PowerTotal -= 9;
                    Console.WriteLine($"You had an ace! Value used as 1, current Player: {Name} total= {PowerTotal}");
                    if (PowerTotal > 21)
                    {
                        Console.WriteLine("Total still larger than 21, bust!");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("You exceeded the value of 21! with your total of: " + PowerTotal);
                    return false;
                }
            }
            return true;
        }

    }
}
