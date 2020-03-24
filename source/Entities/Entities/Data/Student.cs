using System;
using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class Student : Person
    {
        public Student() => Enrollments = new List<Enrollment>();
        public DateTime DateOfBirth { get; set; }
        public DateTime EntryDate { get; set; }
        public string HomeLanguage { get; set; }
        public string HomeCommunicationLanguage { get; set; }
        public string PictureUrl { get; set; }
        public SchoolClass Class { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}