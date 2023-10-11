using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;
using System.Runtime.ConstrainedExecution;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {

        private PhotoContext _db;

        public PhotoController(PhotoContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Index()
        {
            using(_db)
            {
                List<Photo> photos = _db.Photos.ToList();
                return View("Index", photos);
            }

        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            using(_db)
            {
                Photo foundedPhoto = _db.Photos.Where(photo => photo.Id == id).Include(photo => photo.Categories).FirstOrDefault();
                if(foundedPhoto == null)
                {
                    return RedirectToAction("Index");
                }

                return View("Detail", foundedPhoto);
            }
                
        }

        [HttpGet]
        public IActionResult Create()
        {

            using(_db)
            {
                List<Category> categories = _db.Categories.ToList();
                PhotoFormModel model = new PhotoFormModel();
                List<SelectListItem> listCategories = new List<SelectListItem>();

                foreach(Category category in categories)
                {
                    listCategories.Add(new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });
                }
                model.Categories = listCategories;

                return View("Create", model);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhotoFormModel data)
        {

            if(!ModelState.IsValid)
            {
                using(_db)
                {
                    List<Category> categories = _db.Categories.ToList();
                    List<SelectListItem> listCategories = new List<SelectListItem>();
                    foreach(Category category in categories)
                    {
                        listCategories.Add(new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });
                    }
                    data.Categories = listCategories;
                    return View("Create", data);
                }
            }

            using(_db)
            {
                data.Photos.Categories = new List<Category>();

                MemoryStream stream = new MemoryStream();
                data.ImageFile.CopyTo(stream);
                data.Photos.Image = stream.ToArray();

                if(data.SelectedCategories != null)
                {
                    foreach(string categoryString in data.SelectedCategories)
                    {
                        int categoryId = int.Parse(categoryString);
                        Category category = _db.Categories.Where(category => category.Id == categoryId).FirstOrDefault();
                        data.Photos.Categories.Add(category);
                    }
                }
                _db.Photos.Add(data.Photos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


        }
    }
}
