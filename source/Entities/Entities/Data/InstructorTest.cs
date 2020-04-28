using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class InstructorTest : InstructorTestBase
    {
        public int Version { get; set; }
        public InstructorTestBase EllCoach { get; set; }
        public List<InstructorTestBase> Assistants { get; set; }
    }
}