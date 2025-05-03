namespace BlackJackSimulation
{
    public interface IGambler
    {
        bool PlaceBet();

        bool CheckBalance();

        void GatherEarningsFrom(Gambler otherPlayer);




    }
}
