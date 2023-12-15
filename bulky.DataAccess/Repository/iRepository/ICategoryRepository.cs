using bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulky.DataAccess.Repository.iRepository
{
    public interface ICategoryRepository : iRepository<Category>
    {
        void Update(Category obj);
    }
}
