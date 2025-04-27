namespace BlackJackSimulation
{
    public interface PlayerFunctionality
    {

        bool DrawCard(CardsDeck deck);

        int DetermineCardPower(string cardPower);

        bool DetermineBust();

    }
}
