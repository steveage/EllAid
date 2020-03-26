using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface ITestDataRepository
    {
        Task CreateUserItemAsync(Person user);
        Task CreateUserItemsAsync(List<Person> users);
        Task CreateTestItemAsync(TestBase test);
        Task CreateTestItemsAsync(List<TestBase> tests);
    }
}