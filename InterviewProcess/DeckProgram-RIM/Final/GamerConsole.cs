using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckProgram_RIM.Final
{
    public class GamerConsole
    {
        private readonly List<string> _cardList;

        public GamerConsole(string cardList)
        {
            _cardList = new InputParser().ToList(cardList);
        }

        public int StartDeckGame()
        {
            var result = new DeckGameStartegy(_cardList).StartDeckGame();
            return result;
        }
    }
}
