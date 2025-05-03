namespace BlackJackSimulation
{
    public class BlackJack
    {

        public CardsDeck Deck { get; set; }

        public Player P1 { get; set; }
        public Player P2 { get; set; }
        public BlackJack(Player player1, Player player2, CardsDeck gameDeck)
        {
            P1 = player1;
            P2 = player2;
            Deck = gameDeck;
        }

        public void startRound()
        {
            if (P1 is Gambler gambler1 && P2 is Gambler gambler2)
            {
                bool gambler1Bet = gambler1.PlaceBet();
                bool gambler2Bet = gambler2.PlaceBet();

                if (gambler1Bet && gambler2Bet)
                {
                    startBettingGame(gambler1, gambler2);
                }
                Console.WriteLine("Game Over");
            }
            else if (P1 is Player player1 && P2 is Player player2)
            {
                startRegularGame(player1, player2);
            }

            // make sure players totals and hand are reset
            GetReadyForRound();

            // another round logic
            ContinuePlaying();
        }

        public void startRegularGame(Player p1, Player p2)
        {
            while (true)
            {
                if (p1.IsHolding && p2.IsHolding)
                {
                    Console.WriteLine("Comparing player hands..");
                    if (p1.PowerTotal > p2.PowerTotal)
                    {

                        Console.WriteLine($"{p1.Name} wins! with a {p1.PowerTotal}\n {p2.Name} had a total of {p2.PowerTotal}");
                    }
                    else if (p2.PowerTotal > p1.PowerTotal)
                    {
                        Console.WriteLine($"{p2.Name} wins! with a {p2.PowerTotal}\n {p1.Name} had a total of {p1.PowerTotal}");
                    }
                    else
                    {
                        Console.WriteLine($"Draw both players have a score of {p1.PowerTotal}");
                    }
                    break;
                }

                if (!p1.IsHolding)
                {
                    bool cardRange = p1.TakeTurn(Deck);
                    if (!cardRange)
                    {
                        // P1 busted break out of loop
                        Console.WriteLine($"{p2.Name} wins! with a total of {p2.PowerTotal}");
                        break;
                    }

                }
                if (!p2.IsHolding)
                {
                    bool cardRange = p2.TakeTurn(Deck);
                    if (!cardRange)
                    {
                        Console.WriteLine($"{p1.Name} wins! with a total of {p1.PowerTotal}");
                        break;
                    }
                }

            }
        }

        public void startBettingGame(Gambler p1, Gambler p2)
        {
            while (true)
            {
                if (p1.IsHolding && p2.IsHolding)
                {
                    Console.WriteLine("Comparing player hands..");
                    if (p1.PowerTotal > p2.PowerTotal)
                    {
                        p1.GatherEarningsFrom(p2);
                        Console.WriteLine($"{p1.Name} wins! with a {p1.PowerTotal}\n {p2.Name} had a total of {p2.PowerTotal}");
                        Console.WriteLine($"{p1.Name} now wins ${p1.BetAmount + p2.BetAmount}\n new balance: {p1.Balance}");
                    }
                    else if (p2.PowerTotal > p1.PowerTotal)
                    {
                        p2.GatherEarningsFrom(p1);
                        Console.WriteLine($"{p2.Name} wins! with a {p2.PowerTotal}\n {p1.Name} had a total of {p1.PowerTotal}");
                        Console.WriteLine($"{p2.Name} now wins ${p1.BetAmount + p2.BetAmount}\n new balance: {p2.Balance}");

                    }
                    else
                    {
                        Console.WriteLine($"Draw both players have a score of {p1.PowerTotal}");

                    }
                    break;
                }

                if (!p1.IsHolding)
                {
                    bool cardRange = p1.TakeTurn(Deck);
                    if (!cardRange)
                    {
                        p2.GatherEarningsFrom(p1);
                        Console.WriteLine($"{p2.Name} wins! with a total of {p2.PowerTotal}\n new balance: {p2.Balance}");
                        break;
                    }

                }
                if (!p2.IsHolding)
                {
                    bool cardRange = p2.TakeTurn(Deck);
                    if (!cardRange)
                    {
                        p1.GatherEarningsFrom(p2);
                        Console.WriteLine($"{p1.Name} wins! with a total of {p1.PowerTotal}\n new balance: {p1.Balance}");
                        break;
                    }
                }


            }
        }


        public void ContinuePlaying()
        {
            Console.WriteLine($"{P1.Name}, would you like to play another round? '1' for yes '2' for no");
            int p1Input = int.Parse(Console.ReadLine());
            Console.WriteLine($"{P2.Name}, would you like to play another round? '1' for yes '2' for no");
            int p2Input = int.Parse(Console.ReadLine());
            if (p1Input == 1 && p2Input == 1)
            {
                startRound();
            }
        }

        public void GetReadyForRound()
        {

            P1.PowerTotal = 0;
            P2.PowerTotal = 0;
            P1.PlayerHand.Clear();
            P2.PlayerHand.Clear();
        }


    }
}
