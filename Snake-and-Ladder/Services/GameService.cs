using Microsoft.Extensions.Logging;
using Snake_and_Ladder.Services.Interfaces;

namespace Snake_and_Ladder.Services
{
    public class GameService : IGameService
    {
        private readonly ILogger<IGameService> _logger;

        private readonly IPlayerProvider _playerProvider;
        private readonly IDiceService _diceService;
        private readonly IBoardProvider _boardProvider;

        public GameService(ILogger<IGameService> logger, IPlayerProvider playerProvider, IDiceService diceService, IBoardProvider boardProvider)
        {
            _logger = logger;
            _playerProvider = playerProvider;
            _diceService = diceService;
            _boardProvider = boardProvider;
        }

        public void AddPlayer(string name, int id)
        {
            _playerProvider.Add(name, id);
        }

        public void CreateBoard()
        {
            //Ladders
            _boardProvider.AddLadder(2, 38);
            _boardProvider.AddLadder(7, 14);
            _boardProvider.AddLadder(8, 31);
            _boardProvider.AddLadder(15, 26);
            _boardProvider.AddLadder(28, 84);
            _boardProvider.AddLadder(21, 42);
            _boardProvider.AddLadder(36, 44);
            _boardProvider.AddLadder(51, 67);
            _boardProvider.AddLadder(78, 98);
            _boardProvider.AddLadder(71, 91);
            _boardProvider.AddLadder(87, 94);

            //Snakes            
            _boardProvider.AddSnake(99, 80);
            _boardProvider.AddSnake(95, 75);
            _boardProvider.AddSnake(92, 88);
            _boardProvider.AddSnake(89, 68);
            _boardProvider.AddSnake(74, 53);
            _boardProvider.AddSnake(64, 60);
            _boardProvider.AddSnake(62, 19);
            _boardProvider.AddSnake(49, 11);
            _boardProvider.AddSnake(46, 25);            
            _boardProvider.AddSnake(16, 6);

        }

        public void Start()
        {
            if(_playerProvider.Count() < 2)
            {
                _logger.LogError("El número mínimo de jugadores es 2");
                throw new System.Exception("El número mínimo de jugadores es 2");
            }

            _logger.LogWarning("El juego va a comenzar!");
            
            bool gameIsOver = false;
            while (!gameIsOver)
            {
                var currentPlayer = _playerProvider.Next();
                var dice = _diceService.Roll();
                _boardProvider.Move(currentPlayer, dice);

                gameIsOver = currentPlayer.Position == 100;
                _logger.LogInformation($"El jugador {currentPlayer.Id}: {currentPlayer.Name} se mueve hacia la casilla {currentPlayer.Position}");

                if (gameIsOver)
                {
                    currentPlayer.IsTheWinner = true;
                    _logger.LogWarning($"El juego ha terminado. El vencedor ha sido el jugador {currentPlayer.Id}");
                }

                //Enqueue player again
                _playerProvider.Enqueue(currentPlayer);
            }            
        }
    }
}
