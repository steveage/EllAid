using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Adapters;
using EllAid.Adapters.DataObjects;
using EllAid.DataSource.DataAccess.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EllAid.DataSource.Infrastructure.DataAccess
{
    class Repository<T> : IRepository<T> where T : PersonDto
    {
        readonly ILogger<Repository<T>> logger;
        readonly PeopleContext peopleContext;
        readonly UserManager<PersonDto> userManager;

        public Repository(ILogger<Repository<T>> logger, PeopleContext peopleContext, UserManager<PersonDto> userManager)
        {
            this.logger = logger;
            this.peopleContext = peopleContext;
            this.userManager = userManager;
        }

        public async Task CreateDataStoreAsync()
        {
            await peopleContext.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDataStoreAsync()
        {
            await peopleContext.Database.EnsureDeletedAsync();
        }

        public async Task SaveFacultyAsync(List<T> faculty)
        {
            await peopleContext.Database.EnsureCreatedAsync();
            List<Task> tasks = new List<Task>();
            
            faculty.ForEach(member => tasks.Add(SaveFacultyAsync(member)));
            await Task.WhenAll(tasks);
            await peopleContext.SaveChangesAsync();
        }

        async Task SaveFacultyAsync(T member)
        {
            string password = $"{member.FirstName}{member.LastName}!1";
            IdentityResult result = await userManager.CreateAsync(member, password);
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Unable to create faculty member.");
            }
            // await peopleContext.Set<T>().AddAsync(member);
        }
    }
}