using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.Tests
{
    class TestAssigner : ITestAssigner
    {
        public void AssignSection(Test test, TestSection testSection)
        {
            test.Sections.Add(testSection);
            testSection.Test = test;
        }

        public void AssignTest(Enrollment enrollment, TestSession session, TestResult result)
        {
            TestAssignment assignment = new TestAssignment();
            assignment.Session = session;
            assignment.Enrollment = enrollment;
            assignment.Result = result;
            result.TestAssignment = assignment;
            enrollment.TestAssignments.Add(assignment);
            session.TestAssignments.Add(assignment);
        }
    }
}