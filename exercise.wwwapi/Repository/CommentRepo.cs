using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace exercise.wwwapi.Repository
{
    public class CommentRepo<T> : ICommentRepo<T> where T : class
    {


        private DatabaseContext _db;
        private DbSet<T> _table = null;
        public CommentRepo()
        {
            _db = new DatabaseContext();
            _table = _db.Set<T>();
        }
        public CommentRepo(DatabaseContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAllComments()
        {
            return _table.ToList();
        }

        //public T GetById(int id)
        //{
        //    return _table.Find(id);
        //}


        public void Insert(T obj)
        {
            _table.Add(obj);
        }


        public void Save()
        {
            _db.SaveChanges();
        }

       

        //public IEnumerable<Comment> GetAllWithBlogPost() 
        //{ 
        //    return _db.Set<Comment>().Include(x => x.BlogPost).ToList();
        //}

        public T GetById(int id)
        {
            return _table.Find(id);
        }

    }

}

    

