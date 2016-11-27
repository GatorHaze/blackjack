using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class gamelogic
    {
        //adding methods to call from program.cs ("refactors")

        public static List<Card> Deck()
        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            return deck;
        }

        public static void Cards(out int playerCardValue, out int dealerCardValue, out int cardCount)
        {
            playerCardValue = 0;
            dealerCardValue = 0;
            cardCount = 0;
        }

        public static void StartOfGame()
        {
            Console.WriteLine("Welecome to the Blackjack Table!");
            Console.WriteLine("Push Enter to begin playing");
            Console.ReadLine();
        }
        public static int PlayerCardDealing(List<Card> randomDeck, out int playerCardValue, int cardCount, out Card dealtCardP)
        {
            dealtCardP = randomDeck[cardCount];
            cardCount++;
            playerCardValue = dealtCardP.GetCardValue();
            return cardCount;
        }
        public static void Dealing(List<Card> randomDeck, ref int playerCardValue, out int dealerCardValue, ref int cardCount, ref Card dealtCardP, out Card dealtCardD)
        {
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
        }

        //if player get 21 or 22 on the first deal
        public static void PlayersFirstHand(int playerCardValue)
        {
            if (playerCardValue == 21)
            {
                Console.WriteLine($"Blackjack! YOU WIN!!!");
                Console.ReadLine();
            }
            else if (playerCardValue > 21) //player dealt two aces, which equal 22
            {
                Console.WriteLine("You Lose, you busted!!");
                Console.WriteLine();

            }
        }
        //players logic for thier hand
        public static void PlayersTurn(List<Card> randomDeck, ref int playerCardValue, ref int cardCount, ref Card dealtCardP)
        {
            Console.WriteLine("Hit (h) or Stay (s)?");

            while (true)
            {
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
        }

        public static void DealersTurn(List<Card> randomDeck, int playerCardValue, ref int dealerCardValue, ref int cardCount, ref Card dealtCardD)
        {
            if (playerCardValue < 21)
            {
                Console.WriteLine("Player: " + playerCardValue);
                dealtCardD = randomDeck[cardCount];
                cardCount++;
                dealerCardValue += dealtCardD.GetCardValue();

                //player has not busted
                while (dealerCardValue < 16)
                {
                    dealtCardD = randomDeck[cardCount];
                    cardCount++;
                    dealerCardValue += dealtCardD.GetCardValue();
                    Console.WriteLine($"Dealer: {dealerCardValue}");
                }

                //check for winner
                if (playerCardValue == dealerCardValue)
                {
                    Console.WriteLine("Player and Dealer have tied");
                }
                else if (playerCardValue < dealerCardValue && dealerCardValue <= 21)
                {
                    Console.WriteLine("Dealer wins");
                }
                else if (dealerCardValue > 21)
                {
                    Console.WriteLine("Dealer has busted, Player WINS!");
                }
                else if (dealerCardValue == 21)
                {
                    Console.WriteLine("Dealer wins!!!");
                }
                else if (dealerCardValue == 16 && playerCardValue < 16)
                {
                    Console.WriteLine("Dealer Wins!!!");
                }
                else if (playerCardValue > dealerCardValue)
                {
                    Console.WriteLine("Player WINS!!!");
                }
                else
                {
                    dealtCardD = randomDeck[cardCount];
                    cardCount++;
                    dealerCardValue += dealtCardD.GetCardValue();

                    Console.WriteLine($"Player: {playerCardValue}");
                    Console.WriteLine($"Dealer wins {dealerCardValue}!!!");
                }
                Console.ReadLine();
            }
        }

    }
}
