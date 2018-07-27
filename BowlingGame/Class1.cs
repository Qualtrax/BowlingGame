using BowlingGame;

namespace Namespace_1
{
    public class Class1
    {
        // initializes rolls array
        public int[] rolls = new int[21];
        // initializes roll
        private int currentRoll = 0;

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
        public int CalculateScoreForAllRollsInGame()
        {
            Calculator calculator = Calculator.GetRollCalculator(rolls);

            var score = 0;
            int i = 0;

            for (int f = 0; f < 10; f++)
            {
                calculator.GetScoreForFrame(ref score, ref i);
            }

            return score;
        }
    }
}
