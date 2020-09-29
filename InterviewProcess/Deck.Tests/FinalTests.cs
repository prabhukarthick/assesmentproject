using DeckProgram_RIM.Final;
using DeckProgram_RIM.Final.Contracts;
using DeckProgram_RIM.Initial;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Deck.Tests
{
    public class ParseInputTests
    {
        private IDeckInputParser _inputParser;

        public ParseInputTests()
        {
            _inputParser = new InputParser();
        }
        [Fact]
        public void ParseInputData_Queue_Tests()
        {
            //Arrange
            string input1 = "3, 5";
            string input2 = "9, A, 3, Q, Q,2";

            //Act
            var test_senario_1_output = _inputParser.ToQueue(input1);
            var test_senario_2_output = _inputParser.ToQueue(input2);

            //Assert
            Assert.Equal(2, test_senario_1_output.Count);
            Assert.Equal("3", test_senario_1_output.Dequeue());
            Assert.Equal("5", test_senario_1_output.Dequeue());
            Assert.Empty(test_senario_1_output);

            Assert.Equal(6, test_senario_2_output.Count);
            Assert.Equal("9", test_senario_2_output.Dequeue());
            Assert.Equal("A", test_senario_2_output.Dequeue());
            Assert.Equal("3", test_senario_2_output.Dequeue());
            Assert.Equal("Q", test_senario_2_output.Dequeue());
            Assert.Equal("Q", test_senario_2_output.Dequeue());
            Assert.Equal("2", test_senario_2_output.Dequeue());
            Assert.Empty(test_senario_2_output);
        }

        [Fact]
        public void ParseInputData_List_Tests()
        {
            //Arrange
            string input1 = "3, 5";
            string input2 = "9, A, 3, Q, Q, 2";

            //Act
            var test_senario_1_output = _inputParser.ToList(input1);
            var test_senario_2_output = _inputParser.ToList(input2);

            //Assert
            Assert.Equal(2, test_senario_1_output.Count);
            Assert.Equal("3", test_senario_1_output[0]);
            Assert.Equal("5", test_senario_1_output[1]);
            Assert.NotEmpty(test_senario_1_output);

            Assert.Equal(6, test_senario_2_output.Count);
            Assert.Equal("9", test_senario_2_output[0]);
            Assert.Equal("A", test_senario_2_output[1]);
            Assert.Equal("3", test_senario_2_output[2]);
            Assert.Equal("Q", test_senario_2_output[3]);
            Assert.Equal("Q", test_senario_2_output[4]);
            Assert.Equal("2", test_senario_2_output[5]);
            Assert.NotEmpty(test_senario_2_output);
        }
    }

    public class GamerConsole_Tests
    {
        public GamerConsole_Tests()
        {

        }

        [Fact]
        public void Start_Game_Console_Test_With_Number_Only()
        {
            //Arrange
            string input1 = "3, 5";
            string input2 = "5, 4,3,2,7";
            string input3 = "3, 5, 10";
            string input4 = "3,5,8,9";

            //Act
            var expectedResult = new GamerConsole(input1).StartDeckGame();
            //Assert
            Assert.Equal(8, expectedResult);

            //Act
            expectedResult = new GamerConsole(input2).StartDeckGame();
            //Assert
            Assert.Equal(21, expectedResult);

            //Act
            //Assert
            var ex = Assert.Throws<System.Exception>(
                    () => new GamerConsole(input3).StartDeckGame()
                );
            Assert.Equal("only numbers between 2 to 9 accepted.", ex.Message);

            //Act
            expectedResult = new GamerConsole(input4).StartDeckGame();
            //Assert
            Assert.Equal(25, expectedResult);
        }

        [Fact]
        public void start_Game_Console_Test_With_A()
        {
            string input1 = "A";
            var exceptedResult = new GamerConsole(input1).StartDeckGame();
            Assert.Equal(0 , exceptedResult);

            input1 = "A,3";
            exceptedResult = new GamerConsole(input1).StartDeckGame();
            Assert.Equal(3, exceptedResult);

            input1 = "2, A";
            exceptedResult = new GamerConsole(input1).StartDeckGame();
            Assert.Equal(4, exceptedResult);

            input1 = "5,2, A";
            exceptedResult = new GamerConsole(input1).StartDeckGame();
            Assert.Equal(14, exceptedResult);

            input1 = "2, A,A,A";
            exceptedResult = new GamerConsole(input1).StartDeckGame();
            Assert.Equal(16, exceptedResult);
        }

        [Fact]
        public void start_Game_Console_Test_With_J()
        {
            string input = "5,3,J,8,J";
            var exceptedResult = new GamerConsole(input).StartDeckGame();
            Assert.Equal(0, exceptedResult);

            input = "A, 3, J, J";
            exceptedResult = new GamerConsole(input).StartDeckGame();
            Assert.Equal(0, exceptedResult);
        }

        [Fact]
        public void start_Game_Console_Test_With_Q()
        {
            string input = "Q,Q,2";
            var exceptedResult = new GamerConsole(input).StartDeckGame();
            Assert.Equal(3, exceptedResult);

            //input = "A, 3, J, J";
            //exceptedResult = new GamerConsole(input).StartDeckGame();
            //Assert.Equal(0, exceptedResult);
        }


    }
}
