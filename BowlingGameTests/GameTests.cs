using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private BowlingGame.Game game;

        [TestInitialize]
        public void Initialize()
        {
            Calculator calculator = new Calculator();
            game = new Game();
            game.ScoreCalculator = calculator;
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
    }
}
