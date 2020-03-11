using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IItemProvider
    {
        List<T> GetUsers<T>(int count) where T : Person, new();
        T GetUser<T>() where T: Person, new();
        Student GetStudent();
        List<Student> GetStudents(int count);
        SchoolClass GetClass(string className, string grade, int year, string department, int section);
        Course GetStudentCourse(string userId, int classId, string teacherId, string score, bool isCurrent);
        TestResult<T> GetWidaTestResult<T>(DateTime resultDate, string term);
        List<TestResult<T>> GetWidaTestResults<T>(DateTime resultDate, string term, int count);
        List<TestSession> GetTestSessions(int testId, DateTime sessionDate, int count);
    }
}