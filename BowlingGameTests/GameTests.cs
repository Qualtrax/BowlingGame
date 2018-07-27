using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namespace_1;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Namespace_1.Class1 game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Class1();
        }

        [TestMethod]
        public void TestGutterGame()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);

            Assert.AreEqual(0, game.CalculateScoreForAllRollsInGame());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(1);

            Assert.AreEqual(20, game.CalculateScoreForAllRollsInGame());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            for (var i = 0; i < 17; i++)
                game.Roll(0);

            Assert.AreEqual(16, game.CalculateScoreForAllRollsInGame());
        }
    }
}
