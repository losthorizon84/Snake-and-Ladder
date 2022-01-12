using Snake_and_Ladder.Services.Interfaces;
using System;

namespace Snake_and_Ladder
{
    class Worker
    {
        private readonly IGameService _gameService;

        public Worker(IGameService gameService )
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            _gameService.CreateBoard();

            bool validSelection = false;
            while (!validSelection)
            {
                validSelection = true;
                Console.WriteLine();
                Console.WriteLine("Seleccione el número de jugadores:");
                Console.WriteLine("1. Juego de 1 Jugador");
                Console.WriteLine("2. Juego de 2 Jugadores");
                Console.WriteLine("3. Juego de 3 Jugadores");
                Console.WriteLine("4. Juego de 4 Jugadores");
                switch (Console.ReadLine())
                {
                    case "1":
                        Play(1);
                        break;
                    case "2":
                        Play(2);
                        break;
                    case "3":
                        Play(3);
                        break;
                    case "4":
                        Play(4);
                        break;
                    default:
                        validSelection = false;
                        Console.Clear();
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }

        private void Play(int nPlayers)
        {
            for (int i = 0; i < nPlayers; i++)
            {
                Console.WriteLine($"Indique el nombre del jugador {i + 1}");
                string name = Console.ReadLine();
                _gameService.AddPlayer(name, i + 1);
            }

            _gameService.Start();
        }


    }
}
