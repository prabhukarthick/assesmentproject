using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final.Contracts
{
    public interface ICardStrategy
    {
        public int GameScore { get; set; }
        public CardContext Apply(ICardStrategy currentState);
    }
}
