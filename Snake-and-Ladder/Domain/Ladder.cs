namespace Snake_and_Ladder.Domain
{
    /// <summary>
    /// Representa el elemento escalera del tablero 
    /// </summary>
    public class Ladder : BoardEntity
    {
        public Ladder(int head, int tail) 
            : base(head, tail)
        {
        }
    }
}
