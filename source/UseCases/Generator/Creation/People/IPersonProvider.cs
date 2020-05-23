using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.People
{
    interface IPersonProvider
    {
        void Initialize(int count);
        int Count { get; }
        Person GetPerson();
        List<Person> GetPeople();
    }
}