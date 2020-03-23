using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class WidaTestBuilder : IWidaTestBuilder
    {
        internal const string widaTestName = "WIDA";
        readonly ITestAssigner assigner;

        public WidaTestBuilder(ITestAssigner assigner)
        {
            this.assigner = assigner;
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

        TestSection GetSection(string name, TestMetric metric) => new TestSection
        {
            Name = name,
            Metric = metric
        };
    }
}