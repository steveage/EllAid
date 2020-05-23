using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.People
{
    interface IInstructorManager
    {
        void AddAssistant(Assistant assistant, Instructor instructor);
        void AddCoach(EllCoach coach, Instructor instructor);
    }
}