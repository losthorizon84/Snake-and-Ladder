namespace Snake_and_Ladder.Services.Interfaces
{
    public interface IGameService
    {
        void CreateBoard();

        void AddPlayer(string name, int id);

        void Start();
    }
}
