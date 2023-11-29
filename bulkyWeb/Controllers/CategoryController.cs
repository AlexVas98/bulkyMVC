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
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  //gia create category
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Δεν πρέπει το όνομα να είναι ίδιο με το αριθμό παραγγελείας");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Δεν πρέπει το όνομα να είναι test");
            }
            if (ModelState.IsValid)//ελεγχει αν εχουμε βαλει σωστα στοιχεια (validate εχουμε βαλει στο model
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Επιτυχής δημιουργία κατηγορίας";
                return RedirectToAction("Index");  //τον στελνουμε να μας ξανα δειξει ολες τις κατηγοριες
            }
           return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category categoriFromDb = _db.Categories.Find(id); //ΨΑΨΝΩ ΚΑΤΙ ΣΤΗΝ ΒΑΣΗ
           // Category categoriFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); ΔΕΥΤΕΡΟΣ ΤΡΟΠΟΣ
            if (id == null || id == 0)
            {
                return NotFound();
            }
            return View(categoriFromDb);
        }

        [HttpPost]  //gia create category
        public IActionResult Edit(Category obj)
        {      
            if (ModelState.IsValid)//ελεγχει αν εχουμε βαλει σωστα στοιχεια (validate εχουμε βαλει στο model
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Επιτυχής επεξεργασία κατηγορίας";
                return RedirectToAction("Index");  //τον στελνουμε να μας ξανα δειξει ολες τις κατηγοριες
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoriFromDb = _db.Categories.Find(id); //ΨΑΨΝΩ ΚΑΤΙ ΣΤΗΝ ΒΑΣΗ
                                                               // Category categoriFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); ΔΕΥΤΕΡΟΣ ΤΡΟΠΟΣ
            if (id == null || id == 0)
            {
                return NotFound();
            }
            return View(categoriFromDb);
        }

        [HttpPost, ActionName("Delete")]  //gia create category

        public IActionResult DeletePost(int? id)
        {
            Category objDelete = _db.Categories.Find(id); //ΨΑΨΝΩ ΚΑΤΙ ΣΤΗΝ ΒΑΣΗ
                                                               // Category categoriFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); ΔΕΥΤΕΡΟΣ ΤΡΟΠΟΣ
            if (objDelete == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(objDelete);
            _db.SaveChanges();
            TempData["success"] = "Επιτυχής διαγραφή κατηγορίας";
            return RedirectToAction("Index");  //τον στελνουμε να μας ξανα δειξει ολες τις κατηγοριες
        }
    }
}
