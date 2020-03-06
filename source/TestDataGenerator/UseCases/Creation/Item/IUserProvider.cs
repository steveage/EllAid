using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IUserProvider<T> where T : User
    {
        void Initialize(int count);
        int Count { get; }
        T GetUser();
        List<T> GetUsers();
    }
}