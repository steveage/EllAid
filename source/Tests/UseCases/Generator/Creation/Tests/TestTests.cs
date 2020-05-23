using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.UseCases.Generator.Creation.Tests
{
    public class TestTests
    {
        [Fact]
        public void NewTest_SetsDefaultValues()
        {
            //Given, When
            Test test = new Test();
            //Then
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.NotNull(test.Sections);
        }

        [Fact]
        public void NewTest_SetsValuesFromParameters()
        {
            //Given
            string testName = "WIDA";
            TestSubject subject = TestSubject.EnglishLearning;
            //When
            Test test = new Test(testName, subject);
            //Then
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.NotNull(test.Sections);
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.Equal(testName, test.Name);
            Assert.Equal(subject, test.Subject);
        }
    }
}