using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Identity.DocumentDb;
using EllAid.DataSource.UseCases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EllAid.DataSource.Infrastructure.DataAccess
{
    class IdentityRepository<T> : IIdentityRepository<T> where T : DocumentDbIdentityUser
    {
        readonly IDocumentClient dbClient;
        readonly RoleManager<DocumentDbIdentityRole> roleManager;
        readonly UserManager<DocumentDbIdentityUser> userManager;
        readonly IConfiguration config;
        readonly ILogger<IdentityRepository<T>> logger;

        public IdentityRepository(IDocumentClient dbClient, RoleManager<DocumentDbIdentityRole> roleManager, UserManager<DocumentDbIdentityUser> userManager, IConfiguration config, ILogger<IdentityRepository<T>> logger)
        {
            this.dbClient = dbClient;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.config = config;
            this.logger = logger;
        }

        public async Task SetupDatasource()
        {
            await CreateContainerAsync();
            await AddFacultyRoleAsync();
        }

        async Task CreateContainerAsync()
        {
            DocumentCollection collection = new DocumentCollection()
            {
                Id = config["DataStore:Containers:Identities:Id"]
            };
            Uri dbUri = UriFactory.CreateDatabaseUri(config["DataStore:Id"]);
            await dbClient.CreateDocumentCollectionIfNotExistsAsync(dbUri, collection);
        }

        async Task AddFacultyRoleAsync()
        {
            DocumentDbIdentityRole role = new DocumentDbIdentityRole()
            {
                Name = config["DataStore:Containers:Identities:Roles:Faculty:Name"]
            };
            await roleManager.CreateAsync(role);
        }

        public async Task SaveAsync(List<T> identityUsers)
        {
            List<Task> tasks = new List<Task>();
            identityUsers.ForEach(identity => tasks.Add(SaveIdentityAsync(identity)));
            await Task.WhenAll(tasks);   
        }

        private async Task SaveIdentityAsync(T identity)
        {
            logger.LogInformation($"Creating identity for username {identity.UserName}.");
            string password = $"P@ssw0rd";
            IdentityResult result = await userManager.CreateAsync(identity, password);
            if (result != IdentityResult.Success)
            {
                string errorMessage = $"Unable to create identity for username {identity.UserName}.";
                logger.LogError($"{errorMessage} {result.Errors.ToString()}");
                throw new InvalidOperationException(errorMessage);
            }
            await userManager.AddToRoleAsync(identity, config["DataStore:Containers:Identities:Roles:Faculty:Name"]);
        }
    }
}