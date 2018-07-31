using System.Linq;
using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
        private int currentRoll = 0;
        private int[] rolls = new int[21];

        public ICalculator ScoreCalculator { get; set; }

        public List<int> Rolls
        {
            get
            {
                return rolls.ToList();
            }
        }


        /// <summary>
        /// Adds a role
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="roll"></param>
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        /// <summary>
        /// Calculates the score for a game
        /// </summary>
        /// <returns>the score</returns>
        public int Score()
        {
            return ScoreCalculator.GetScoreForAllRollsInGame(rolls);
        }
    }
}
