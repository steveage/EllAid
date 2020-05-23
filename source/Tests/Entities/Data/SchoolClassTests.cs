using System;
using EllAid.Entities.Data;
using Xunit;

namespace EllAid.Tests.Entities.Data
{
    public class SchoolClassTests
    {
        [Fact]
        public void New_SetsIdAndList()
        {
            //Given
            //When
            SchoolClass schoolClass = new SchoolClass();
            //Then
            Assert.NotEqual(Guid.Empty, schoolClass.Id);
            Assert.NotNull(schoolClass.Students);
        }

        [Fact]
        public void New_SetsName()
        {
            //Given
            string name = "School Class A";
            //When
            SchoolClass schoolClass = new SchoolClass(name);
            //Then
            Assert.NotEqual(Guid.Empty, schoolClass.Id);
            Assert.NotNull(schoolClass.Students);
            Assert.Equal(name, schoolClass.Name);
        }
    }
}