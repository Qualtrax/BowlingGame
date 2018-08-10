namespace BowlingGame
{
    public class Calculator : ICalculator
    {
        public int GetScoreForAllRollsInGame(int[] rolls)
        {
            int i = 0, score = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if ( rolls[i] == 10)
                {
                    score += 10 + rolls[i + 1] + rolls[i + 2];
                }
                // spares
                else if (rolls[i] + rolls[i + 1] == 10)
                {
                    score += 10 + rolls[i + 2];
                    i++;
                }
                else
                {
                    score += rolls[i] + rolls[i + 1];
                    i++;
                }

                i++;
            }
            return score;
        }
    }
}
