namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frames = 0; frames < 10; frames++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfFrameRolls(roll);
                    roll += 2;
                }
            }
            return score;
        }

        private int SumOfFrameRolls(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
    }
}
