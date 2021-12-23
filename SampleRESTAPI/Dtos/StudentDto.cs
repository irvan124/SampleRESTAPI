using System;
using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    public class StudentDto
    {
          
        // FAQ Convention over Configuration
        // Data Anotations and Data Anotation Schema
        // ID  = Primary Key, Type Int  = Auto Increment
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
       
        public DateTime EnrollmentDate { get; set; }

    }

}
