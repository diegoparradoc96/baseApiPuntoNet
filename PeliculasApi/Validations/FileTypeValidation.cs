using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Validations
{
    public class FileTypeValidation : ValidationAttribute
    {
        private readonly string[] validTypes;

        public FileTypeValidation(string[] validTypes)
        {
            this.validTypes = validTypes;
        }

        public FileTypeValidation(FileTypeGroup fileTypeGroup)
        {
            if (fileTypeGroup == FileTypeGroup.Imagen)
            {
                validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (!validTypes.Contains(formFile.ContentType))
            {
                return new ValidationResult(
                    $"El tipo del archivo debe ser uno de los siguientes: {string.Join(", ", validTypes)}"
                );
            }

            return ValidationResult.Success;
        }
    }
}
