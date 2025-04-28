namespace BlackJackSimulation
{
    public class BlackJack
    {
        // introduce gambling players ? or general mechanics to work with bids through an interface / inheritance ?
        // game deck is provided as a parameter so that players can draw cards
        // ace logic
        public Player P1 { get; set; }
        public Player P2 { get; set; }

        public CardsDeck Deck { get; set; }
        public BlackJack(Player player1, Player player2, CardsDeck gameDeck)
        {
            P1 = player1;
            P2 = player2;
            Deck = gameDeck;
        }

        public void startRound()
        {
            while (true)
            {
                if (P1.IsHolding && P2.IsHolding)
                {
                    Console.WriteLine("Comparing player hands..");
                    if (P1.PowerTotal > P2.PowerTotal)
                    {
                        Console.WriteLine($"{P1.Name} wins! with a {P1.PowerTotal}\n {P2.Name} had a total of {P2.PowerTotal}");
                    }
                    else if (P2.PowerTotal > P1.PowerTotal)
                    {
                        Console.WriteLine($"{P2.Name} wins! with a {P2.PowerTotal}\n {P1.Name} had a total of {P1.PowerTotal}");
                    }
                    else
                    {
                        Console.WriteLine($"Draw both players have a score of {P1.PowerTotal}");
                    }
                    break;
                }

                if (!P1.IsHolding)
                {
                    bool cardRange = P1.takeTurn(Deck);
                    if (!cardRange)
                    {
                        // P1 busted break out of loop
                        Console.WriteLine($"{P2.Name} wins! with a total of {P2.PowerTotal}");
                        break;
                    }

                }
                if (!P2.IsHolding)
                {
                    bool cardRange = P2.takeTurn(Deck);
                    if (!cardRange)
                    {
                        Console.WriteLine($"{P1.Name} wins! with a total of {P1.PowerTotal}");
                        break;
                    }
                }

            }


        }


    }
}
