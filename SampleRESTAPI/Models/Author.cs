using System;

namespace SampleRESTAPI.Models
{
    public class Author
    {
        //Guid : Generated Unique ID | tidak auto increment, identifier yang unique
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MainCategory { get; set; }
    }
}
