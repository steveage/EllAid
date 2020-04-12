using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.DataSource.Adapters;
using EllAid.DataSource.Adapters.DataObjects;
using EllAid.DataSource.DataAccess.Context;
using Microsoft.Extensions.Logging;

namespace EllAid.DataSource.Infrastructure.DataAccess
{
    class Repository<T> : IRepository<T> where T : PersonDto
    {
        readonly ILogger<Repository<T>> logger;
        readonly PeopleContext peopleContext;

        public Repository(ILogger<Repository<T>> logger, PeopleContext peopleContext)
        {
            this.logger = logger;
            this.peopleContext = peopleContext;
        }

        // public async Task SaveInstructorsAsync(List<InstructorDto> instructors) => await SavePeopleAsync<InstructorDto>(instructors);
        
        // public async Task SaveEllCoachesAsync(List<EllCoachDto> coaches) => await SavePeopleAsync<EllCoachDto>(coaches);

        // public async Task SaveAssistantsAsync(List<AssistantDto> assistants) => await SavePeopleAsync<AssistantDto>(assistants);

        // async Task SaveItemAsync<T>(T item, Container container, string partitionKeyValue) where T : EntityDto
        // {
        //     PartitionKey partitionKey = new PartitionKey(partitionKeyValue);
        //     try
        //     {
        //         ItemResponse<T> response = await container.CreateItemAsync<T>(item, partitionKey);
        //         logger.LogDebug($"Saved item with id {item.Id} and type {item.Type} in container {container.Id}. Operation consumed {response.RequestCharge} RUs.");
        //     }
        //     catch (Exception ex)
        //     {
        //         logger.LogError($"Exception when creating item with id {item.Id} and type {item/*.Type*/} in container {container.Id}. Exception: {ex}");
        //     }
        // }

        // async Task SavePeopleAsync<T>(List<T> people) where T : PersonDto
        // {
        //     List<Task> tasks = new List<Task>();
        //     // people.ForEach(person => tasks.Add(SaveItemAsync<T>(person, dbAccess.UsersContainer, person.Email)));
        //     await Task.WhenAll(tasks);
        // }

        public async Task SaveFacultyAsync(List<T> faculty)
        {
            await peopleContext.Set<T>().AddRangeAsync(faculty);
        }
    }
}