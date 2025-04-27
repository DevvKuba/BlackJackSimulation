namespace BlackJackSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            CardsDeck blackJackDeck = new CardsDeck();
            Player player1 = new Player("Joffrey");
            Player player2 = new Player("Goomba");

            BlackJack blackJackTable = new BlackJack(player1, player2, blackJackDeck);
            blackJackTable.startRound();

            // when a bust happens display the other player as the winner



        }
    }
}
