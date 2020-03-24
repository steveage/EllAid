using System;

namespace EllAid.Entities.Data
{
    public class TestSession : Entity
    {
        public TestSession(){}
        public TestSession(string name, DateTime date, Test test, CourseAssignment assignment)
        {
            Name = name;
            Date = date;
            Test = test;
            CourseAssignment = assignment;
        }
        
        public Test Test { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}