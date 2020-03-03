using System.Runtime.CompilerServices;

///<remark>Internals should only be accessed from the composition root of the application.</remark>
[assembly: InternalsVisibleTo("EllAid.TestDataGenerator.UI")]
///<remark>Internals can be visible from test projects to allow testing.</remark>
[assembly: InternalsVisibleTo("EllAid.TestDataGenerator.Tests.UseCases")]
[assembly: InternalsVisibleTo("EllAid.TestDataGenerator.Tests.Infrastructure")]