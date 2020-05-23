using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Adapters.DataObjects;
using EllAid.Details.Web.DataSource.DataAccess.Context;
using EllAid.UseCases.DataSource;
using Microsoft.Extensions.Logging;

namespace EllAid.Details.Main.DataAccess
{
    public class FacultyRepository<T> : IFacultyRepository<T> where T : PersonDto
    {
        readonly ILogger<FacultyRepository<T>> logger;
        readonly PeopleContext peopleContext;

        public FacultyRepository(ILogger<FacultyRepository<T>> logger, PeopleContext peopleContext)
        {
            this.logger = logger;
            this.peopleContext = peopleContext;
        }

        public async Task CreateDataStoreAsync() => await peopleContext.Database.EnsureCreatedAsync();

        public async Task DeleteDataStoreAsync() => await peopleContext.Database.EnsureDeletedAsync();

        public async Task SaveFacultyAsync(List<T> faculty)
        {
            List<Task> tasks = new List<Task>();
            faculty.ForEach(member => tasks.Add(SaveEntityAsync(member)));
            await Task.WhenAll(tasks);
            await peopleContext.SaveChangesAsync();
        }

        async Task SaveEntityAsync(T member) => await peopleContext.AddAsync(member);
    }
}