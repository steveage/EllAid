using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses;

namespace EllAid.TestDataGenerator.UseCases
{
    // This use case is too big in scope and took too much time to implement. It should have been split during the first iteration planning meeting into research, create data source, create students, create teachers, create tests, etc. If split, velocity could have been measured and each use case could be implemented in each iteration.
    class DataCreationUseCase : IDataCreationInputBoundary
    {
        readonly ISchoolClassBuilder builder;

        public DataCreationUseCase(ISchoolClassBuilder builder)
        {
            this.builder = builder;
        }

        public List<SchoolClass> GetClasses()
        {
            return builder.GetClasses(SchoolGrade.PreKindergarten, 2020);
        }
    }
}