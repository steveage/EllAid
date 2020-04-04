using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.TestDataGenerator.UseCases.Adapters;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace EllAid.TestDataGenerator.Infrastructure.TestData
{
    class TestDataRepository : ITestDataRepository
    {
        readonly IDatabaseAccess dbAccess;
        readonly ILogger<TestDataRepository> logger;

        public TestDataRepository(IDatabaseAccess dbAccess, ILogger<TestDataRepository> logger)
        {
            this.dbAccess = dbAccess;
            this.logger = logger;
        }

        public async Task SaveInstructorsAsync(List<InstructorDto> instructors) => await SavePeopleAsync<InstructorDto>(instructors);
        
        public async Task SaveEllCoachesAsync(List<EllCoachDto> coaches) => await SavePeopleAsync<EllCoachDto>(coaches);

        public async Task SaveAssistantsAsync(List<AssistantDto> assistants) => await SavePeopleAsync<AssistantDto>(assistants);

        async Task SaveItemAsync<T>(T item, Container container, string partitionKeyValue) where T : EntityDto
        {
            PartitionKey partitionKey = new PartitionKey(partitionKeyValue);
            try
            {
                ItemResponse<T> response = await container.CreateItemAsync<T>(item, partitionKey);
                logger.LogDebug($"Saved item with id {item.Id} and type {item.Type} in container {container.Id}. Operation consumed {response.RequestCharge} RUs.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception when creating item with id {item.Id} and type {item/*.Type*/} in container {container.Id}. Exception: {ex}");
            }
        }

        async Task SavePeopleAsync<T>(List<T> people) where T : PersonDto
        {
            List<Task> tasks = new List<Task>();
            people.ForEach(person => tasks.Add(SaveItemAsync<T>(person, dbAccess.UsersContainer, person.Email)));
            await Task.WhenAll(tasks);
        }
    }
}