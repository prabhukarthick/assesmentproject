using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final
{
    public class CardContext : ICardStrategy
    {
        public Dictionary<int, ICardStrategy> Cards;
        public ICardStrategy PreviousCard, NextCard;
        protected string stateValue { get; set; }
        public int GameScore { get; set; }
        public int currentIndex { get; private set; }
        public string CardScore { get { return stateValue; } }

        public CardContext()
        {
            Cards = new Dictionary<int, ICardStrategy>();
        }
        public virtual CardContext GetCurrentState()
        {
            return this;
        }

        public int SetCardType(ICardStrategy CardType)
        {
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
