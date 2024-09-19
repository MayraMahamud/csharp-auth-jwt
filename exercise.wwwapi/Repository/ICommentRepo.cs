using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ICommentRepo<T> where T : class
    {
        IEnumerable<T> GetAllComments();
        //T GetById(int id);
        void Insert(T obj);
        void Save();
        T GetById(int id);

    }
}
