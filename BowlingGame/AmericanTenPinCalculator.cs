using System.Linq;

namespace BowlingGame
{
    public class AmericanTenPinCalculator : IRollCalculator
    {
        private const int STRIKE = 10;
        private const int SPARE = 10;
        private const int TOTALFRAMES = 10;

        public int GetScoreForAllRollsInGame(int[] rolls)
        {
            int score = 0;
            int rollNumber = 0;

            for (int frame = 0; frame < TOTALFRAMES; frame++)
            {
                if (IsStrike(rolls, rollNumber))
                {
                    score += 10 + rolls[rollNumber + 1] + rolls[rollNumber + 2];
                }
                else if (IsSpare(rolls, rollNumber))
                {
                    score += 10 + rolls[rollNumber + 2];
                    rollNumber++;
                }
                else
                {
                    score += rolls[rollNumber] + rolls[rollNumber + 1];
                    rollNumber++;
                }

                rollNumber++;
            }

            return score;
        }

        private static bool IsSpare(int[] rolls, int rollNumber)
        {
            return rolls[rollNumber] + rolls[rollNumber + 1] == SPARE;
        }

        private static bool IsStrike(int[] rolls, int rollNumber)
        {
            return rolls[rollNumber] == STRIKE;
        }
    }
}