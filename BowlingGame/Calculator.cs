namespace BowlingGame
{
    class Calculator
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

        public int GetScoreForRolls()
        {
            int score = 0;
            int i = 0;

            for (int f = 0; f < 10; f++)
            {
                // strikes
                if (rolls[i] == 10)
                    score += 10 + rolls[i + 1] + rolls[i + 2];
                else
                {
                    // spares
                    if (rolls[i] + rolls[i + 1] == 10)
                    {
                        score += 10 + rolls[i + 2];
                        i++;
                    }
                    else
                    {
                        score += rolls[i] + rolls[i + 1];
                        i++;
                    }
                }

                i++;
            }

            return score;
        }
    }
}
