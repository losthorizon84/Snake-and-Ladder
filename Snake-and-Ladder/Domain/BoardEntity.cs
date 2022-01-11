namespace Snake_and_Ladder.Domain
{
    /// <summary>
    /// Clase abstracta para representar elementos genéricos que van a formar parte del tablero
    /// </summary>
    public abstract class BoardEntity : IDentifiable
    {
        public int Id { get; set; }
        public int Head { get; private set; }
        public int Tail { get; private set; }

        public BoardEntity(int head, int tail)
        {
            Head = head;
            Tail = tail;
        }
    }
}
