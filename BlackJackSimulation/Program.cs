namespace BlackJackSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardsDeck blackJackDeck = new CardsDeck();
            Player player1 = new Player("Joffrey");

            player1.DrawCard(blackJackDeck);
            player1.DrawCard(blackJackDeck);
        }
    }
}
