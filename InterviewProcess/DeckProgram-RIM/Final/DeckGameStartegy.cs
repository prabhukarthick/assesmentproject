using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    _cardContext.SetCardType(new SpecialTypeCard(card));
            }
            _cardContext.Apply(_cardContext);
            return _cardContext.PreviousScore;
        }
    }

    internal class SpecialTypeCard : CardContext, ICardStrategy
    {
        private string score;

        public SpecialTypeCard(string score)
        {
            this.score = score;
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
        }

        public override CardContext Apply(ICardStrategy currentState)
        {
            var s = currentState as CardContext;
            
            return this;
        }
    }

    public class CardTypeJ : CardContext
    {
        public CardTypeJ()
        {
        }

        public override CardContext Apply(ICardStrategy currentState)
        {
            currentState.PreviousScore = 0;
            return this;
        }
    }

    public class CardTypeA : CardContext
    {
        public CardTypeA()
        {

        }
        public override CardContext Apply(ICardStrategy currentState)
        {
            PreviousScore  =  currentState.PreviousScore * 2;
            return this;
        }
    }

    public class CardContext: ICardStrategy
    {
        public Dictionary<int, ICardStrategy> Cards;

        public int PreviousScore { get; set; }
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
            foreach (var card in Cards)
            {                
                PreviousScore = card.Value.Apply(this).PreviousScore;
                currentIndex++;
            }
            return this;
        }

        private bool checkDefaultConstraints()
        {
            return false;
        }
    }
}