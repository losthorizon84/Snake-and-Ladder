using Microsoft.Extensions.Logging;
using Snake_and_Ladder.Services.Interfaces;
using System;

namespace Snake_and_Ladder.Services
{
    public class DiceService : IDiceService
    {
        private readonly ILogger<IDiceService> _logger;

        public DiceService(ILogger<IDiceService> logger)
        {
            _logger = logger;
        }

        public int Roll()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 6);

            _logger.LogInformation($"El valor obtenido al lanzar el dado ha sido: {dice}");

           return dice;
        }
    }
}
