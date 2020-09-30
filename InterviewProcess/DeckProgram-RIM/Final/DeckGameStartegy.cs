using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DeckProgram_RIM.Final
{
    public class DeckGameStartegy
    {
        protected List<string> _cardList;
        
        public DeckGameStartegy(List<string> cardList)
        {
            _cardList = cardList;
        }

        public int StartDeckGame()
        {
            var _cardContext = new CardContext();
            foreach (var card in _cardList)
            {
             var cardCount = int.TryParse(card, out int score) ?
                    _cardContext.SetCardType(new NumberTypeCard(score)) :
                    _cardContext.SetCardType(new SpecialTypeCard(card).SetCardState());
            }
            _cardContext.Apply(_cardContext);
            return _cardContext.GameScore;
        }
    }

    internal class SpecialTypeCard : CardContext, ICardStrategy
    {
        internal string score;

        public SpecialTypeCard(string score)
        {
            this.score = score;
        }

        public ICardStrategy SetCardState()
        {
            return Apply(null);
        }

        public override CardContext Apply(ICardStrategy currentState)
        {
            switch (score)
            {
                case "A":
                case "a":
                    return new CardTypeA().Apply(currentState);
                case "J":
                case "j":
                    return new CardTypeJ().Apply(currentState);
                case "Q":
                case "q":
                    return new CardTypeQ().Apply(currentState);                
                case "K":
                case "k":
                    return new CardTypeK().Apply(currentState);
                default:
                    break;
            }
            return this;
        }
    }

    class CardTypeK : CardContext, ICardStrategy
    {
        short positionFlag = 0;
        public CardTypeK()
        {
            stateValue = "K";
        }
        public override CardContext Apply(ICardStrategy currentState)
        {
            if (currentState is null)
            {
                return this;
            }

            var state = currentState as CardContext;
            var s = state.currentIndex - 1;

            if (state.currentIndex > 1 &&
                state.Cards.TryGetValue(s,
                    out ICardStrategy _lookupcard)
                )
            {
                var u = (_lookupcard.ToString().Contains("Type K")) ?
                    state.PreviousCard.ToString()
                    : "";
            }

            return state;
        }

        public override string ToString()
        {
            return "Card Type K";
        }
    }
    
}