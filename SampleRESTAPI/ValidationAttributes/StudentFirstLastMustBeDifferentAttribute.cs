using SampleRESTAPI.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.ValidationAttributes
{
    public class StudentFirstLastMustBeDifferentAttribute : ValidationAttribute
    {

        // Menambahkan Validation Rule terpisah yang nanti nya akan di implementasi ke Dto (Data Transfer Object)
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (StudentForCreateDto)validationContext.ObjectInstance;
            if(student.FirstName == student.LastName)
            {
                return new ValidationResult("Firstname dan Lastname tidak boleh sama", new[] { nameof(StudentForCreateDto) });
            }
            return ValidationResult.Success;
        }
       
    }
}
