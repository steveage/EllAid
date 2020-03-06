using System;

namespace EllAid.Entities.Data
{
    public class Student : Person
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime EntryDate { get; set; }
        public string HomeLanguage { get; set; }
        public string HomeCommunicationLanguage { get; set; }
        public string PictureUrl { get; set; }
    }
} 