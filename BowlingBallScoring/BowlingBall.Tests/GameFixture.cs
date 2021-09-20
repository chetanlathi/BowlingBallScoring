// Author : Chetan Lathi.   
// Created Test Cases for BowlingBall Game
// Created on : 20 September 2021

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game _game=null;

        [TestInitialize]
        public void TestInitialize()
        {
            _game = new Game();
        }

        [TestMethod]
        public void Test_RollBall_With_AllZero()
        {
            //Arrange
            RollBall(0, 20);

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(0, actualResult);
        }       

        [TestMethod]
        public void Test_RollBall_With_AllOne()
        {
            //Arrange
            RollBall(1, 20);

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(20, actualResult);
        }

        [TestMethod]
        public void Test_RollBall_With_OneSpare()
        {
            //Arrange
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
             RollBall(0, 17);

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(16, actualResult);
        }

        [TestMethod]
        public void Test_Roll_With_OneStrike()
        {
            //Arrange
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(4);
            RollBall(0, 17);

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(24, actualResult);
        }

        [TestMethod]
        public void Test_Roll_With_PerfectGame()
        {
            //Arrange
            RollBall(10, 12);

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(300, actualResult);
        }

        [TestMethod]
        public void Test_Roll_With_RandomGame_And_NoExtraRoll()
        {
            //Arrange
            _game.Roll(new int[] { 4, 3, 8, 2, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(134, actualResult);
        }

        [TestMethod]
        public void Test_Roll_With_RandomGame_And_SpareThenStrikeAtEnd()
        {
            //Arrange
            _game.Roll(new int[] { 4, 2, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(145, actualResult);
        }

        [TestMethod]
        public void Test_Roll_With_RandomGame_And_ThreeStrikesAtEnd()
        {
            //Arrange
            _game.Roll(new int[] { 5, 2, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });

            //Act
            int actualResult = _game.GetScore();

            //Assert
            Assert.AreEqual(166, actualResult);
        }

        private void RollBall(int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}
