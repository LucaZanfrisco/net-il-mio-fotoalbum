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
                List<Photo> photos = _db.Photos.ToList();
                if(photos != null)
                {
                    return Ok(photos);
                }
            }

            return Ok(new {result = false, Message = "Errore nella risposta"});
        } 

    }
}
