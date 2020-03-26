using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Tests
{
    interface IWidaTestBuilder : ITestBuilder
    {
        TestResult<int?> BuildResult(TestSession session, TestSection section, Student student, DateTime date);
    }
}