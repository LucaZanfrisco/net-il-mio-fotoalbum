using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Lunghezza massima di 50 caratteri")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Lunghezza massima 500 caratteri")]
        public string Image { get; set; }

        [Required]
        
        public bool Visible { get; set; }

        public List<Category>? Categories { get; set; }

    }
}
