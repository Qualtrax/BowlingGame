namespace BowlingGame
{
    public class Calculator : ICalculator
    {
        private const int RollsOnStrike = 1;
        private const int RollsOnSpare = 2;
        private const int RollsOnOpenFrame = 2;

        public int GetScoreForAllRollsInGame(int[] rolls)
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                // strikes 
                if (rolls[roll] == 10)
                {
                    score += 10 + rolls[roll + 1] + rolls[roll + 2];
                    roll += RollsOnStrike;
                }
                else
                // spares
                if (rolls[roll] + rolls[roll + 1] == 10)
                {
                    score += 10 + rolls[roll + 2];
                    roll += RollsOnSpare;
                }
                else
                {
                    score += rolls[roll] + rolls[roll + 1];
                    roll += RollsOnOpenFrame;
                }
            }

            return score;
        }
    }
}
