using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final
{
    internal class CardTypeQ : CardContext
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
}
