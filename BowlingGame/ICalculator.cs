using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public interface ICalculator
    {
        /// <summary>
        /// Given an array of rolls for a game of bowling, calculate and return the final score.
        /// </summary>
        /// <param name="rolls">Array of pins knocked down per roll</param>
        /// <returns>The calculated score</returns>
        int GetScoreForAllRollsInGame(int[] rolls);
    }
}
