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
        private readonly IScoreBoard _scoreBoard;

        public GameService(ILogger<IGameService> logger, IPlayerProvider playerProvider, IDiceService diceService, IBoardProvider boardProvider, IScoreBoard scoreBoard)
        {
            _logger = logger;
            _playerProvider = playerProvider;
            _diceService = diceService;
            _boardProvider = boardProvider;
            _scoreBoard = scoreBoard;
        }

        public void AddPlayer(string name, int id)
        {
            _playerProvider.Add(name, id);
            _scoreBoard.StartPlayer(id);
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
                var steps =_boardProvider.Move(currentPlayer.Id, _scoreBoard.GetPosition(currentPlayer.Id), dice);
                _scoreBoard.SetPosition(currentPlayer.Id, steps);

                gameIsOver = _scoreBoard.IsWinner(currentPlayer.Id);
                _logger.LogInformation($"El jugador {currentPlayer.Id}: {currentPlayer.Name} se mueve hacia la casilla {_scoreBoard.GetPosition(currentPlayer.Id)}");

                if (gameIsOver)
                {
                    _logger.LogWarning($"El juego ha terminado. El vencedor ha sido el jugador {currentPlayer.Id}");
                }

                //Enqueue player again
                _playerProvider.Enqueue(currentPlayer);
            }            
        }
    }
}
