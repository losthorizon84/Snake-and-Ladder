namespace Snake_and_Ladder.Domain
{
    /// <summary>
    /// Representa el elemento serpiente del tablero 
    /// </summary>
    public class Snake : BoardEntity
    {
        public Snake(int head, int tail) 
            : base(head, tail)
        {
        }
    }
}
