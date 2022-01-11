using Microsoft.Extensions.Logging;
using Snake_and_Ladder.Domain;
using Snake_and_Ladder.Services.Interfaces;
using System.Collections.Generic;

namespace Snake_and_Ladder.Services
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly ILogger<BaseProvider<Player>> _logger;
        private Queue<Player> _players;
        private int _count;

        public PlayerProvider(ILogger<BaseProvider<Player>> logger) 
        {
            _logger = logger;
            _players = new Queue<Player>();
            _count = 0;
        }

        public void Enqueue(Player player)
        {
            _players.Enqueue(player);
        }

        public void Add(string name, int id)
        {
            _players.Enqueue(new Player(id, name));
            _logger.LogDebug($"Añadido el jugador {id}: {name}");
            _count += 1;
        }

        public int Count()
        {
            return _count;
        }

        public Player Next()
        {
            var player = _players.Dequeue();
            _logger.LogInformation($"Turno del jugador {player.Id}: {player.Name}");
            return player;
        }
    }
}
