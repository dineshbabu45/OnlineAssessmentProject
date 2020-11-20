﻿using OnlineAssessmentApplication.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessmentApplication.Repository
{/// <summary>
/// Add new test,update test,delete test
/// </summary>
    public interface ITestRepository
    {
        IEnumerable<Test> DisplayAllDetails();
        void CreateNewTest(Test test);
        Test GetTestByTestId(int testId);
        void UpdateTest(Test editTest);
        void DeleteTest(int testId);
    }
    public class TestRepository : ITestRepository
    {
        readonly AssessmentDbContext db;
        public TestRepository()
        {
            db = new AssessmentDbContext();
        }
        public void CreateNewTest(Test test) //To create new test
        {
            test.Status = "In-progress";
            db.Tests.Add(test);
            db.SaveChanges();

        }

        public void UpdateTest(Test editTest)
        {

            Test test = db.Tests.Find(editTest.TestId);
            if (test != null)
            {
                test.TestId = editTest.TestId;
                test.TestName = editTest.TestName;
                test.TestDate = editTest.TestDate;
                test.StartTime = editTest.StartTime;
                test.EndTime = editTest.EndTime;
                test.Grade = editTest.Grade;
                test.Subject = editTest.Subject;

                test.ModifiedTime = editTest.ModifiedTime;
                db.SaveChanges();
            }

        }
        public void DeleteTest(int testId)
        {
            db.Tests.Remove(GetTestByTestId(testId));
            db.SaveChanges();
        }
        public Test GetTestByTestId(int testId)
        {
            return db.Tests.Find(testId);
        }


        public IEnumerable<Test> DisplayAllDetails()
        {
            IEnumerable<Test> allTests = db.Tests.OrderByDescending(temp => temp.TestDate).ToList();
            return allTests;

        }
    }
}
