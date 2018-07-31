using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTests
{
    [TestClass]
    public class CalculatorTests
    {
  
        [TestMethod]
        public void TestGutterGame()
        {
            int[] rolls = new int[21];
            for (var i = 0; i < 20; i++)
                rolls[i] = 0;

            Calculator calculator = new Calculator();
            int score = calculator.GetScoreForAllRollsInGame(rolls);
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void TestAllOnes()
        {
            int[] rolls = new int[21];
            for (var i = 0; i < 20; i++)
                rolls[i] = 1;

            Calculator calculator = new Calculator();
            int score = calculator.GetScoreForAllRollsInGame(rolls);
            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void TestOneSpare()
        {
            int[] rolls = new int[21];
            rolls[0] = 5;
            rolls[1] = 5;
            rolls[2] = 3;

            for (var i = 0; i < 17; i++)
                rolls[i + 3] = 0;

            Calculator calculator = new Calculator();
            int score = calculator.GetScoreForAllRollsInGame(rolls);
            Assert.AreEqual(16, score);
        }

        [TestMethod]
        public void TestOneStrike()
        {
            int[] rolls = new int[21];
            rolls[0] = 10;
            rolls[1] = 5;
            rolls[2] = 3;

            for (var i = 0; i < 16; i++)
                rolls[i + 3] = 0;

            Calculator calculator = new Calculator();
            int score = calculator.GetScoreForAllRollsInGame(rolls);
            Assert.AreEqual(26, score);
        }

        [TestMethod]
        public void TestAllStrikes()
        {
            int[] rolls = new int[21];

            for (var i = 0; i < 12; i++)
                rolls[i] = 10;

            Calculator calculator = new Calculator();
            int score = calculator.GetScoreForAllRollsInGame(rolls);
            Assert.AreEqual(300, score);
        }
    }
}
