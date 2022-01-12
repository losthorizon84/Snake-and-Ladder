using Microsoft.Extensions.Logging;
using Snake_and_Ladder.Domain;
using Snake_and_Ladder.Services.Interfaces;

namespace Snake_and_Ladder.Services
{
    public class DefaultBoardProvider : IBoardProvider
    {        
        const int SIZE = 100;
        
        private readonly ILogger<IBoardProvider> _logger;
        private readonly IBoardEntityProvider _boardEntityProvider;

        public DefaultBoardProvider(ILogger<IBoardProvider> logger, IBoardEntityProvider boardEntityProvider)
        {
            _logger = logger;
            _boardEntityProvider = boardEntityProvider;
        }

        public int Size => SIZE;

        public void AddLadder(int tail, int head)
        {
            _boardEntityProvider.Add(new Ladder(head, tail));
        }

        public void AddSnake(int head, int tail)
        {
            _boardEntityProvider.Add(new Snake(head, tail));
        }

        public int Move(int playerId, int currentPosition, int dice)
        {
            int newPosition = currentPosition + dice;
            int steps = dice;
            if(newPosition > 100)
            {
                steps = 0;
            }
            else if (newPosition < 100)
            {
                var entity = _boardEntityProvider.FindSingle(_ => _.Head == newPosition || _.Tail == newPosition);
                if (entity != null)
                {
                    if (entity is Snake && entity.Head == newPosition)
                    {
                        _logger.LogWarning($"El jugador {playerId} ha caído en una casilla con penalización [{newPosition}]. Retrocede a la casilla {entity.Tail}");
                        newPosition = entity.Tail;
                    }
                    else if (entity is Ladder && entity.Tail == newPosition)
                    {
                        _logger.LogWarning($"El jugador {playerId} ha caído en una casilla con ventaja [{newPosition}]. Avanza a la casilla {entity.Head}");
                        newPosition = entity.Head;
                    }                    
                }
                steps = newPosition - currentPosition;
            }


            return steps;
        }

    }
}
