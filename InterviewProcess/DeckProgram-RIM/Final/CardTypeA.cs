using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final
{
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

            GameScore = currentState.GameScore * 2;
            return this;
        }
    }
}
