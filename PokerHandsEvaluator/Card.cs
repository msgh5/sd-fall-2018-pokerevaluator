using System;

namespace PokerHandsEvaluator
{
    public class Card
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public static Card Parse(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new Exception("Data is empty");
            }

            data = data.ToUpper();

            var rank = GetRank(data);
            var suit = GetSuit(data);

            return new Card(rank, suit);
        }

        private static Suit GetSuit(string data)
        {
            var suit = data.Substring(data.Length - 1);

            switch (suit)
            {
                case "H": return Suit.Hearts;
                case "D": return Suit.Diamonds;
                case "C": return Suit.Clubs;
                case "S": return Suit.Spades;
                default:
                    {
                        if (data == "JOKER")
                        {
                            return Suit.None;
                        }

                        throw new Exception($"Failed to parse: {data}");
                    }
            }
        }

        private static Rank GetRank(string data)
        {
            var firstCharacter = data.Substring(0, 1);

            switch (firstCharacter)
            {
                case "A": return Rank.Ace;
                case "2": return Rank.Two;
                case "3": return Rank.Three;
                case "4": return Rank.Four;
                case "5": return Rank.Five;
                case "6": return Rank.Six;
                case "7": return Rank.Seven;
                case "8": return Rank.Eight;
                case "9": return Rank.Nine;
                case "J": return Rank.Jack;
                case "Q": return Rank.Queen;
                case "K": return Rank.King;
                default:
                    {
                        var firstTwoCharacters = data.Substring(0, 2);

                        if (firstTwoCharacters == "10")
                        {
                            return Rank.Ten;
                        }
                        else if (data == "JOKER")
                        {
                            return Rank.Joker;
                        }
                        else
                        {
                            throw new Exception($"Failed to parse: {data}");
                        }
                    }
            }
        }
    }
}