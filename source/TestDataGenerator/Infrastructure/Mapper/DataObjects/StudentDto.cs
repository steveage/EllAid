using System;
using System.Collections.Generic;

namespace EllAid.TestDataGenerator.Infrastructure.Mapper.DataObjects
{
    class StudentDto : UserDto
    {
        // internal List<string> Classes { get; set; }
        internal List<SchoolClassDto> Classes { get; set; }
        internal DateTime DateOfBirth { get; set; }
        internal DateTime EntryDate { get; set; }
        internal string HomeLanguage { get; set; }
        internal string HomeCommunicationLanguage { get; set; }
        internal string PictureUrl { get; set; }
    }
}