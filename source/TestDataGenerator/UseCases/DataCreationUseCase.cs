using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters;
using EllAid.TestDataGenerator.UseCases.Creation.People;
using EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses;

namespace EllAid.TestDataGenerator.UseCases
{
    // This use case is too big in scope and took too much time to implement. It should have been split during the first iteration planning meeting into research, create data source, create students, create teachers, create tests, etc. If split, velocity could have been measured and each use case could be implemented in each iteration.
    class DataCreationUseCase : IDataCreationInputBoundary
    {
        readonly ISchoolClassBuilder builder;
        readonly IFacultyExtractor extractor;
        readonly IDataSaver saver;

        public DataCreationUseCase(ISchoolClassBuilder builder, IFacultyExtractor extractor, IDataSaver saver)
        {
            this.builder = builder;
            this.extractor = extractor;
            this.saver = saver;
        }

        public async Task CreateClassesAsync()
        {
            await CreatePreKClassesAsync();
        }

        async Task CreatePreKClassesAsync()
        {
            List<SchoolClass> schoolClasses = builder.GetClasses(SchoolGrade.PreKindergarten, 2020);
            await saver.DeleteDataStoreAsync();
            await saver.CreateDataStoreAsync();
            await SaveInstructorsAsync(schoolClasses);
            await SaveEllCoachesAsync(schoolClasses);
            await SaveAssistantsAsync(schoolClasses);
        }

        async Task SaveInstructorsAsync(List<SchoolClass> schoolClasses)
        {
            List<Instructor> instructors = extractor.ExtractInstructors(schoolClasses);
            await saver.SaveInstructorsAsync(instructors);
        }

        async Task SaveEllCoachesAsync(List<SchoolClass> schoolClasses)
        {
            List<EllCoach> coaches = extractor.ExtractEllCoaches(schoolClasses);
            await saver.SaveEllCoachesAsync(coaches);
        }

        async Task SaveAssistantsAsync(List<SchoolClass> schoolClasses)
        {
            List<Assistant> assistants = extractor.ExtractAssistants(schoolClasses);
            await saver.SaveAssistantsAsync(assistants);
        }
    }
}