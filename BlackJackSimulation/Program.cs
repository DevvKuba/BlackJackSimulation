namespace BlackJackSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            CardsDeck blackJackDeck = new CardsDeck();
            Player player1 = new Player("Joffrey");
            Player player2 = new Player("Goomba");

            Gambler gambler1 = new Gambler("Casio");
            Gambler gambler2 = new Gambler("Robi");

            BlackJack blackJackTable = new BlackJack(player1, player2, blackJackDeck);
            blackJackTable.startRound();




        }
    }
}
