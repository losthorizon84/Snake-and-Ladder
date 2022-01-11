using Microsoft.Extensions.Logging;
using Snake_and_Ladder.Domain;
using Snake_and_Ladder.Services.Interfaces;

namespace Snake_and_Ladder.Services
{
    class BoardEntityProvider : BaseProvider<BoardEntity>, IBoardEntityProvider
    {
        public BoardEntityProvider(ILogger<BaseProvider<BoardEntity>> logger) 
            : base(logger)
        {
        }
    }
}
