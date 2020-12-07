using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;
using System.Runtime.InteropServices;

namespace BowlingGameTests
{
    [TestClass]
    public class AmericanTenPinCalculatorTest
    {
        private GameState game;
        
        [TestInitialize]
        public void Initialize()
        {
            var calculator = new AmericanTenPinCalculator();
            game = new GameState(calculator);
        }

        [TestMethod]
        public void TestGutterGame()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);

            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(1);

            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void TestAllStrike()
        {
            for (var i = 0; i < 12; i++)
                game.Roll(10);

            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            for (var i = 0; i < 17; i++)
                game.Roll(0);

            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void TestEndSpare()
        {
            for (var i = 0; i < 18; i++)
                game.Roll(0);

            game.Roll(10);
            game.Roll(5);
            game.Roll(5);

            Assert.AreEqual(20, game.GetScore());
        }

    }
}
