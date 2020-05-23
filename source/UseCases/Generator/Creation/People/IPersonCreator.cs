using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.People
{
    interface IPersonCreator
    {
        T CreatePerson<T>() where T : Person, new();
        List<T> CreatePeople<T>(int count) where T : Person, new();
        List<Student> CreateStudents(int count, int birthYear);
    }
}