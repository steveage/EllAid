using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Adapters.DataObjects;
using EllAid.DataSource.DataAccess.Context;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using TestSupport.EfHelpers;
using Xunit;

namespace EllAid.DataSource.Tests.Infrastructure.DataSource
{
    public class PeopleContextTests
    {
        [Fact]
        public async Task Save_WhenAssistantDto_AddsAssistantsToDb()
        {
        //Given
            DbContextOptions<PeopleContext> options = this.GetCosmosDbToEmulatorOptions<PeopleContext>();
            using PeopleContext context = new PeopleContext(options, GetConfig());
            string assistantId = GetId();
            string assistantEmail = "assistant@shool.com";
            string instructorId = GetId();
            string instructorEmail = "instructor1@school.com";

            InstructorShortDto instructor = new InstructorShortDto()
            {
                Id = instructorId,
                Email = instructorEmail
            };
            AssistantDto assistant = new AssistantDto()
            {
                Id = assistantId,
                Email = assistantEmail,
                Instructor = instructor
            };
        //When
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            context.Add(assistant);
            await context.SaveChangesAsync();
            assistant = await context.FindAsync<AssistantDto>(assistantId);
        //Then
            Assert.Equal(assistantId, assistant.Id);
            Assert.Equal(assistantEmail, assistant.Email);
            Assert.Equal(instructorId, assistant.Instructor.Id);
            Assert.Equal(instructorEmail, assistant.Instructor.Email);
        }
        
        [Fact]
        public async Task Save_WhenInstructorDto_AddsInstructorToDb()
        {
        //Given
            DbContextOptions<PeopleContext> options = this.GetCosmosDbToEmulatorOptions<PeopleContext>();

            using PeopleContext context = new PeopleContext(options, GetConfig());
            string instructorId = GetId();
            string instructorEmail = "email@school.com";
            string assistant1Id = GetId();
            string assistant2Id = GetId();
            AssistantShortDto assistant1 = new AssistantShortDto()
            {
                Id = assistant1Id,
                Email = "assistant1@school.com"
            };
            AssistantShortDto assistant2 = new AssistantShortDto()
            {
                Id = assistant2Id,
                Email = "assistant2@school.com"
            };
            EllCoachShortDto coach = new EllCoachShortDto()
            {
                Id = GetId(),
                Email = "coach@school.com",
            };
            InstructorDto instructor = new InstructorDto()
            {
                Id = instructorId,
                Email = instructorEmail,
                Assistants = new List<AssistantShortDto>() { assistant1,assistant2},
                EllCoach = coach,
                Department = Department.EarlyChildhood
            };
        //When
            context.Add(instructor);
            await context.SaveChangesAsync();
            instructor = await context.FindAsync<InstructorDto>(instructorId);
        //Then
            Assert.Equal(instructorId, instructor.Id);
            Assert.Equal(instructorEmail, instructor.Email);
            Assert.Equal(assistant1.Id, instructor.Assistants[0].Id);
            Assert.Equal(assistant2.Id, instructor.Assistants[1].Id);
        }

        IConfiguration GetConfig()
        {
            Mock<IConfiguration> configMock = new Mock<IConfiguration>();
            configMock.SetupGet((x => x[It.Is<string>(s => s == "DataStore:Containers:People:Id")]));
            configMock.SetupGet((x => x[It.Is<string>(s => s == "DataStore:Containers:People:PartitionKey")]));
            return configMock.Object;
        }
        string GetId() => Guid.NewGuid().ToString();

        [Fact]
        public async Task Save_WhenEllCoachDto_AddsEllCoachToDb()
        {
        //Given
            DbContextOptions<PeopleContext> options = this.GetCosmosDbToEmulatorOptions<PeopleContext>();
            using PeopleContext context = new PeopleContext(options, GetConfig());
            string coachId = GetId();
            string coachEmail = "coach@shool.com";
            string instructor1Id = GetId();
            string instructor1Email = "instructor1@school.com";
            string instructor2Id = GetId();
            string instructor2Email = "instructor2@school.com";

            InstructorShortDto instructor1 = new InstructorShortDto()
            {
                Id = instructor1Id,
                Email = instructor1Email
            };
            InstructorShortDto instructor2 = new InstructorShortDto()
            {
                Id = instructor2Id,
                Email = instructor2Email
            };
            EllCoachDto coach = new EllCoachDto()
            {
                Id = coachId,
                Email = coachEmail,
                Type = DataAccessConstants.noSqlEllCoachType,
                Instructors = new List<InstructorShortDto>() { instructor1, instructor2 }
            };
        //When
            context.Add(coach);
            await context.SaveChangesAsync();
            coach = await context.FindAsync<EllCoachDto>(coachId);
        //Then
            Assert.Equal(coachId, coach.Id);
            Assert.Equal(coachEmail, coach.Email);
            Assert.Equal(instructor1Id, coach.Instructors[0].Id);
            Assert.Equal(instructor1Email, coach.Instructors[0].Email);
            Assert.Equal(instructor2Id, coach.Instructors[1].Id);
            Assert.Equal(instructor2Email, coach.Instructors[1].Email);
        }
    }
}