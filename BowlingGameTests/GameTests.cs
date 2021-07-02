using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void TestAllGutterballs()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(17, 0);

            Assert.AreEqual(16, game.Score());
        }

        [TestMethod]
        public void TestTwoSpares()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            game.Roll(7);
            game.Roll(1);
            game.Roll(1);
            RollMany(14, 0);

            Assert.AreEqual(26, game.Score());
        }

        [TestMethod]
        public void TestThreeSparesAtEnd()
        {
            RollMany(14, 0);
            game.Roll(9);
            game.Roll(1);
            game.Roll(9);
            game.Roll(1);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);

            Assert.AreEqual(58, game.Score());
        }


        [TestMethod]
        public void TestStrikeSpare()
        {
            RollCustom(new int[] { 10,1,9,10,1,9,10,1,9,10,1,9,10,1,9,10 });
            Assert.AreEqual(200, game.Score());
        }

        private void RollCustom(int[] rolls)
        {
            foreach(int roll in rolls)
            {
                game.Roll(roll);
            }
        }

        [TestMethod]
        public void RollingStrikeCalcStrikeTest()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(17, 0);

            Assert.AreEqual(24, game.Score());
        }

        [TestMethod]
        public void RollingTwoStrikesCalcStrikeTest()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);

            Assert.AreEqual(47, game.Score());
        }

        [TestMethod]
        public void RollingTwoStrikesInMiddleCalcStrikeTest()
        {
            game.Roll(1);
            game.Roll(3);
            game.Roll(10);
            game.Roll(10);
            game.Roll(1);
            game.Roll(2);
            RollMany(14, 0);

            Assert.AreEqual(41, game.Score());
        }

        [TestMethod]
        public void RollingTwoStrikesAtEndCalcStrikeTest()
        {
            RollMany(14, 1);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.AreEqual(104, game.Score());
        }

        [TestMethod]
        public void RollingPerfectGameTest()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

        private void RollMany(int numberOfRolls, int pins)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game.Roll(pins);
        }



    }
}
