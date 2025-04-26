namespace BlackJackSimulation
{
    public class Card
    {
        Random random = new Random();

        List<string> cardSuits = new List<string>
        {
            "Spades",
            "Hearts",
            "Diamonds",
            "Clubs",
        };

        List<int> cardNums = Enumerable.Range(1, 13).ToList();

        public Dictionary<string, string> CardDict { get; set; }

        public string CardSuit { get; set; }
        public int CardNum { get; set; }
        public string CardPower { get; set; }


        public Card()
        {
            CardSuit = cardSuits[random.Next(cardSuits.Count)];
            CardNum = random.Next(1, cardNums.Count + 1);

            // calculate power
            if (CardNum > 1 && CardNum < 11)
            {
                // 2-10 count as regular powers
                CardPower = CardNum.ToString();
            }
            else if (CardNum == 1)
            {
                CardPower = "Ace";
            }
            else if (CardNum == 11)
            {
                CardPower = "Jack";
            }
            else if (CardNum == 12)
            {
                CardPower = "Queen";
            }
            else if (CardNum == 13)
            {
                CardPower = "King";
            }


            CardDict = new Dictionary<string, string> { [CardSuit] = CardPower };



        }
    }
}
