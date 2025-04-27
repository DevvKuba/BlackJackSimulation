namespace BlackJackSimulation
{
    public class CardsDeck
    {
        public List<Dictionary<string, string>> GameDeck { get; set; }
        public CardsDeck()
        {
            // initiliase the actual gameDeck to play
            GameDeck = new List<Dictionary<string, string>>();
            for (int i = 0; i < 52; i++)
            {

                GameDeck.Add(new Card().CardDict);
            }
        }
    }
}
