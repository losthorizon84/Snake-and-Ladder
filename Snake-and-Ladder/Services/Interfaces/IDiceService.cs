namespace Snake_and_Ladder.Services.Interfaces
{
    /// <summary>
    /// Interfaz para tratar los lanzamientos de dados de los jugadores
    /// </summary>
    public interface IDiceService
    {
        /// <summary>
        /// Lanza un dado y devuelve el valor extraído
        /// </summary>
        /// <returns></returns>
        int Roll();
    }
}
