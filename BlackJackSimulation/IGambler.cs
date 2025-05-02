using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimulation
{
    public interface IGambler
    {
        int PlaceBet(int amount);

        int CheckBalance();


    }
}
