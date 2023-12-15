using bulky.DataAccess.Data;
using bulky.DataAccess.Repository.iRepository;
using bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bulky.DataAccess.Repository
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository 
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) //otan diladi ftiaxnete to dbcontext to pername stin repository<category>
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
