using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IUserCreator
    {
        List<T> CreateUsers<T>(int count) where T : User, new();
        List<Student> CreateStudents(int count, int birthYear);
    }
}