using Microsoft.Extensions.Logging;
using Snake_and_Ladder.Services.Interfaces;
using System.Collections.Generic;

namespace Snake_and_Ladder.Services
{
    public class ScoreBoard : IScoreBoard
    {
        private readonly ILogger<IScoreBoard> _logger;
        private IDictionary<int, int> _score;

        public ScoreBoard(ILogger<IScoreBoard> logger)
        {
            _logger = logger;
            _score = new Dictionary<int, int>();
        }

        public int GetPosition(int playerId)
        {
            return _score[playerId];
        }

        public bool IsWinner(int playerId)
        {
            return _score[playerId] == 100;
        }

        public void StartPlayer(int playerId)
        {
            if (!_score.ContainsKey(playerId))
            {
                _score.Add(playerId, 1);
            }
        }

        public void SetPosition(int playerId, int steps)
        {
            _score[playerId] += steps;
        }
    }
}
