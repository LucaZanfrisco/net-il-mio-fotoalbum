using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Validation
{
    public class ImageFileValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file != null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Tipo di file non supportato");
        }
    }
}
