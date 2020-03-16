using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface ISchoolClassBuilder
    {
        SchoolClass BuildGenEdClass(string name);
    }
}