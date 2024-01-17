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
    public async Task StudentRepo_GetStudentsAsync_ReturnsAllStudentsSuccessfully_StandardCall()
    {
        // Arrange
        var _testContext = new ApplicationDbContext(options);
        StudentRepo _studentRepo = new(_testContext);
        int expectedTotalRecords = 5;
        string expectedFirstName = "Patty";
        int expectedMaxId = 5;

        // Act
        var returnValues = await _studentRepo.GetStudentsAsync();
        var totalRecords = returnValues.Count();
        var firstName = returnValues.FirstOrDefault().FirstName; // Note: Method returns data ordered by lastname
        var maxId = returnValues.Max(s => s.Id);

        // Assert
        Assert.AreEqual(totalRecords, expectedTotalRecords);
        Assert.AreEqual(firstName, expectedFirstName);
        Assert.AreEqual(maxId, expectedMaxId);
    }

    [TestMethod]
    public async Task StudentRepo_GetStudentAsync_ReturnsStudentAndRelationshipsSuccessfully_ValidParameter()
    {
        // Arrange
        var _testContext = new ApplicationDbContext(options);
        StudentRepo _studentRepo = new(_testContext);
        int studentIdParameter = 3;
        List<int> expectedCourseIds = new () { 2,4,6 };

        // Act
        var student = await _studentRepo.GetStudentByIdAsync(studentIdParameter);

        // Assert
        Assert.AreEqual(student.Id, studentIdParameter);
        Assert.IsNotNull(student.StudentsCourses);
        Assert.IsTrue(student.StudentsCourses.Count() == 3);
        foreach(var course in student.StudentsCourses) 
        {
            Assert.IsTrue(expectedCourseIds.Contains(course.CourseId));
        }
    }

    [TestMethod]
    public async Task StudentRepo_UpdateStudentAsync_ReturnsUpdatedStudentSuccessfully_ValidParameter()
    {
        // Arrange
        var _testContext = new ApplicationDbContext(options);
        StudentRepo _studentRepo = new(_testContext);
        int studentIdParameter = 3;
        var student = await _studentRepo.GetStudentByIdAsync(studentIdParameter);
        string initialEmail = student.Email;
        string initialPhNumber = student.PhoneNumber;
        DateOnly initialBirthDate = student.BirthDate;

        // Act
        student.Email = "updatedEmail@sis.edu";
        student.PhoneNumber = "999-999-9999";
        student.BirthDate = new DateOnly(09, 09, 09);

        var updatedStudent = await _studentRepo.UpdateStudentAsync(student);

        // Assert
        Assert.AreNotEqual(initialEmail, updatedStudent.Email);
        Assert.AreNotEqual(initialPhNumber, updatedStudent.PhoneNumber);
        Assert.AreNotEqual(initialBirthDate, updatedStudent.BirthDate);
        Assert.AreEqual(studentIdParameter, updatedStudent.Id);
    }
}
