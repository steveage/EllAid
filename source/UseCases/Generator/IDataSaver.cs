using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.Entities.Services;

namespace EllAid.UseCases.Generator
{
    public interface IDataSaver : IDataStoreManager
    {
        Task SaveInstructorsAsync(List<Instructor> instructors);
        Task SaveEllCoachesAsync(List<EllCoach> ellCoaches);
        Task SaveAssistantsAsync(List<Assistant> assistants);
    }
}