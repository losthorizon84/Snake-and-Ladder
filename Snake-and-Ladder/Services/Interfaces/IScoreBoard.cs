namespace Snake_and_Ladder.Services.Interfaces
{
    public interface IScoreBoard
    {
        void StartPlayer(int playerId);

        int GetPosition(int playerId);

        void SetPosition(int playerId, int steps);

        bool IsWinner(int playerId);
    }
}
