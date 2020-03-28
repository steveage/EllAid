using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Tests
{
    interface IWidaTestBuilder : ITestBuilder
    {
        TestResult BuildResult(TestSection section, DateTime date);
    }
}