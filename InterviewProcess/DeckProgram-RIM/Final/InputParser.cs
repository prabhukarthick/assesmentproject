using DeckProgram_RIM.Final.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckProgram_RIM.Final
{
    public class InputParser:IDeckInputParser
    {        
        public Queue<string> ToQueue(string Input)
        {
            IEnumerable<string> _res = ExtractInputToArray(Input);
            return new Queue<string>(_res.ToArray());
        }       

        public List<string> ToList(string Input)
        {
            IEnumerable<string> _res = ExtractInputToArray(Input);
            return new List<string>(_res.ToArray());
        }

        private static IEnumerable<string> ExtractInputToArray(string Input)
        {
            return Input.Trim()
                            .Where(c => char.ToString(c) != " " && char.ToString(c) != ",")
                            .Select(c => char.ToString(c));
        }
    }
}
