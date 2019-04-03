using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsEvaluator
{
    public class PokerHand
    {
        public List<Card> Cards { get; private set; }

        public PokerHand(Card firstCard, Card secondCard, Card thirdCard, Card fourthCard, Card fifthCard)
        {
            Cards = new List<Card> { firstCard, secondCard, thirdCard, fourthCard, fifthCard };
        }

        public Hand GetHandType()
        {
            if (IsFiveOfAKind())
            {
                return Hand.FiveOfAKind;
            }
            else if (IsRoyalFlush())
            {
                return Hand.RoyalFlush;
            }
            else if (IsStraightFlush())
            {
                return Hand.StraightFlush;
            }
            else if (IsFourOfAKind())
            {
                return Hand.FourOfAKind;
            }
            else if (IsFullHouse())
            {
                return Hand.FullHouse;
            }
            else if (IsFlush())
            {
                return Hand.Flush;
            }
            else if (IsStraight())
            {
                return Hand.Straight;
            }
            else if (IsThreeOfAKind())
            {
                return Hand.ThreeOfAKind;
            }
            else if (IsTwoPairs())
            {
                return Hand.TwoPairs;
            }
            else if (IsOnePair())
            {
                return Hand.OnePair;
            }
            else if (IsHighCard())
            {
                return Hand.HighCard;
            }
            else
            {
                throw new Exception("Hand not implemented");
            }
        }

        private bool IsFiveOfAKind()
        {
            return GetGroupByRankCount(4) == 1 && Cards.Any(p => p.Rank == Rank.Joker);
        }

        private bool IsRoyalFlush()
        {
            return IsStraightFlush() && Cards[4].Rank == Rank.Ace;
        }

        private bool IsStraightFlush()
        {
            return IsFlush() && IsStraight();
        }

        private bool IsFourOfAKind()
        {
            return GetGroupByRankCount(4) == 1;
        }

        private bool IsFullHouse()
        {
            return IsThreeOfAKind() && IsOnePair();
        }

        private bool IsFlush()
        {
            return GetGroupBySuitCount(5) == 1;
        }

        private bool IsStraight()
        {
            var sortedCards = Cards.OrderBy(c => c.Rank).ToList();

            for (int i = 0; i < sortedCards.Count - 1; i++)
            {
                if (sortedCards[i + 1].Rank != sortedCards[i].Rank + 1)
                    return false;
            }

            return true;
        }

        private bool IsThreeOfAKind()
        {
            return GetGroupByRankCount(3) == 1;
        }

        private bool IsTwoPairs()
        {
            return GetGroupByRankCount(2) == 2;
        }

        private bool IsOnePair()
        {
            return GetGroupByRankCount(2) == 1;
        }

        private bool IsHighCard()
        {
            return GetGroupByRankCount(1) == 5;
        }

        private int GetGroupByRankCount(int number)
        {
            return Cards.GroupBy(c => c.Rank).Count(g => g.Count() == number);
        }

        private int GetGroupBySuitCount(int number)
        {
            return Cards.GroupBy(c => c.Suit).Count(g => g.Count() == number);
        }
    }
}
