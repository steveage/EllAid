using System.Collections.Generic;

namespace EllAid.DataSource.Adapters.DataObjects
{
    public class SchoolClassDto : EntityDto
    {
        public string Name { get; set; }
        public int Section { get; set; }
        public List<string> Teachers { get; set; }
        public List<string> Assistants { get; set; }
        public List<string> EllCoaches { get; set; }
        public List<string> Students { get; set; }
        public string Grade { get; set; }
        public string Year { get; set; }
        public string Department { get; set; }
    }
}