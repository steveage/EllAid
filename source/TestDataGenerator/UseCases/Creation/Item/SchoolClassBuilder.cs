using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class SchoolClassBuilder : ISchoolClassBuilder
    {
        readonly IPersonCreator personCreator;

        public SchoolClassBuilder(IPersonCreator personCreator)
        {
            this.personCreator = personCreator;
        }

        public SchoolClass BuildGenEdClass()
        {
            SchoolClass schoolClass = new SchoolClass();
            Instructor instructor = personCreator.CreatePerson<Instructor>();
            List<Assistant> assistants = personCreator.CreatePeople<Assistant>(2);
            EllCoach coach = personCreator.CreatePerson<EllCoach>();
            instructor.Assistants = assistants;
            instructor.EllCoach = coach;
            schoolClass.Instructor = instructor;
            return schoolClass;
        }
    }
}