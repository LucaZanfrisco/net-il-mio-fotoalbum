using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Il campo NOME è obbligatorio")]
        [StringLength(50, ErrorMessage ="Lunghezza massima 50 caratteri")]
        public string Name { get; set; }

        public List<Photo>? Photos { get; set; }
    }
}
