namespace BowlingGame
{
    public class GameState
    {
        private int _currentRoll = 0;

        // 21 is the max rolls per game
        private int[] _rolls = new int[21];

        private IRollCalculator _rollCalculator;

        public GameState(IRollCalculator rollCalculator)
        {
            this._rollCalculator = rollCalculator;
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int GetScore()
        {
            var score = _rollCalculator.GetScoreForAllRollsInGame(_rolls);

            return score;
        }
    }
}
