using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {
        public Photo Photos { get; set; }
        public Category Category { get; set; }
        public List<Photo> listPhotos { get; set; }
        public List<Category> listCategories { get; set; }
        public List<SelectListItem>? Categories { get; set;}
        public List<string>? SelectedCategories { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
