using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IUserCreator
    {
        List<Person> CreatePeople(int count);
        List<Student> CreateStudents(int count, int birthYear);
    }
}