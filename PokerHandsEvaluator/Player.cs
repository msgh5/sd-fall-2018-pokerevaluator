namespace PokerHandsEvaluator
{
    public class Player
    {
        public string Name { get; private set; }
        public PokerHand Hand { get; private set; }

        public Player(string name, PokerHand hand)
        {
            Name = name;
            Hand = hand;
        }
    }
}
