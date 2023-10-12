using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class CategoryController : Controller
    {

        private PhotoContext _db;

        public CategoryController(PhotoContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            using(_db)
            {
                List<Category> categories = _db.Categories.Include(category => category.Photos).ToList();

                return View("Index", categories);
            }
        }

        public IActionResult Detail(int id)
        {
            using(_db)
            {
                Category? category = _db.Categories.Where(category => category.Id == id).Include(category => category.Photos).FirstOrDefault();

                if(category != null)
                {
                    return View("Detail", category);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", category);
            }
            using(_db)
            {
                if(category.Name != null)
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(_db)
            {
                Category? category = _db.Categories.Where(category => category.Id == id).Include(category => category.Photos).FirstOrDefault();

                if(category != null)
                {
                    _db.Categories.Remove(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }
    }
}
