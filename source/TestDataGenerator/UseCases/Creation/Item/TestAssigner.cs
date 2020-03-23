using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class TestAssigner : ITestAssigner
    {
        public void AssignSection(Test test, TestSection testSection)
        {
            test.Sections.Add(testSection);
            testSection.Test = test;
        }
    }
}