using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Validations
{
    public class WeightFileValidation : ValidationAttribute
    {
        private readonly int maxWeightInMegaBytes;

        public WeightFileValidation(int MaxWeightInMegaBytes)
        {
            maxWeightInMegaBytes = MaxWeightInMegaBytes;
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

            if (formFile.Length > maxWeightInMegaBytes * 1024 * 1024)
            {
                return new ValidationResult(
                    $"El peso del archivo no debe ser mayor a {maxWeightInMegaBytes}mb"
                );
            }

            return ValidationResult.Success;
        }
    }
}
