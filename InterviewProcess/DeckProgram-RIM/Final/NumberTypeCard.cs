using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final
{
    internal class NumberTypeCard : CardContext, ICardStrategy
    {
        private readonly int _value;

        public NumberTypeCard(int value)
        {
            _value = (value > 1 && value < 10) ?
                    value : throw new Exception("only numbers between 2 to 9 accepted.");
            stateValue = _value.ToString();
        }

        public override CardContext Apply(ICardStrategy currentState)
        {
            GameScore = currentState.GameScore;
            GameScore += _value;
            return this;
        }
    }
}
