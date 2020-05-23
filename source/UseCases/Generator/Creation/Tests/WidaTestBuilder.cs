using System;
using EllAid.Entities.Data;
using EllAid.UseCases.Generator.Creation.People;

namespace EllAid.UseCases.Generator.Creation.Tests
{
    class WidaTestBuilder : IWidaTestBuilder
    {
        internal const string widaTestName = "WIDA";
        readonly ITestAssigner assigner;
        readonly IDataFabricator fabricator;

        public WidaTestBuilder(ITestAssigner assigner, IDataFabricator fabricator)
        {
            this.assigner = assigner;
            this.fabricator = fabricator;
        }
        public Test Build()
        {
            Test test = new Test(widaTestName, TestSubject.EnglishLearning);
            assigner.AssignSection(test, GetSection("Listening", TestMetric.Point0To30));
            assigner.AssignSection(test, GetSection("Reading", TestMetric.Point0To15));
            assigner.AssignSection(test, GetSection("Writing", TestMetric.Point0To18));
            assigner.AssignSection(test, GetSection("Speaking", TestMetric.Point0To30));
            return test;
        }

        public TestResult BuildResult(TestSection section,DateTime date) => new TestResult()
        {
            Section = section,
            Date = date,
            Score = GetScore(section.Metric).ToString()
        };

        TestSection GetSection(string name, TestMetric metric) => new TestSection
        {
            Name = name,
            Metric = metric
        };

        int GetScore(TestMetric metric) =>
        metric switch
        {
            TestMetric.Point0To15 => fabricator.PickRandomNumber(0,15),
            TestMetric.Point0To18 => fabricator.PickRandomNumber(0,18),
            TestMetric.Point0To30 => fabricator.PickRandomNumber(0,30),
            _                     => throw new ArgumentException("Invalid enum value.", nameof(metric))
        };
    }
}