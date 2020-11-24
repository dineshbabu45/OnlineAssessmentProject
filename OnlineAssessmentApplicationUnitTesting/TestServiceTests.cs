using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.Repository;
using OnlineAssessmentApplication.ServiceLayer;
using OnlineAssessmentApplication.ViewModel;
using System;

namespace OnlineAssessmentApplicationUnitTesting
{
   [TestClass]
    public class TestSevicesTests
    {
        private readonly TestService testService;
        private readonly Mock<ITestRepository> testMock = new Mock<ITestRepository>();
        public TestSevicesTests()
        {
            testService = new TestService(testMock.Object);
        }
        [TestMethod]
        public void GetTestByTestId()
        {
            var testId = 5;
           
            testMock.Setup(t => t.GetTestByTestId(testId)).Returns(new Test() {TestId=testId } );
            var test = testService.GetTestByTestId(testId);
            
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void CreateTest()
        {
            testMock.Setup(t => t.CreateNewTest(It.IsAny<Test>()));


            testService.CreateNewTest(new CreateTestViewModel() { TestName = "Assessment", UserId = 5, Subject =Subject.English, Grade = Grade.III, TestDate = new DateTime(2020, 11, 19, 11, 50, 0), StartTime = new DateTime(2020, 11, 19, 11, 50, 0), EndTime = new DateTime(2020, 11, 19, 12, 50, 0) });
           testMock.Verify(t => t.CreateNewTest(It.IsAny<Test>()),Times.Once);
           
        }
        [TestMethod]
        public void UpdateTest()
        {
            testMock.Setup(t => t.UpdateTest(It.IsAny<Test>()));
            testService.UpdateTest(new EditTestViewModel() { TestName = "Assessment", Subject = Subject.English, Grade = Grade.III, TestDate = new DateTime(2020, 11, 19, 11, 50, 0), StartTime = new DateTime(2020, 11, 19, 11, 50, 0), EndTime = new DateTime(2020, 11, 19, 12, 50, 0) });
            testMock.Verify(t => t.UpdateTest(It.IsAny<Test>()), Times.Once);

        }
        [TestMethod]
        public void DeleteTest()
        {
            var testId = 5;
            testMock.Setup(t => t.DeleteTest(testId));

            testService.DeleteTest(testId);
            testMock.Verify(t => t.DeleteTest(testId), Times.Once);
        }
    }
}
