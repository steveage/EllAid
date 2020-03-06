using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    interface IItemProvider
    {
        List<T> GetUsers<T>(int count) where T : User, new();
        T GetUser<T>() where T: User, new();
        Student GetStudent();
        List<Student> GetStudents(int count);
        SchoolClass GetClass(string className, string grade, int year, string department, int section);
        Course GetStudentCourse(string userId, int classId, string teacherId, string score, bool isCurrent);
        TestResult GetWidaTestResult(DateTime resultDate, string term);
        List<TestResult> GetWidaTestResults(DateTime resultDate, string term, int count);
        List<TestSession> GetTestSessions(int testId, DateTime sessionDate, int count);
    }
}