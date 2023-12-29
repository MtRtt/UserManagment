using Microsoft.AspNetCore.Mvc;
using UserManagment.Data;
using UserManagment.Models;

namespace UserManagment.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UserDbContext _UserDB;
        public CategoryController(UserDbContext userDb)
        {
            _UserDB = userDb;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _UserDB.categories;
            return View(CategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _UserDB.categories.Add(obj);
                _UserDB.SaveChanges();
                TempData["success"] = "دسته جدید با موفقیت ایجاد شد";
                //return View();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get for Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _UserDB.categories.Find(id);
            // var categoryFromDbFirst = _UserDB.categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromSiingle = _UserDB.categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _UserDB.categories.Update(obj);
                _UserDB.SaveChanges();
                TempData["success"] = "دسته  با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get for Edit
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _UserDB.categories.Find(id);
            // var categoryFromDbFirst = _UserDB.categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromSiingle = _UserDB.categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _UserDB.categories.Find(id);
            _UserDB.categories.Remove(obj);
            _UserDB.SaveChanges();
            TempData["success"] = "دسته  با موفقیت حذف شد";
            return RedirectToAction("Index");


        }
    }

}
