using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace_1;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;
        private ICalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
            game = new Game(calculator);
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
        public void TestNoRoll()
        {
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestOneStrikeFirstFrame()
        {
            game.Roll(10);
            for (int i = 0; i < 18; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(10, game.Score());
        }

        [TestMethod]
        public void TestOneStrikeAndOneSpare()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            for (int i = 0; i < 18; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(30, game.Score());
        }

        [TestMethod]
        public void TestPerfect()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.Score());
        }

        [TestMethod]
        public void TestOneLessThanPerfect()
        {
            for (int i = 0; i < 11; i++)
            {
                game.Roll(10);
            }
            game.Roll(9);
            Assert.AreEqual(299, game.Score());
        }
    }
}
