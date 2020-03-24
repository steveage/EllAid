using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Entities.Tests.Data
{
    public class TestTests
    {
        [Fact]
        public void New_SetsIdAndList()
        {
            //Given
            //When
            Test test = new Test();
            //Then
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.NotNull(test.Sections);
        }

        [Fact]
        public void New_SetsNameAndSubject()
        {
            //Given
            string name = "WIDA Test";
            TestSubject subject = TestSubject.EnglishLearning;
            //When
            Test test = new Test(name, subject);
            //Then
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.NotNull(test.Sections);
            Assert.Equal(name, test.Name);
            Assert.Equal(subject, test.Subject);
        }
    }
}