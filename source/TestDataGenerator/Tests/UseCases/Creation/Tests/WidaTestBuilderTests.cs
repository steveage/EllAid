using System;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure;
using EllAid.TestDataGenerator.UseCases.Creation.Tests;
using Xunit;

namespace EllAid.TestDataGenerator.Tests.UseCases.Creation.Tests
{
    public class WidaTestBuilderTests
    {
        [Fact]
        public void Build_ReturnsWidaTest()
        {
            //Given
            WidaTestBuilder builder = new WidaTestBuilder(new TestAssigner(), new BogusFabricator());
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

        [Fact]
        public void BuildResult_ReturnsPopulatedResult()
        {
            //Given
            WidaTestBuilder builder = new WidaTestBuilder(new TestAssigner(), new BogusFabricator());
            TestSession session = new TestSession();
            TestSection section = new TestSection()
            {
                Metric = TestMetric.Point0To15
            };
            Student student = new Student();
            DateTime date = DateTime.Now;
            //When
            TestResult result = builder.BuildResult(section, date);
            //Then
            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal(section, result.Section);
            Assert.Equal(date, result.Date);
        }

        [Theory]
        [InlineData(TestMetric.Point0To15, 0, 15)]
        [InlineData(TestMetric.Point0To18, 0, 18)]
        [InlineData(TestMetric.Point0To30, 0, 30)]
        public void BuildResult_ReturnsResultWithScore(TestMetric metric, int scoreFrom, int scoreTo)
        {
            // Given
            WidaTestBuilder builder = new WidaTestBuilder(new TestAssigner(), new BogusFabricator());
            TestSession session = new TestSession();
            TestSection section = new TestSection()
            {
                Metric = metric
            };
            Student student = new Student();
            DateTime date = DateTime.Now;
            // When
            TestResult result = builder.BuildResult(section, date);
            // Then
            Assert.NotNull(result.Score);
            Assert.InRange(Int32.Parse(result.Score), scoreFrom, scoreTo);
        }

        [Fact]
        public void BuildResult_WhenMetricNotInRange_ThrowsException()
        {
            //Given
            WidaTestBuilder builder = new WidaTestBuilder(new TestAssigner(), new BogusFabricator());
            TestSession session = new TestSession();
            TestSection section = new TestSection();
            Student student = new Student();
            DateTime date = DateTime.Now;
            //When, Then
            Assert.Throws<ArgumentException>(() => builder.BuildResult(section, date));
        }
    }
}