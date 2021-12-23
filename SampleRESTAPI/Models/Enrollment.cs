namespace SampleRESTAPI.Models
{
    public enum Grade
    {
        A,B,C,D,E
    }
    public class Enrollment
    {
        // THis is Transactional Tables
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }


        // Realting to Master Tables
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
