using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface ITestDataRepository
    {
        Task SaveInstructorsAsync(List<InstructorDto> instructors);
        Task SaveEllCoachesAsync(List<EllCoachDto> coaches);
        Task SaveAssistantsAsync(List<AssistantDto> assistants);
    }
}