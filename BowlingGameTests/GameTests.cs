using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20,1);
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17,0);
            Assert.AreEqual(16,game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollMany(int numberOfRolls, int pins)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game.Roll(pins);
        }
    }
}
