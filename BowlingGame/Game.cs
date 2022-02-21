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

            for (int frame = 0; frame < 10; frame++)
			{
				var isStrike = IsStrike(roll);
				if (isStrike)
				{
					score += CalculateValueForStrike(roll);
				}
				else if (IsSpare(roll))
				{
					score += CalculateValueForSpare(roll);
				}
				else
				{
					score += CalculatePinValue(roll);
				}

				roll = IncrementFrame(roll, isStrike);
			}

			return score;
        }

		private int CalculatePinValue(int roll)
		{
			return rolls[roll] + rolls[roll + 1];
		}

		private int CalculateValueForSpare(int roll)
		{
			return 10 + rolls[roll + 2];
		}

		private int CalculateValueForStrike(int roll)
		{
			return 10 + rolls[roll + 1] + rolls[roll + 2];
		}

		private bool IsSpare(int roll)
		{
			return rolls[roll] + rolls[roll + 1] == 10;
		}

		private bool IsStrike(int roll)
		{
			return rolls[roll] == 10;
		}

		private int IncrementFrame(int roll, bool isStrike = false)
		{
			var frame = roll;
			if (isStrike)
			{
				frame ++;
			}
			else
			{
				frame += 2;
			}
			return frame;
		}
	}
}
