using System;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.Tests
{
    interface IWidaTestBuilder : ITestBuilder
    {
        TestResult BuildResult(TestSection section, DateTime date);
    }
}