using System;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pinsKnockedDown)
        {
            AddPinsToRoll(pinsKnockedDown);
        }

        public int Score()
        {
            int score = 0;
            int currentRoll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                bool isStrike = IsStrike(currentRoll);

                if (isStrike)
                {
                    score = CalculateSrike(score, currentRoll);
                    currentRoll = IncrementRoll(currentRoll, isStrike);
                }
                else
                {
                    if (IsSpare(currentRoll))
                    {
                        score = CalculateSpare(score, currentRoll);
                    }
                    else
                    {
                        score = CalculateStandard(score, currentRoll);
                    }

                    currentRoll = IncrementRoll(currentRoll, isStrike);
                }
            }

            return score;
        }

        private void AddPinsToRoll(int pinsKnockedDown)
        {
            rolls[currentRoll++] = pinsKnockedDown;
        }

        private int IncrementRoll(int currentRoll, bool isStrike)
        {
            return  isStrike ? currentRoll + 1 : currentRoll + 2;
        }

        private bool IsSpare(int i)
        {
            return rolls[i] + rolls[i + 1] == 10;
        }

        private bool IsStrike(int i)
        {
            return rolls[i] == 10;
        }

        private int CalculateStandard(int s, int i)
        {
            s += rolls[i] + rolls[i + 1];
            return s;
        }

        private int CalculateSpare(int s, int i)
        {
            s += 10 + rolls[i + 2];
            return s;
        }

        private int CalculateSrike(int s, int i)
        {
            s += rolls[i] + rolls[i + 1] + rolls[i + 2];
            return s;
        }
    }
}
