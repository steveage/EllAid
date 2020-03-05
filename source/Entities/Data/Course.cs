using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class Course : Entity
    {
        // TODO: solve missing UserId
        public string Email { get; set; }
        public int Class { get; set; }
        public List<string> Teachers { get; set; }
        public bool IsCurrent { get; set; }
        public string Score { get; set; }
    }
}