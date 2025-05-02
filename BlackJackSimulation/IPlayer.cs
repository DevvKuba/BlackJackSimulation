namespace BlackJackSimulation
{
    public interface IPlayer
    {

        bool DrawCard(CardsDeck deck);

        bool TakeTurn(CardsDeck deck);

        int DetermineCardPower(string cardPower);

        bool DetermineBust();

    }
}
