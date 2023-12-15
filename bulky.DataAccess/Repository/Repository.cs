using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using bulky.DataAccess.Data;
using bulky.DataAccess.Repository.iRepository;
using Microsoft.EntityFrameworkCore;

namespace bulky.DataAccess.Repository
{
    public class Repository<T> : iRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset; //gia na doume ti tupo table exei
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
            //_db.Categories == dbset
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }

    }
}
