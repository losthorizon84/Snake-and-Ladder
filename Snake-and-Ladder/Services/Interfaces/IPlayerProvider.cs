using Snake_and_Ladder.Domain;

namespace Snake_and_Ladder.Services.Interfaces
{
    public interface IPlayerProvider
    {
        /// <summary>
        /// Extrae de la cola el jugador con turno
        /// </summary>
        /// <returns></returns>
        Player Next();

        /// <summary>
        /// Total de jugadores
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Añade un jugador
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        void Add(string name, int id);


        /// <summary>
        /// Encola de nuevo a un jugador hasta su próximo turno
        /// </summary>
        /// <param name="player"></param>
        void Enqueue(Player player);
    }
}
