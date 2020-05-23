using System;
using EllAid.Entities.Data;
using EllAid.UseCases.Generator.Creation.Tests;
using Xunit;

namespace EllAid.Tests.UseCases.Generator.Creation.Tests
{
    public class TestAssignerTests
    {
        [Fact]
        public void AssignSection_AddsSectionToTest()
        {
            //Given
            TestAssigner assigner = new TestAssigner();
            Test test = new Test();
            TestSection section = new TestSection();
            //When
            assigner.AssignSection(test, section);
            //Then
            Assert.Equal(section, test.Sections[0]);
            Assert.Equal(test, section.Test);
        }

        [Fact]
        public void AssignTest_CreatesTestAssignmentAndAssignsIt()
        {
            //Given
            TestAssigner assigner = new TestAssigner();
            Enrollment enrollment = new Enrollment();
            TestSession session = new TestSession();
            TestResult result = new TestResult();
            //When
            assigner.AssignTest(enrollment, session, result);
            //Then
            Assert.Single(session.TestAssignments);
            Assert.NotEqual(Guid.Empty, session.TestAssignments[0].Id);
            Assert.Equal(session, session.TestAssignments[0].Session);
            Assert.Equal(enrollment, session.TestAssignments[0].Enrollment);
            Assert.Equal(result, session.TestAssignments[0].Result);
            Assert.Equal(session.TestAssignments[0], result.TestAssignment);
            Assert.Single(enrollment.TestAssignments);
            Assert.Contains(result.TestAssignment, enrollment.TestAssignments);
        }
    }
}