using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class TestProvider : ITestProvider
    {
        public List<Test> GetTests()
        {
            List<Test> tests = new List<Test>();
            tests.Add(GetWidaTest());

            return tests;
        }

        Test GetWidaTest() => new Test
            {
                // TODO: Setup Id provider that will generate unique number.
                // Id = "1",
                Id = 1,
                // TestId = 2,
                //Type = "test",
                // Subject = "English",
                Name = "WIDA",
                // ScoreMetric = "0-30",
                // Version = 1,
                // Sections = new List<string> {"Listening", "Speaking", "Reading", "WrittingRAW", "Writting-Grade ADJ"}
            };
    }
}