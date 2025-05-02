using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimulation
{
    public class Gambler : Player, IGambler
    {
        public int Balance { get; set; }
        public Gambler(string name) : base(name)
        {
            base.Name = name;
            base.PlayerHand = new List<Dictionary<string, string>>();
        }

        public int PlaceBet()
        {
            int betAmount;
            Console.WriteLine("How much are you willing to bet, only accepting whole ammounts:");
            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out betAmount))
            {
                Balance -= betAmount;
                CheckBalance();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }


        // are forced to place a bet when taking a turn only then can draw a card
        // check balance is done prior to ensure they can still play, if balance is ever
        // becomes negative they get kicked out of the casino
        // possibly itilise inheritance to call base methods for gambler
        }
        public int CheckBalance()
        {
            throw new NotImplementedException();
        }

        public bool TakeTurn(CardsDeck deck)
        {
            int bet = PlaceBet();
            
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
                    //money goes to other play
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
