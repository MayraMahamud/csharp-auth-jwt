using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
       
        IEnumerable<T> GetAll();
        void Insert(T obj);
        void Save();
        void Update(T obj);
        T GetById(int id); 
        //void Add(UserFollow entity);
        //void Remove(UserFollow entity); 
    }
}
