using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class TestBuilderTests
    {
        [Fact]
        public void Build_ReturnsPopulatedTest()
        {
            //Given
            TestBuilder builder = new TestBuilder();
            string testName = "WIDA";
            TestSubject subject = TestSubject.EnglishLearning;
            //When
            Test test = builder.Build(testName, subject);
            //Then
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.Equal(testName, test.Name);
            Assert.Equal(subject, test.Subject);
        }
    }
}