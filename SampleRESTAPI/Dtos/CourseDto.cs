using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    public class CourseDto
    {
        [Key]
        //[Column("Course_id")]
        //[MaxLength(255)]
        public int CourseID { get; set; }
        public string Title { get; set; }

        // [NotMapped]
        //[Column(TypeName ="decimal(5,2)")]

        // TotalHours = Credit x 1.5 jam
        public float TotalHours { get; set; }
    }
}
