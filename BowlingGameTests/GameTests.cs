using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;
using System.Diagnostics;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private TheGame game;

        [TestInitialize]
        public void Initialize()
        {
            game = new TheGame();
        }

        [TestMethod]
        public void TestGutterGame()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(1);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            for (var i = 0; i < 17; i++)
                game.Roll(0);

            Assert.AreEqual(16, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);

            Assert.AreEqual(26, game.Score());
        }

        [TestMethod]
        public void TestA300()
        {
            for (var i = 0; i < 12; i++)
                game.Roll(10);

            Assert.AreEqual(300, game.Score());
        }

        [TestMethod]
        public void TestAStrike()
        {
            var rolls = new int[] { 10 };
            var calculator = Calculator.GetRollCalculator(rolls);
            var results = calculator.IsStrike(0);
            Assert.IsTrue(results);
        }
    }
}
