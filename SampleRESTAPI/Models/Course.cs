using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRESTAPI.Models
{
    //Using Data anotation Schema
    //[Table("Course")]
    public class Course
    {
        //Data moditifactions  
        [Key]
        //[Column("Course_id")]
        public int CourseID { get; set; }
        [MaxLength(125)]
        [Required]
        public string Title { get; set; }
       
        // [NotMapped]
        //[Column(TypeName ="decimal(5,2)")]
        [Required]
        public int Credits { get; set; }

        // Tipe data nya Collections makanya pake ICollections dari Enrollment.cs
        // Adding Relation into Enrollment Table
        // One to many, Plular. Jamak
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
