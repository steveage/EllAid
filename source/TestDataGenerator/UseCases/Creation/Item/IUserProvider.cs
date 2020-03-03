using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IUserProvider<T> where T : User
    {
        void Initialize(string type, int count);
        string Type { get; }
        int Count { get; }
        T GetUser();
        List<T> GetUsers();
    }
}