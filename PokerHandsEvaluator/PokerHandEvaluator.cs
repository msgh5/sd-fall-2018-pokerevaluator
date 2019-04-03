using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsEvaluator
{
    public class PokerHandEvaluator
    {
        public List<Player> PickWinners(List<Player> players)
        {
            var hands = players.Select(p => p.Hand).ToList();

            var winningHand = DetermineWinnigHand(hands);

            return players.Where(p => p.Hand.GetHandType() == winningHand).ToList();
        }

        private Hand DetermineWinnigHand(List<PokerHand> hands)
        {
            return hands.Min(p => p.GetHandType());
        }
    }
}