using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();

            var userInput = "";

            Console.WriteLine("Welcome to the Poker Hand Evaluator.");
            Console.WriteLine("Type the player's name followed by the hand separated by comma. Ex: Jack,JC,10C,9C,8C,7C");
            Console.WriteLine("When you are done, type 1 to start the evaluation.");

            while(userInput != "1")
            {
                userInput = Console.ReadLine();

                if (userInput != "1")
                {
                    try
                    {
                        var data = userInput.Split(',');

                        var playerName = data[0].Trim();

                        var firstCardInput = data[1].Trim();
                        var secondCardInput = data[2].Trim();
                        var thirdCardInput = data[3].Trim();
                        var fourthCardInput = data[4].Trim();
                        var fifthCardInput = data[5].Trim();

                        var firstCard = Card.Parse(firstCardInput);
                        var secondCard = Card.Parse(secondCardInput);
                        var thirdCard = Card.Parse(thirdCardInput);
                        var fourthCard = Card.Parse(fourthCardInput);
                        var fifthCard = Card.Parse(fifthCardInput);

                        var hand = new PokerHand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

                        var player = new Player(playerName, hand);

                        players.Add(player);

                        Console.WriteLine("Player added successfully. Type the next player or 1 to start the evaluation.");
                    }
                    catch
                    {
                        Console.WriteLine("Failed to parse the hand, please try again.");
                    }
                }
                else if (userInput == "1" && !players.Any())
                {
                    userInput = "";
                    Console.WriteLine("No players were added, please try again.");
                }
            }
            
            Console.WriteLine("PLAYERS:");

            foreach(var player in players)
            {
                Console.WriteLine($"{player.Name} - {player.Hand.GetHandType()}");
            }

            var handEvaluator = new PokerHandEvaluator();
            var winners = handEvaluator.PickWinners(players);

            Console.WriteLine("WINNER(s):");

            foreach(var player in winners)
            {
                Console.WriteLine($"- {player.Name}");
            }
        }
    }
}
