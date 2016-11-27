using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
    {

        public static void Main(string[] args)
        {
            List<Card> randomDeck;
            List<Card> deck = gamelogic.Deck();

            randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            gamelogic.StartOfGame();

            int playerCardValue, dealerCardValue, cardCount;

            Card dealtCardP, dealtCardD;

            gamelogic.Cards(out playerCardValue, out dealerCardValue, out cardCount);

            cardCount = gamelogic.PlayerCardDealing(randomDeck, out playerCardValue, cardCount, out dealtCardP);

            gamelogic.Dealing(randomDeck, ref playerCardValue, out dealerCardValue, ref cardCount, ref dealtCardP, out dealtCardD);

            //refactored and placed code in gamelogic.cs
            gamelogic.PlayersFirstHand(playerCardValue);

            //players turn 
            gamelogic.PlayersTurn(randomDeck, ref playerCardValue, ref cardCount, ref dealtCardP);

            //Dealers Turn
            gamelogic.DealersTurn(randomDeck, playerCardValue, ref dealerCardValue, ref cardCount, ref dealtCardD);
        }
    }
}









