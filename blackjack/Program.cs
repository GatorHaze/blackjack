using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
    {

        static void Main(string[] args)
        {

            var deck = new List<Card>();
            List<Card> randomDeck;

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();


            Console.WriteLine("Welecome to the Blackjack Table!");
            Console.WriteLine("Push Enter to begin playing");
            Console.ReadLine();

            var playerCardValue = 0;
            var dealerCardValue = 0;
            var cardCount = 0;

            Card dealtCardP;
            Card dealtCardD;

            dealtCardP = randomDeck[cardCount];
            cardCount++;
            playerCardValue = dealtCardP.GetCardValue();

            Console.WriteLine($"Your first card is.. {dealtCardP}");

            dealtCardP = randomDeck[cardCount];
            cardCount++;
            playerCardValue += dealtCardP.GetCardValue();

            Console.WriteLine($"Your next card is.. {dealtCardP}");

            dealtCardD = randomDeck[cardCount];
            cardCount++;
            dealerCardValue = dealtCardD.GetCardValue();

            Console.WriteLine($"The dealer is showing {dealtCardD}");
            Console.WriteLine($"Dealer: {dealerCardValue} Player: {playerCardValue}");
            Console.WriteLine();

            //players turn 

            while (true)
            {

                if (playerCardValue == 21)
                {
                    Console.WriteLine($"Blackjack! YOU WIN!!!");
                    break;
                }
                else if (playerCardValue > 21) //player dealt two aces 
                {
                    Console.WriteLine("You Lose, you busted!!");
                    Console.WriteLine();
                    break;     
                }

                Console.WriteLine("Hit (h) or Stay (s)?");
                string input = Console.ReadLine();

                if (input == "h")
                {
                    dealtCardP = randomDeck[cardCount];
                    cardCount++;
                    playerCardValue += dealtCardP.GetCardValue();

                    Console.WriteLine($"Your card is {dealtCardP}");
                    Console.WriteLine($"You now have {playerCardValue}");
                    Console.WriteLine();

                    if (playerCardValue > 21)
                    {
                        Console.WriteLine("You Lose, you busted!!");
                        Console.ReadLine();
                    }
                    else if (playerCardValue == 21)
                    {
                        Console.WriteLine($"Blackjack! YOU WIN!!!");
                        Console.ReadLine();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input == "s")
                {
                    Console.WriteLine("Dealers Turn!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect response, try again");
                    continue;
                }
            }


            //Dealers Turn


            if (playerCardValue < 21)
            {
                Console.WriteLine("Players card value is " + playerCardValue);
                dealtCardD = randomDeck[cardCount];
                cardCount++;
                dealerCardValue += dealtCardD.GetCardValue();

                //player has not busted
                while (dealerCardValue < 16)
                {
                    dealtCardD = randomDeck[cardCount];
                    cardCount++;
                    dealerCardValue += dealtCardD.GetCardValue();
                }

                //check for winner
                if (playerCardValue == dealerCardValue)
                {
                    Console.WriteLine("Player and Dealer have tied");
                }
                else if (playerCardValue < dealerCardValue && dealerCardValue <= 21)
                {
                    Console.WriteLine($"Dealer has: {dealerCardValue}");
                    Console.WriteLine("Dealer wins");
                }
                else if (dealerCardValue > 21)
                {
                    Console.WriteLine("Dealer has busted, player wins!");
                }
                else if (dealerCardValue == 21)
                {
                    Console.WriteLine($"Dealer has: {dealerCardValue}");
                    Console.WriteLine("Dealer wins!!!");
                }
                else if (dealerCardValue == 16 && playerCardValue < 16)
                {
                    Console.WriteLine("Dealer Wins!!!");
                }
                else if (playerCardValue > dealerCardValue)
                {
                    Console.WriteLine("Player Wins!!!");
                }
                else
                {
                    dealtCardD = randomDeck[cardCount];
                    cardCount++;
                    dealerCardValue += dealtCardD.GetCardValue();

                    Console.WriteLine($"Dealer: {dealerCardValue} Player: {playerCardValue}");
                    Console.WriteLine("Dealer wins!!!");
                }
                Console.WriteLine($"Dealer: { dealerCardValue}");
                Console.ReadLine();

                
            }
        }
    }
}









