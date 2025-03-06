using System;

namespace SimpleRESTApi.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string InstructorName { get; set; } = null;
        public string InstructorEmail { get; set; } = null;
        public string InstructorPhone { get; set; } = null;
        public string InstructorAddress { get; set; } = null;
        public string InstructorCity { get; set; } = null;
    }
}