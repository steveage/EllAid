using System;
using System.Collections.Generic;

namespace EllAid.Adapters.DataObjects
{
    public class StudentDto : PersonDto
    {
        // internal List<string> Classes { get; set; }
        public List<SchoolClassDto> Classes { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EntryDate { get; set; }
        public string HomeLanguage { get; set; }
        public string HomeCommunicationLanguage { get; set; }
        public string PictureUrl { get; set; }
    }
}