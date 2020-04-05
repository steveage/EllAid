using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;
using EllAid.TestDataGenerator.UseCases.Creation.People;
using EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses;

namespace EllAid.TestDataGenerator.UseCases
{
    // This use case is too big in scope and took too much time to implement. It should have been split during the first iteration planning meeting into research, create data source, create students, create teachers, create tests, etc. If split, velocity could have been measured and each use case could be implemented in each iteration.
    class DataCreationUseCase : IDataCreationInputBoundary
    {
        private readonly IDataSourceBuilder dataSourceBuilder;
        readonly ISchoolClassBuilder builder;
        readonly IFacultyExtractor extractor;
        readonly IMappingProvider mapper;
        readonly ITestDataRepository repository;

        public DataCreationUseCase(IDataSourceBuilder dataSourceBuilder, ISchoolClassBuilder builder, IFacultyExtractor extractor, IMappingProvider mapper, ITestDataRepository repository)
        {
            this.dataSourceBuilder = dataSourceBuilder;
            this.builder = builder;
            this.extractor = extractor;
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task CreateClassesAsync()
        {
            await CreateClassesIfDataSourceIsReady();
        }

        async Task CreateClassesIfDataSourceIsReady()
        {
            bool dataSourceIsReady = await dataSourceBuilder.BuildAsync();
            if (dataSourceIsReady)
            {
                await CreatePreKClassesAsync();
            }
        }

        async Task CreatePreKClassesAsync()
        {
            List<SchoolClass> schoolClasses = builder.GetClasses(SchoolGrade.PreKindergarten, 2020);
            await SaveInstructors(schoolClasses);
            await SaveEllCoaches(schoolClasses);
            await SaveAssistantsAsync(schoolClasses);

        }

        async Task SaveInstructors(List<SchoolClass> schoolClasses)
        {
            List<Instructor> instructors = extractor.ExtractInstructors(schoolClasses);
            List<InstructorDto> instructorDtos = new List<InstructorDto>();
            instructors.ForEach(instructor => instructorDtos.Add(mapper.Map<InstructorDto, Instructor>(instructor, "instructor")));
            await repository.SaveInstructorsAsync(instructorDtos);
        }

        async Task SaveEllCoaches(List<SchoolClass> schoolClasses)
        {
            List<EllCoach> coaches = extractor.ExtractEllCoaches(schoolClasses);
            List<EllCoachDto> coachDtos = new List<EllCoachDto>();
            coaches.ForEach(coach => coachDtos.Add(mapper.Map<EllCoachDto, EllCoach>(coach, "ellCoach")));
            await repository.SaveEllCoachesAsync(coachDtos);
        }

        async Task SaveAssistantsAsync(List<SchoolClass> schoolClasses)
        {
            List<Assistant> assistants = extractor.ExtractAssistants(schoolClasses);
            List<AssistantDto> assistantDtos = new List<AssistantDto>();
            assistants.ForEach(assistant => assistantDtos.Add(mapper.Map<AssistantDto, Assistant>(assistant, "assistant")));
            await repository.SaveAssistantsAsync(assistantDtos);
        }
    }
}