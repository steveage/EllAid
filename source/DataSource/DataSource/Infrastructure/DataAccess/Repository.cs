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
            await peopleContext.Set<T>().AddAsync(member);
        }
    }
}