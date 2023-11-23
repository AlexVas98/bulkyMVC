using bulkyWeb.Data;
using bulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;//Μια μεταβλητη που περναμε μέσα local var για να το προβαλουμε
        public CategoryController(ApplicationDbContext db)//οτι παρουμε απο τον controller το κανουμε assign σε local var
        {
            _db = db;
        }


        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View();
        }
    }
}
