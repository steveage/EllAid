using EllAid.Entities.Data;
using EllAid.UseCases.Generator.Creation.People;
using Xunit;

namespace EllAid.Tests.UseCases.Generator.Creation.People
{
    public class InstructorManagerTests
    {
        [Fact]
        public void AddAssistant_AddsAssistantToInstructorAndInstructorToAssistant()
        {
            //Given
            InstructorManager manager = new InstructorManager();
            Instructor instructor = new Instructor();
            Assistant assistant = new Assistant();
            //When
            manager.AddAssistant(assistant, instructor);
            //Then
            Assert.Contains(assistant, instructor.Assistants);
            Assert.Equal(instructor, assistant.Instructor);
        }

        [Fact]
        public void AddCoach_AddsCoachToInstructorAndInstructorToCoach()
        {
            //Given
            InstructorManager manager = new InstructorManager();
            Instructor instructor = new Instructor();
            EllCoach coach = new EllCoach();
            //When
            manager.AddCoach(coach, instructor);
            //Then
            Assert.Equal(coach, instructor.EllCoach);
            Assert.Contains(instructor, coach.Instructors);
        }
    }
}