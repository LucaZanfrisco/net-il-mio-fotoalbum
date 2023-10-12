using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotoApiController : ControllerBase
    {
        private PhotoContext _db;

        public PhotoApiController(PhotoContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllPhotos()
        {
            using(_db)
            {
                List<Photo> photos = _db.Photos.Where(photo => photo.Visible == true).ToList();
                if(photos != null)
                {
                    return Ok(photos);
                }
            }

            return Ok(new {result = false, Message = "Errore nella risposta"});
        }

        [HttpGet]
        public IActionResult GetPhotosByTitle(string? search)
        {
            if(search == null)
            {
                List<Photo> photos = _db.Photos.Where(photo => photo.Visible == true).ToList();
                return Ok(photos);
            }

            using(_db)
            {
                List<Photo>? photo = _db.Photos.Where(photo => photo.Title.ToLower().Contains(search.ToLower()) && photo.Visible == true).ToList();
                if(photo != null) 
                {
                    return Ok(photo);
                }
                else
                {
                    return Ok(new { result = false, Message = "Nessuna foto trovata" });
                }
    
            }
        }
    }
}
