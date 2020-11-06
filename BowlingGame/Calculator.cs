using System.Linq;

namespace BowlingGame
{
    public class Calculator
    {
        private int[] rolls;

        private Calculator(int[] rolls)
        {
            this.rolls = rolls;
        }

        public static Calculator GetRollCalculator(int[] rolls)
        {
            return new Calculator(rolls);
        }

        public int GetScoreForAllRollsInGame()
        {
            int rollIndex = 0;
            int score = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score = CalculateScoreForStrike(score, rollIndex);
                }
                else if (IsSpare(rollIndex))
                {
                    score = CalculateScoreForSpare(score, rollIndex);
                    rollIndex++;
                }
                else
                {
                    score = CalculateScoreForOpen(score, rollIndex);
                    rollIndex++;
                }

                rollIndex++;
            }
            return score;
        }

        private int CalculateScoreForOpen(int score, int rollIndex)
        {
            score += rolls[rollIndex] + rolls[rollIndex + 1];
            return score;
        }

        private int CalculateScoreForSpare(int score, int rollIndex)
        {
            score += 10 + rolls[rollIndex + 2];
            return score;
        }

        private int CalculateScoreForStrike(int score, int rollIndex)
        {
            return score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        public bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

    }
}
