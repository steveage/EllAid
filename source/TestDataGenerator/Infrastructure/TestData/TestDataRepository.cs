using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using User = EllAid.Entities.Data.User;

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

        public async Task CreateUserItemsAsync(List<User> users)
        {
            List<Task> tasks = new List<Task>();
            
            foreach (User user in users)
            {
                tasks.Add(CreateItemAsync(user, dbAccess.UsersContainer, user.Id));
            }
            await Task.WhenAll(tasks);
        }

        public async Task CreateUserItemAsync(User user)
        {
            await CreateItemAsync(user, dbAccess.UsersContainer, user.Id);
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

        async Task CreateItemAsync(Item item, Container container, int partitionKeyValue)
        {
            PartitionKey partitionKey = new PartitionKey(partitionKeyValue);
            try
            {
                ItemResponse<Item> response = await container.CreateItemAsync<Item>(item, partitionKey);
                // logger.LogDebug($"Saved item with id {item.Id} and type {item.Type} in container {container.Id}. Operation consumed {response.RequestCharge} RUs.");
                logger.LogDebug($"Saved item with id {item.Id} and type {item/*.Type*/} in container {container.Id}. Operation consumed {response.RequestCharge} RUs.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception when creating item with id {item.Id} and type {item/*.Type*/} in container {container.Id}. Exception: {ex}");
            }
        }
    }
}