using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        [Authorize(Roles ="ADMIN")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
