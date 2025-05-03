namespace BlackJackSimulation
{
    public class Gambler : Player, IGambler
    {
        public int Balance { get; set; }
        public int BetAmount { get; set; }
        public Gambler(string name, int balance) : base(name)
        {
            Balance = balance;
            base.Name = name;
            base.PlayerHand = new List<Dictionary<string, string>>();
        }

        public bool PlaceBet()
        {
            int betAmount;
            Console.WriteLine($"How much are you willing to bet {Name} current balance: {Balance}, only accepting whole ammounts:");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out betAmount))
            {
                Balance -= betAmount;
                bool ifCheckSuccessful = CheckBalance();
                if (!ifCheckSuccessful)
                {
                    return false;
                }
                BetAmount = betAmount;
                Console.WriteLine($"{Name} placed a bet of {BetAmount}");
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} entered an invalid input");
            }
            return false;

        }

        // update earnings function instead maybe
        public void GatherEarningsFrom(Gambler otherPlayer)
        {
            int earnings = BetAmount + otherPlayer.BetAmount;
            Balance += earnings;
            BetAmount = 0;
        }
        public bool CheckBalance()
        {
            if (Balance < 0)
            {
                Console.WriteLine($"You took the casions money! Current balance: {Balance} *gets kicked out*");
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool DetermineBust()
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
                        // money bet goes to other player
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("You exceeded the value of 21! with your total of: " + PowerTotal);
                    //money goes to other player
                    return false;
                }
            }
            return true;
        }


        // these methods stay the same no need to override can just call them
        //public int DetermineCardPower(string cardPower)
        //{

        //}

        //public bool DrawCard(CardsDeck deck)
        //{

        //}

    }


}
