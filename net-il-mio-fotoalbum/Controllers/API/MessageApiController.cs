
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class MessageApiController : ControllerBase
    {
        private PhotoContext context;

        public MessageApiController(PhotoContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] Message data)
        {
            if(data == null)
            {
                return BadRequest();
            }
            using(context)
            {
                context.Message.Add(data);
                context.SaveChanges();
                
                return Ok();
            }

        }
    }
}
