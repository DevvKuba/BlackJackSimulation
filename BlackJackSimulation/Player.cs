namespace BlackJackSimulation
{

    public class Player : PlayerFunctionality
    {
        public string Name { get; set; }
        public int PowerTotal { get; set; } = 0;
        public List<Dictionary<string, string>> PlayerHand { get; set; }

        public Player(string name)
        {
            Name = name;
            PlayerHand = new List<Dictionary<string, string>>();
        }

        public void DrawCard(CardsDeck deck)
        {
            var card = deck.GameDeck[0];
            var cardPowerList = card.Values.ToList();
            string cardPowerString = cardPowerList[0]; ;
            PowerTotal += DetermineCardPower(cardPowerString);
            Console.WriteLine(PowerTotal);

            PlayerHand.Add(card);
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
                    return 1;
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
    }
}
