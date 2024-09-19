using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {


        private DatabaseContext _db;
        private DbSet<T> _table = null;
        public Repository()
        {
            _db = new DatabaseContext();
            _table = _db.Set<T>();
        }
        public Repository(DatabaseContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                    .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                     (_table, (current, expression) => current.Include(expression));
            }
            return _table.ToList();
        }

        public IEnumerable<T> GetAll()
        {
           
            return _table.ToList();
        }


        public void Insert(T obj)
        {
            _table.Add(obj);
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }


        public T GetById(int id)
        {
            return _table.Find(id);
        }


        //public void Add(UserFollow entity)
        //{
        //    _db.UserFollows.Add(entity);
        //    _db.SaveChanges();
        //}

        //public void Remove(UserFollow entity)
        //{
        //    _db.UserFollows.Remove(entity);
        //    _db.SaveChanges();
        //}


       






    }
}
