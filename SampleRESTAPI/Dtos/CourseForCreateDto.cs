using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    public class CourseForCreateDto : IValidatableObject
    {
        [Required]
        

        public string Title { get; set; }
        [Required]
        //Add with range Validation
        // [NotMapped]
        //[Column(TypeName ="decimal(5,2)")]
        
        public int Credits { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!Title.StartsWith("Training") || Title.Length >= 50)
            {
                yield return new ValidationResult("Harus dimulai dengan kata Training lebih kecil dan lebih dari 50 Karakter", new[] { "Title" });
            }
            if (Credits >= 10)
            {
                yield return new ValidationResult("Harus lebih kecil dari 10 Credit", new[] { "Credits" });
            }
        }
    }
}
