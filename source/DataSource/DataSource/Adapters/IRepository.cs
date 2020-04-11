using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.DataSource.Adapters.DataObjects;

namespace EllAid.DataSource.Adapters
{
    public interface IRepository<T> where T : PersonDto
    {
        // Task SaveInstructorsAsync(List<InstructorDto> instructors);
        // Task SaveEllCoachesAsync(List<EllCoachDto> coaches);
        // Task SaveAssistantsAsync(List<AssistantDto> assistants);
        Task SaveFacultyAsync(List<T> faculty);
    }
}