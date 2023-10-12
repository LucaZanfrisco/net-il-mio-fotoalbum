using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class MessageController : Controller
    {
        private PhotoContext context;

        public MessageController(PhotoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using(context)
            {
                List<Message> messages = context.Message.ToList();
                return View("Index", messages);
            }
            
        }

        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return View("Error");
            }
            using(context)
            {
                Message deleteMessage = context.Message.Where(message => message.Id == id).FirstOrDefault();
                if(deleteMessage != null)
                {
                    context.Message.Remove(deleteMessage);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
