using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface IDataSaver
    {
        Task SaveInstructorsAsync(List<Instructor> instructors);
        Task SaveEllCoachesAsync(List<EllCoach> ellCoaches);
        Task SaveAssistantsAsync(List<Assistant> assistants);
    }
}