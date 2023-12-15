using bulky.DataAccess.Repository.iRepository;
using bulky.DataAccess.Data;
using bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _UnitOfWork;//Μια μεταβλητη που περναμε μέσα local var για να το προβαλουμε
        public CategoryController(IUnitOfWork UnitOfWork)//οτι παρουμε απο τον controller το κανουμε assign σε local var
        {
            _UnitOfWork = UnitOfWork;
        }


        public IActionResult Index()
        {
            List<Category> objCategoryList = _UnitOfWork.Category.GetAll().ToList();
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
                _UnitOfWork.Category.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Επιτυχής δημιουργία κατηγορίας";
                return RedirectToAction("Index");  //τον στελνουμε να μας ξανα δειξει ολες τις κατηγοριες
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoriFromDb = _UnitOfWork.Category.Get(u => u.Id == id);
            //Category categoriFromDb = _db.Categories.Find(id); //ΨΑΨΝΩ ΚΑΤΙ ΣΤΗΝ ΒΑΣΗ
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
                _UnitOfWork.Category.Update(obj);
                _UnitOfWork.Save();
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
            Category categoriFromDb = _UnitOfWork.Category.Get(u => u.Id == id); //ΨΑΨΝΩ ΚΑΤΙ ΣΤΗΝ ΒΑΣΗ
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
            Category objDelete = _UnitOfWork.Category.Get(u => u.Id == id); //ΨΑΨΝΩ ΚΑΤΙ ΣΤΗΝ ΒΑΣΗ
                                                                            // Category categoriFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); ΔΕΥΤΕΡΟΣ ΤΡΟΠΟΣ
            if (objDelete == null)
            {
                return NotFound();
                return NotFound();
            }
            _UnitOfWork.Category.Delete(objDelete);
            _UnitOfWork.Save();
            TempData["success"] = "Επιτυχής διαγραφή κατηγορίας";
            return RedirectToAction("Index");  //τον στελνουμε να μας ξανα δειξει ολες τις κατηγοριες
        }
    }
}
