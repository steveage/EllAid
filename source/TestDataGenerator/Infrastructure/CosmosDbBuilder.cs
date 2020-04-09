using System;
using System.Net;
using System.Threading.Tasks;
using EllAid.TestDataGenerator.UseCases.Adapters;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EllAid.TestDataGenerator.Infrastructure
{
    class CosmosDbBuilder : IDataSourceBuilder
    {
        internal const string dbUriConfigKey = "dbUri";
        internal const string dbKeyConfigKey = "dbKey";
        internal const string dbIdConfigKey = "dbId";
        internal const string dbTestsContainerIdConfigKey = "dbTestsContainerId";
        internal const string dbUsersContainerIdConfigKey = "dbUsersContainerId";
        readonly IConfiguration config;
        readonly ILogger<CosmosDbBuilder> logger;
        CosmosClient client;
        Database database;
        bool clientIsReady;
        bool databaseIsReady;

        public CosmosDbBuilder(IConfiguration config, ILogger<CosmosDbBuilder> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        public async Task<bool> BuildAsync()
        {
            CreateClient();
            await DeleteDatabaseAsync();
            await BuildDatabaseIfReadyAsync();
            await BuildContainersIfReadyAsync();

            return databaseIsReady;
        }

        void CreateClient()
        {
            string uri = config[dbUriConfigKey];
            string key = config[dbKeyConfigKey];
            
            try
            {
                client = new CosmosClientBuilder(uri, key)
                .WithSerializerOptions(new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                })
                .Build();
                clientIsReady = true;
                logger.LogInformation($"Successfully created Cosmos Db client for endpoint: {client.Endpoint}");
            }
            catch (Exception ex)
            {
                clientIsReady = false;
                logger.LogError($"Unable to build Cosmos Db client. Exception: {ex}");
            }
        }

        async Task DeleteDatabaseAsync()
        {
            if (clientIsReady)
            {
                await DeleteDatabaseIfExistsAsync();
            }
        }

        async Task DeleteDatabaseIfExistsAsync()
        {
            database = client.GetDatabase(GetDatabaseId());
            logger.LogInformation($"Attempting to delete database: {database.Id}...");
            try
            {
                await database.DeleteAsync();
                logger.LogInformation($"Database {database.Id} deleted successfully.");
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                logger.LogInformation($"Unable to delete database {database.Id}. Database may not exist.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error when deleting database: {database.Id}. Exception: {ex}.");
            }
        }

        string GetDatabaseId() => config[dbIdConfigKey];

        async Task BuildDatabaseIfReadyAsync()
        {
            if (clientIsReady)
            {
                await BuildDatabaseAsync();
            }
        }

        async Task BuildDatabaseAsync()
        {
            try
            {
                string databaseId = GetDatabaseId();
                logger.LogInformation($"Attempting to create database: {databaseId}...");
                database = await client.CreateDatabaseAsync(databaseId);
                databaseIsReady = true;
            }
            catch (Exception ex)
            {
                databaseIsReady = false;
                logger.LogError($"Unable to create database. Exception: {ex}");
            }
        }
 
        async Task BuildContainersIfReadyAsync()
        {
            if (databaseIsReady)
            {
                await BuildContainersAsync();
            }
        }

        async Task BuildContainersAsync()
        {
            string testsContainerId = config[dbTestsContainerIdConfigKey];
            string usersContainerId = config[dbUsersContainerIdConfigKey];
            try
            {
                logger.LogInformation($"Attempting to create container {testsContainerId}...");
                await database.CreateContainerAsync(testsContainerId, "/testId");
                logger.LogInformation($"Attempting to create container {usersContainerId}...");
                await database.CreateContainerAsync(usersContainerId, "/email");
                databaseIsReady = true;
            }
            catch (Exception ex)
            {
                databaseIsReady = false;
                logger.LogError($"Unable to create database containers. Exception: {ex}");
            }
        }
    }
}