using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Il campo email è obbligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Il testo del messagio è obbligatorio")]
        public string Text { get; set; }

        public Message() { }
    }
}
