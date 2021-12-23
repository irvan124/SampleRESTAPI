using SampleRESTAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    // Add Custom Validation from ValidationAttributes Folder
    [StudentFirstLastMustBeDifferentAttribute]
    // Instance IValidation Object berdasarkan Table2 field yang ada
    //Custom Error Validator
    public class StudentForCreateDto 
    {
        // Add Validation for prevent the input not blank or null using [Required]
        // Data Anotation
        [Required(ErrorMessage ="Kolom Firstname harus di isi")]
        [MaxLength(20, ErrorMessage = "Tidak boleh dari 20 karakter")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Kolom Lastname harus di isi.")]
        [MaxLength(20, ErrorMessage ="Tidak boleh lebih dari 20 karakter")]
        public string LastName { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }

        // Menambahkan Validation berdasarkan Table table yang ada
       /* public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(FirstName == LastName)
            {
                yield return new ValidationResult("FirstName dan LastName tidak boleh sama",
                    new[] { "StudentForCreateDto" });
            }
        }
       */
    }
}
