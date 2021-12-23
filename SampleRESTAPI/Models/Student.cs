using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRESTAPI.Models
{
    public class Student
    {
        // FAQ Convention over Configuration
        // Data Anotations and Data Anotation Schema
        // ID  = Primary Key, Type Int  = Auto Increment
        [Key]
        public int ID { get; set; } 
        // Add validation for prevent the input is cant be blank or null
        [Required]
        public string FirstName { get;  set; }
        [Required]
        public string LastName { get; set; }
    
        public DateTime EnrollmentDate { get; set; }

        // Tipe data nya Collections makanya pake ICollections dari Enrollment.cs
        // Adding Relation into Enrollment Table
        // One to many, Plular. Jamak
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
