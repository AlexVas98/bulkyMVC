using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bulky.DataAccess.Repository.iRepository
{
    public interface iRepository<T> where T :class //To kanoume generic dioti 8a exoume polla tables
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter); // linq expression otan zitame kapoio sugkekrimeno id
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);

    }
}
