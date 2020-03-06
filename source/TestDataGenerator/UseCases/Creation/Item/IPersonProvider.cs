using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IPersonProvider
    {
        void Initialize(int count);
        int Count { get; }
        Person GetPerson();
        List<Person> GetPeople();
    }
}