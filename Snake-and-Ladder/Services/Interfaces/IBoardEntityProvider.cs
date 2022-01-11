using Snake_and_Ladder.Domain;
using System;
using System.Linq.Expressions;

namespace Snake_and_Ladder.Services.Interfaces
{
    public interface IBoardEntityProvider : IGenericProvider<BoardEntity>
    {
        /// <summary>
        /// Busca en una casilla del tablero si hay algún elemento
        /// </summary>
        BoardEntity FindSingle(Expression<Func<BoardEntity, bool>> criteria);
    }
}
