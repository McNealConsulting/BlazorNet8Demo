using Microsoft.EntityFrameworkCore;
using RepoLayer.Data;
using RepoLayer.StudentRepo;
using SharedModels.StudentModels;

namespace RepoLayerTests.StudentRepoTests;

[TestClass]
public class StudentRepoIntegrationTests
{
    DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Test_Demo").Options;

    [TestMethod]
    public void StudentRepo_GetStudentsAsync_ReturnsAllStudentsSuccessfully_StandardCall()
    {
        // Arrange
        var _testContext = new ApplicationDbContext(options);
        StudentRepo _studentRepo = new(_testContext);
        int expectedTotalRecords = 5;
        string expectedFirstName = "Patty";
        int expectedMaxId = 5;

        // Act
        var result = _studentRepo.GetStudentsAsync();
        var returnValues = result.Result;
        var totalRecords = returnValues.Count();
        var firstName = returnValues.FirstOrDefault().FirstName; // Note: Method returns data ordered by lastname
        var maxId = returnValues.Max(s => s.Id);

        // Assert
        Assert.AreEqual(totalRecords, expectedTotalRecords);
        Assert.AreEqual(firstName, expectedFirstName);
        Assert.AreEqual(maxId, expectedMaxId);
    }

    [TestMethod]
    public void StudentRepo_GetStudentAsync_ReturnsStudentAndRelationshipsSuccessfully_ValidParameter()
    {
        // Arrange
        var _testContext = new ApplicationDbContext(options);
        StudentRepo _studentRepo = new(_testContext);
        int studentIdParameter = 3;
        List<int> expectedCourseIds = new () { 2,4,6 };

        // Act
        var result = _studentRepo.GetStudentByIdAsync(studentIdParameter);
        var student = result.Result;

        // Assert
        Assert.AreEqual(student.Id, studentIdParameter);
        Assert.IsNotNull(student.StudentsCourses);
        Assert.IsTrue(student.StudentsCourses.Count() == 3);
        foreach(var course in student.StudentsCourses) 
        {
            Assert.IsTrue(expectedCourseIds.Contains(course.CourseId));
        }
    }
}
