using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckProgram_RIM.Initial
{
    public class ParseInput
    {
        public ParseInput()
        {

        }
        public Queue<string> FromString(string Input)
        {
            var _res = Input.Trim().Where(c => char.ToString(c) != " " && char.ToString(c) != ",").Select(c => char.ToString(c));
            return new Queue<string>(_res.ToArray());
        }
    }

    public class DeckProgram
    {
        public DeckProgram()
        {

        }
        public int InitiateGame(string Input)
        {
            var inputData = new ParseInput().FromString(Input);
            int actualCardValue = 0;
            string deQueueValue = inputData.Dequeue();
            bool _isIgnoredCard = true;
            do
            {
                if (_isIgnoredCard)
                {
                    if (deQueueValue == "A" || deQueueValue == "J")
                    {
                        continue;
                    }
                    _isIgnoredCard = false;
                }

                switch (deQueueValue)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        actualCardValue = actualCardValue + int.Parse(deQueueValue);
                        break;
                    case "A":
                    case "a":
                        actualCardValue = DeckContains_A_Card(actualCardValue);
                        break;
                    case "J":
                    case "j":
                        actualCardValue = 0;
                        break;
                    case "K":
                    case "k":
                        if (inputData.TryDequeue(out deQueueValue))
                        {
                            var s = deQueueValue;
                            if (inputData.TryDequeue(out deQueueValue))
                            {
                                if (deQueueValue.ToLower() != "k")
                                {
                                    if (deQueueValue.ToLower() == "j")
                                    {
                                        actualCardValue = 0;
                                    }
                                    //else if
                                    //actualCardValue +=(int.Parse(s) + int.Parse(deQueueValue));
                                }
                            }
                        }
                        break;
                    case "Q":
                    case "q":
                        if (inputData.TryDequeue(out deQueueValue))
                        {
                            //If no check its A or J to ignore
                            if (deQueueValue.ToLower() == "a" || deQueueValue.ToLower() == "j")
                            {
                                break;
                            }
                            //check the deQueue is valid int
                            //if yes add +1                          
                            // If not A or J add +1
                            if (int.TryParse(deQueueValue, out int nextCardValue))
                            {
                                actualCardValue = actualCardValue + (nextCardValue + 1);
                            }
                            else
                            {
                                if (deQueueValue.ToLower() == "q")
                                {
                                    actualCardValue += 2;
                                }
                                else
                                {
                                    actualCardValue += 1;
                                }
                            }
                        }
                        break;
                }
            } while (inputData.TryDequeue(out deQueueValue));
            return actualCardValue;
        }

        private int DeckContains_K_Card()
        {
            throw new NotImplementedException();
        }

        private int DeckContains_Q_Card(string deQueueValue)
        {
            return int.Parse(deQueueValue) + 1;
        }

        private int DeckContains_A_Card(int actualCardValue)
        {
            return actualCardValue * 2;
        }
    }
}
