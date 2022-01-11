using Snake_and_Ladder.Domain;

namespace Snake_and_Ladder.Services.Interfaces
{
    public interface IGenericProvider<T>
        where T : IDentifiable
    {        
        void Add(T t);
    }
}
