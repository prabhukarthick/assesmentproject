using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final.Contracts
{
    public interface ICardStrategy
    {
        public int PreviousScore { get; set; }
        public CardContext Apply(ICardStrategy currentState);
    }
}
