using DeckProgram_RIM;
using System;
using System.Linq;
using Xunit;

namespace Deck.Tests
{
    public class DeckTests
    {
        [Fact]
        public void test_scenario_6()
        {
            //Arrange
            string input1 = "2,K,3,2";
            //Act
            var expectedResult = new DeckProgram().InitiateGame(input1);
            //Assert
            Assert.Equal(7 , expectedResult);
        }


        [Fact]
        public void test_scenario_5()
        {
            //Arrange
            string input1 = "9, A, 3, Q, Q,Q,Q,A,A";
            //Act
            var expectedResult = new DeckProgram().InitiateGame(input1);
            //Assert
            Assert.Equal(100, expectedResult);
        }

        [Fact]
        public void test_scenario_4()
        {
            //Arrange
            string input1 = "2, A, A, A, J";
            //Act
            var expectedResult = new DeckProgram().InitiateGame(input1);
            //Assert
            Assert.Equal(0, expectedResult);
        }


        [Fact]
        public void test_scenario_3()
        {
            //Arrange
            string input1 = "2, A, A, A";
            //Act
            var expectedResult = new DeckProgram().InitiateGame(input1);
            //Assert
            Assert.Equal(16, expectedResult);
        }

        [Fact]
        public void test_scenario_2()
        {
            //Arrange
            string input1 = "3, 5";
            //Act
            var expectedResult = new DeckProgram().InitiateGame(input1);
            //Assert
            Assert.Equal(8, expectedResult);
        }

        [Fact]
        public void test_scenario_1()
        {
            //Arrange
            string input1 = "3, 5";
            //Act
            var expectedResult = new DeckProgram().InitiateGame(input1);
            //Assert
            Assert.Equal(8, expectedResult);
        }

        [Fact]        
        public void test_input_values_correctness()
        {            
           //Arrange
            string input1 = "3, 5";
            string input2 = "9, A, 3, Q, Q, 2";
            //Act
            var test_senario_1_output = new ParseInput().FromString(input1);
            var test_senario_2_output = new ParseInput().FromString(input2);

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
    }
}
