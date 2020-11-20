using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessmentApplicationUnitTesting
{
    [TestClass]
    public class TestControllerTest
    {
        readonly TestRepository testRepository;
        readonly AssessmentDbContext db;
        readonly UserRepository userRepository;
        public TestControllerTest()
        {
            testRepository = new TestRepository();
            userRepository = new UserRepository();
            db = new AssessmentDbContext(); 
        }
        [TestMethod]
        public void CreateNewTest() //To create new test
        {
            testRepository.CreateNewTest(new Test() { TestName="Assessment",UserId=5,Subject=3,Grade=6,TestDate= new DateTime(2020, 11, 19, 11, 50, 0),StartTime= new DateTime(2020, 11, 19, 11, 50, 0),EndTime = new DateTime(2020, 11, 19, 12, 50, 0) });
            IEnumerable<Test> fetchedData = db.Tests.Where(data => data.TestId == 6)?.ToList();
            Assert.IsNotNull(fetchedData);
        }
        [TestMethod]
        public void CreateTest()
        {

            userRepository.Create(new User() { Name = "Manoj", EmailID = "manojradha@gmail.com", PhoneNumber = 8675674243, Password = "123", UserGrade = 2, RoleId = 2 });
            IEnumerable<User> fetchedData = db.Users.Where(temp => temp.EmailID == "manojradha@gmail.com")?.ToList();
            Assert.IsNotNull(fetchedData);

        }
        [TestMethod]
        public void EditTest()
        {
            int id = 5;
            Test test = testRepository.GetTestByTestId(id);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void DeleteTest()
        {
            bool value=false;
            int id = 5;
            Test test = testRepository.GetTestByTestId(id);
            if (test != null)
            {

                testRepository.DeleteTest(id);
                value = true;
            }
            Assert.IsTrue(value);
        }

    }

}
