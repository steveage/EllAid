using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IClassManager
    {
        SchoolClass Create(string className, CourseAssignment assignment);
        void AddStudent(Student student, SchoolClass schoolClass);
    }
}