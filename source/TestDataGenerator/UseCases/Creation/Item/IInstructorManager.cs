using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IInstructorManager
    {
        void AddAssistant(Assistant assistant, Instructor instructor);
        void AddCoach(EllCoach coach, Instructor instructor);
    }
}