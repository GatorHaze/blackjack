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

            var cardCount = 0;
            var playerCardValue = 0;
            var dealerCardValue = 0;
            var dealerTotal = dealerCardValue;
            

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
            Console.WriteLine($"Dealer: {dealerCardValue} Player: {playerCardValue}" );
            Console.WriteLine();
            Console.WriteLine("Would you like to hit? Enter (1) for Hit or (n) to Stay");
            var input = Console.ReadLine();
            

            while (true)
            {
                dealtCardP = randomDeck[cardCount];
                cardCount++;
                playerCardValue += dealtCardP.GetCardValue();
                Console.WriteLine($"Your card is {dealtCardP}");
                Console.WriteLine($"You now have {playerCardValue}");
                Console.ReadLine();

                if (playerCardValue == 21)
                {
                    Console.WriteLine($"Blackjack! YOU WIN!!!");
                    Console.WriteLine();
                    Console.WriteLine($"Dealer has {dealerCardValue}");
                }
                else if (playerCardValue > 21)
                {
                    Console.WriteLine($"Oops!{playerCardValue}. You busted, you lose");
                }
                else if (playerCardValue < 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("Would you like to hit? y/n?");
                    var answer = Console.ReadLine();


                    if (answer == "y")
                    {
                        dealtCardP = randomDeck[cardCount];
                        cardCount++;
                        playerCardValue += dealtCardP.GetCardValue();
                         
                        Console.WriteLine($"Your card is {dealtCardP}");
                        Console.WriteLine($"You now have {playerCardValue}");

                        if (playerCardValue < 21)
                        {
                            Console.WriteLine("You busted, Dealer Wins");
                            Console.WriteLine();
                            Console.ReadLine();
                            break;
                        }
                        else
                            continue;
                    }
                    else if (answer == "n")
                    {
                        Console.WriteLine("Dealers Turn!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You must enter a 'y' or a 'n'");
                    }
                }
                else 
                {
                    Console.WriteLine("Dealers turn");
                    break;
                }
                break;
            }
            
          

            while (true)
            {
                dealtCardD = randomDeck[cardCount];
                cardCount++;
                dealerCardValue += dealtCardD.GetCardValue();
                Console.WriteLine($"Dealer card is {dealtCardD}");
                Console.WriteLine($"Dealer now has {playerCardValue}");
                Console.WriteLine();

                if (dealerTotal == 21 && playerCardValue < 21)
                {
                    Console.WriteLine("Dealer Wins!!!");
                    break;
                }
                else if (dealerTotal == 16 && playerCardValue < 16)
                {
                    Console.WriteLine("Dealer Wins!!!");
                    break;
                }
                    else if (dealerTotal == playerCardValue && dealerTotal < 21 && playerCardValue < 21)
                    {
                    Console.WriteLine("Draw. Play again?");
                    Console.WriteLine();
                    }

                if (playerCardValue < 21 && dealerTotal < 16)
                {
                    dealtCardD = randomDeck[cardCount];
                    cardCount++;
                    dealerCardValue = dealtCardD.GetCardValue();

                    Console.WriteLine();
                    Console.WriteLine($"Dealers card {dealtCardD}");
                    Console.WriteLine($"Dealer has {dealerTotal}");
                }

                else if (dealerTotal < playerCardValue)
                {
                    Console.WriteLine("Player win!!!");
                    break;
                }
                else if (dealerTotal > playerCardValue)
                {
                    Console.WriteLine("Dealer Wins!");
                }   
                else
                {
                    break;
                }
            }
            Console.ReadLine();
        }

    }
    }












