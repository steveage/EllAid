using System;
using System.Collections.Generic;

namespace EllAid.Entities.Data
{
    public class TestSession : Entity
    {
        public TestSession() => TestAssignments = new List<TestAssignment>();
        public TestSession(string name, DateTime date, Test test) : this()
        {
            Name = name;
            Date = date;
            Test = test;
        }
        
        public Test Test { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<TestAssignment> TestAssignments { get; set; }
    }
}