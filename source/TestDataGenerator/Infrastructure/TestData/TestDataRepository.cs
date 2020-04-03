using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Adapters;
using EllAid.TestDataGenerator.UseCases.Adapters.DataObjects;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Person = EllAid.Entities.Data.Person;

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

        public async Task CreateUserItemsAsync(List<Person> users)
        {
            List<Task> tasks = new List<Task>();
            
            foreach (Person user in users)
            {
                tasks.Add(CreateItemAsync(user, dbAccess.UsersContainer, user.Email));
            }
            await Task.WhenAll(tasks);
        }

        public async Task CreateUserItemAsync(Person user)
        {
            await CreateItemAsync(user, dbAccess.UsersContainer, user.Email);
        }

        public async Task CreateTestItemAsync(TestBase test)
        {
            await CreateItemAsync(test, dbAccess.TestsContainer, test.TestId);
        }

        public async Task CreateTestItemsAsync(List<TestBase> tests)
        {
            List<Task> tasks = new List<Task>();

            foreach (TestBase test in tests)
            {
                tasks.Add(CreateItemAsync(test, dbAccess.TestsContainer, test.TestId));
            }
            await Task.WhenAll(tasks);
        }

        async Task CreateItemAsync(Entity item, Container container, string partitionKeyValue)
        {
            PartitionKey partitionKey = new PartitionKey(partitionKeyValue);
            try
            {
                ItemResponse<Entity> response = await container.CreateItemAsync<Entity>(item, partitionKey);
                // logger.LogDebug($"Saved item with id {item.Id} and type {item.Type} in container {container.Id}. Operation consumed {response.RequestCharge} RUs.");
                logger.LogDebug($"Saved item with id {item.Id} and type {item/*.Type*/} in container {container.Id}. Operation consumed {response.RequestCharge} RUs.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception when creating item with id {item.Id} and type {item/*.Type*/} in container {container.Id}. Exception: {ex}");
            }
        }

        public Task SaveInstructorsAsync(List<InstructorDto> instructors)
        {
            throw new NotImplementedException();
        }

        public Task SaveEllCoachesAsync(List<EllCoachDto> coaches)
        {
            throw new NotImplementedException();
        }

        public Task SaveAssistantsAsync(List<AssistantDto> assistants)
        {
            throw new NotImplementedException();
        }
    }
}