using System.Collections.Generic;
using EllAid.Entities.Data;
using EllAid.UseCases.Generator.Creation.People;
using Xunit;

namespace EllAid.Tests.UseCases.Generator.Creation.People
{
    public class PersonExtractorTests
    {
        [Fact]
        public void ExtractInstructors_ReturnsInstructors()
        {
            //Given
            FacultyExtractor extractor = new FacultyExtractor();
            Instructor instructor1 = new Instructor();
            SchoolClass schoolClass1 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = instructor1
                }
            };
            Instructor instructor2 = new Instructor();
            SchoolClass schoolClass2 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = instructor2
                }
            };
            List<SchoolClass> schoolClasses = new List<SchoolClass>(){ schoolClass1, schoolClass2};
            //When
            List<Instructor> instructors = extractor.ExtractInstructors(schoolClasses);
            //Then
            Assert.Equal(instructor1, instructors[0]);
            Assert.Equal(instructor2, instructors[1]);
        }

        [Fact]
        public void ExtractEllCoaches_ReturnsUniqueEllCoaches()
        {
            //Given
            FacultyExtractor extractor = new FacultyExtractor();
            EllCoach coach1 = new EllCoach();
            EllCoach coach2 = new EllCoach();
            SchoolClass schoolClass1 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = new Instructor()
                    {
                        EllCoach = coach1
                    }
                }
            };
            SchoolClass schoolClass2 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = new Instructor()
                    {
                        EllCoach = coach2
                    }
                }
            };
            SchoolClass schoolClass3 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = new Instructor()
                    {
                        EllCoach = coach2
                    }
                }
            };
            List<SchoolClass> schoolClasses = new List<SchoolClass>(){ schoolClass1, schoolClass2, schoolClass3};
            
        //When
        List<EllCoach> ellCoaches = extractor.ExtractEllCoaches(schoolClasses);
        //Then
        Assert.Equal(2, ellCoaches.Count);
        Assert.Contains(coach1, ellCoaches);
        Assert.Contains(coach2, ellCoaches);
        }

        [Fact]
        public void ExtractAssistants_ReturnsAssistants()
        {
            //Given
            FacultyExtractor extractor = new FacultyExtractor();
            Assistant assistant1 = new Assistant();
            Assistant assistant2 = new Assistant();
            Assistant assistant3 = new Assistant();
            Assistant assistant4 = new Assistant();
            SchoolClass schoolClass1 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = new Instructor()
                }
            };
            SchoolClass schoolClass2 = new SchoolClass()
            {
                CourseAssignment = new CourseAssignment()
                {
                    Instructor = new Instructor()
                }
            };
            schoolClass1.CourseAssignment.Instructor.Assistants.Add(assistant1);
            schoolClass1.CourseAssignment.Instructor.Assistants.Add(assistant2);
            schoolClass2.CourseAssignment.Instructor.Assistants.Add(assistant3);
            schoolClass2.CourseAssignment.Instructor.Assistants.Add(assistant4);
            List<SchoolClass> schoolClasses = new List<SchoolClass>(){schoolClass1, schoolClass2 };
            //When
            List<Assistant> assistants = extractor.ExtractAssistants(schoolClasses);
            //Then
            Assert.Equal(4, assistants.Count);
            Assert.Contains(assistant1, assistants);
            Assert.Contains(assistant2, assistants);
            Assert.Contains(assistant3, assistants);
            Assert.Contains(assistant4, assistants);
        }
    }
}