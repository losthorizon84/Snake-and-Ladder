using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snake_and_Ladder.Services;
using Snake_and_Ladder.Services.Interfaces;

namespace Snake_and_Ladder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateDefaultBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                services.GetRequiredService<Worker>().Execute();
            }
            
        }

        public static IHostBuilder CreateDefaultBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IBoardProvider, DefaultBoardProvider>();
                    services.AddScoped<IGameService, GameService>();
                    services.AddScoped<IPlayerProvider, PlayerProvider>();
                    services.AddScoped<IBoardEntityProvider, BoardEntityProvider>();
                    services.AddScoped<IDiceService, DiceService>();
                    services.AddScoped<IScoreBoard, ScoreBoard>();
                    services.AddScoped<Worker>();
                });
    }
}
