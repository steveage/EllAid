using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.DocumentDb;
using EllAid.Adapters.DataObjects;
using EllAid.Entities.Data;
using EllAid.UseCases.DataSource;
using Microsoft.AspNetCore.Mvc;

namespace EllAid.Details.Web.DataSource.Controllers
{
    public class FacultyController : ControllerBase
    {
        readonly ISaveFacultyUseCase<Instructor, InstructorDto, DocumentDbIdentityUser> instructorUseCase;
        readonly ISaveFacultyUseCase<EllCoach, EllCoachDto, DocumentDbIdentityUser> ellCoachUseCase;
        readonly ISaveFacultyUseCase<Assistant, AssistantDto, DocumentDbIdentityUser> assistantUseCase;

        public FacultyController(ISaveFacultyUseCase<Instructor, InstructorDto, DocumentDbIdentityUser> instructorUseCase, ISaveFacultyUseCase<EllCoach, EllCoachDto, DocumentDbIdentityUser> ellCoachUseCase, ISaveFacultyUseCase<Assistant, AssistantDto, DocumentDbIdentityUser> assistantUseCase)
        {
            this.instructorUseCase = instructorUseCase;
            this.ellCoachUseCase = ellCoachUseCase;
            this.assistantUseCase = assistantUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructors([FromBody] List<Instructor> instructors)
        {
            await instructorUseCase.SaveAsync(instructors);
            return GetResult(nameof(instructorUseCase.SaveAsync), instructors);
        }

        IActionResult GetResult<T>(string sourceName, List<T> entities) where T : Entity => CreatedAtAction(sourceName, GetIds(entities), entities);
        
        IEnumerable<string> GetIds<T>(List<T> entities) where T : Entity => entities.Select(e => e.Id.ToString());

        [HttpPost]
        public async Task<IActionResult> CreateEllCoaches([FromBody] List<EllCoach> ellCoaches)
        {
            await ellCoachUseCase.SaveAsync(ellCoaches);
            return GetResult(nameof(ellCoachUseCase.SaveAsync), ellCoaches);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssistants([FromBody] List<Assistant> assistants)
        {
            await assistantUseCase.SaveAsync(assistants);
            return GetResult(nameof(assistantUseCase.SaveAsync), assistants);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDataStore()
        {
            await instructorUseCase.DeleteDataStoreAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDataStore()
        {
            await instructorUseCase.CreateDataStoreAsync();
            return Created($"Faculty/{nameof(CreateDataStore)}", null);
        }
    }
}