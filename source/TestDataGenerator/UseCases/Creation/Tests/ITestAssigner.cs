using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Tests
{
    interface ITestAssigner
    {
        void AssignSection(Test test, TestSection testSection);
        void AssignTest(Enrollment enrollment, TestSession session, TestResult result);
    }
}