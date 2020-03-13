using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IPersonCreator
    {
        T CreatePerson<T>() where T : Person, new();
        List<T> CreatePeople<T>(int count) where T : Person, new();
        List<Student> CreateStudents(int count, int birthYear);
    }
}