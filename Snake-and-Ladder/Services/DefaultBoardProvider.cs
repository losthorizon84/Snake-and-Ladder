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

        public void Move(Player player, int dice)
        {
            player.Position += dice;

            if (player.Position > 100)
            {
                player.Position -= dice;
            }
            else if (player.Position < 100)
            {
                var entity = _boardEntityProvider.FindSingle(_ => _.Head == player.Position || _.Tail == player.Position);
                if (entity != null)
                {
                    if (entity is Snake && entity.Head == player.Position)
                    {
                        _logger.LogWarning($"El jugador {player.Id} ha caído en una casilla con penalización [{player.Position}]. Retrocede a la casilla {entity.Tail}");
                        player.Position = entity.Tail;
                    }
                    else if (entity is Ladder && entity.Tail == player.Position)
                    {
                        _logger.LogWarning($"El jugador {player.Id} ha caído en una casilla con ventaja [{player.Position}]. Avanza a la casilla {entity.Head}");
                        player.Position = entity.Head;
                    }
                }
            }
        }

    }
}
