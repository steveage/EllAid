using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class TestBuilder : ITestBuilder
    {
        public Test Build(string testName, TestSubject subject)
        {
            Test test = new Test()
            {
                Id = Guid.NewGuid(),
                Name = testName,
                Subject = subject
            };

            return test;
        }
    }
}