using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
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
                default:
                    break;
            }
            return this;
        }
    }

    internal class CardTypeQ:CardContext
    {
        public CardTypeQ()
        {
            stateValue = "Q";
        }

        public override CardContext Apply(ICardStrategy currentState)
        {
            if (currentState is null)
            {
                return this;
            }

            var state = currentState as CardContext;
            if (state.NextCard != null)
            {
                var nextCardName = state.NextCard.GetType().Name;
                if (nextCardName.Contains("TypeA")
                    ||
                    nextCardName.Contains("TypeJ"))
                {
                    return this;
                }
                state.GameScore += 1;
            }
            
            
            return state;
            
        }
    }

    public class CardTypeJ : CardContext
    {
        public CardTypeJ() 
        {
            stateValue = "J";
        }

        public override CardContext Apply(ICardStrategy currentState)
        {
            if (currentState is null)
            {
                return this;
            }

            currentState.GameScore = 0;
            return this;
        }
    }

    public class CardTypeA : CardContext
    {
        
        public CardTypeA()
        {
            stateValue = "A";
        }
        public override CardContext Apply(ICardStrategy currentState)
        {
            if (currentState is null)
            {
                return this;
            }

            GameScore  =  currentState.GameScore * 2;
            return this;
        }
    }

    public class CardContext: ICardStrategy
    {
        public Dictionary<int, ICardStrategy> Cards;
        public ICardStrategy PreviousCard, NextCard;
        public string stateValue { get; set; }
        public int GameScore { get; set; }        
        protected int currentIndex { get; private set; }
        

        public CardContext()
        {
            Cards = new Dictionary<int, ICardStrategy>();
        }
        public virtual CardContext GetCurrentState() 
        {
            return this;
        }

        public int SetCardType(ICardStrategy CardType) {
            Cards.Add(Cards.Count + 1, CardType);
            return Cards.Count;
        }

        public virtual CardContext Apply(ICardStrategy currentState)
        {
            if (checkDefaultConstraints())
            {
                //need to implement
            }

            for (int i = 1; i <= Cards.Count; i++)
            {
                currentIndex = i - 1;
                PreviousCard = i == 1 ? null : Cards[currentIndex];
                Cards.TryGetValue(i, out ICardStrategy CurrentCard);
                NextCard = (Cards.Count == i) ? null : Cards[i + 1];
                GameScore = CurrentCard.Apply(this).GameScore;                
            }            
            return this;
        }

        private bool checkDefaultConstraints()
        {
            return false;
        }
    }
}