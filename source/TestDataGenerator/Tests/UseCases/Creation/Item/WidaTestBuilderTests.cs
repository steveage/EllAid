using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Item
{
    public class WidaTestBuilderTests
    {
        [Fact]
        public void Build_ReturnsWidaTest()
        {
            //Given
            WidaTestBuilder builder = new WidaTestBuilder(new TestAssigner());
            //When
            Test test = builder.Build();
            //Then
            Assert.NotEqual(Guid.Empty, test.Id);
            Assert.Equal(WidaTestBuilder.widaTestName, test.Name);
            Assert.Equal(TestSubject.EnglishLearning, test.Subject);
            Assert.Equal(4, test.Sections.Count);
            Assert.Equal(1, test.Sections.FindAll(section => section.Name.Equals("Listening")).Count);
            Assert.Equal(1, test.Sections.FindAll(section => section.Name.Equals("Reading")).Count);
            Assert.Equal(1, test.Sections.FindAll(section => section.Name.Equals("Writing")).Count);
            Assert.Equal(1, test.Sections.FindAll(section => section.Name.Equals("Speaking")).Count);
            Assert.Equal(TestMetric.Point0To30, test.Sections.Find(section => section.Name.Equals("Listening")).Metric);
            Assert.Equal(TestMetric.Point0To30, test.Sections.Find(section => section.Name.Equals("Speaking")).Metric);
            Assert.Equal(TestMetric.Point0To15, test.Sections.Find(section => section.Name.Equals("Reading")).Metric);
            Assert.Equal(TestMetric.Point0To18, test.Sections.Find(section => section.Name.Equals("Writing")).Metric);
        }
    }
}