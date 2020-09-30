using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final
{
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
}
