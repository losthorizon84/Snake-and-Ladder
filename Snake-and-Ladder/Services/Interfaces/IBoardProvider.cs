using Snake_and_Ladder.Domain;

namespace Snake_and_Ladder.Services.Interfaces
{
    public interface IBoardProvider
    {
        int Size { get; }

        void AddSnake(int head, int tail);

        void AddLadder(int tail, int head);

        int Move(int playerId, int currentPosition, int dice);        

    }
}
