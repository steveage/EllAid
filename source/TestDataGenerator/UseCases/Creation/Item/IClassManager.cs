using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IClassManager
    {
        SchoolClass Create(string className, SchoolGrade grade);
        void AddStudent(Student student, SchoolClass schoolClass);
    }
}