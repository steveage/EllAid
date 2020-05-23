using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.People
{
    class InstructorManager : IInstructorManager
    {
        public void AddAssistant(Assistant assistant, Instructor instructor)
        {
            instructor.Assistants.Add(assistant);
            assistant.Instructor = instructor;
        }

        public void AddCoach(EllCoach coach, Instructor instructor)
        {
            instructor.EllCoach = coach;
            coach.Instructors.Add(instructor);
        }
    }
}