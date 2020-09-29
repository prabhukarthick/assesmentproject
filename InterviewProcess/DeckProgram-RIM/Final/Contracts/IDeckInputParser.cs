using System.Collections.Generic;

namespace DeckProgram_RIM.Final.Contracts
{
    public interface IDeckInputParser
    {
        public Queue<string> ToQueue(string Input);
        public List<string> ToList(string Input);
    }
}