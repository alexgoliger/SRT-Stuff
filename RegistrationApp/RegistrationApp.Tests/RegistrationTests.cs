using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrationApp.Domain;
using System.Collections.Generic;
using RegistrationApp.Data;

namespace RegistrationApp.Tests
{
  [TestClass]
  public class RegistrationTests
  {
    StudentDTO student;
    //StudentDTO s1;
    CourseDTO course;

    [TestInitialize]
    public void Initialize()
    {
      student = new StudentDTO(22322440, "Alex", "Goliger");
      //s1 = new StudentDTO("Max", "Goliger");
      course = new CourseDTO(8240, "Calculus 1", 10, 12);
    }

    /**
    * pre: none
    * post: a new student named Alex Goliger is added
    */
    [TestMethod]
    public void Test_Add_Student()
    {
      // arrange
      Student actual;
      Student expected = new Student
      {
        StudentId = 22322440,
        FirstName = "Alex",
        LastName = "Goliger"
      };

      // act
      DomainHelper.AddStudent(student);
      actual = DomainHelper.FindStudent(student.StudentId);
      //actual = DataHelper.GetAllStudents()[DataHelper.GetAllStudents().Count - 1];

      // assert
      Assert.AreEqual(expected, actual);
    }

    /*[TestMethod]
    public void Test_Add_Student_Count()
    {
      // arrange
      int actual;
      int expected = DataHelper.GetAllStudents().Count + 1;

      // act
      DomainHelper.AddStudent(student);
      actual = DataHelper.GetAllStudents().Count;

      // assert
      Assert.AreEqual(expected, actual);
    }*/

    /**
    * pre: none
    * post: a new student is added, and then immediately removed
    */
    [TestMethod]
    public void Test_Remove_Student()
    {
      // arrange
      StudentDTO toRemove = new StudentDTO(123, "Remove", "Me");
      DomainHelper.AddStudent(toRemove);  // it is necessary to add a new student to the database,
                                          // since trying to remove a student that is already
                                          // enrolled in courses will produce an error
      int actual;
      int expected = DataHelper.GetAllStudents().Count - 1;

      // act
      DomainHelper.RemoveStudent(toRemove);
      actual = DataHelper.GetAllStudents().Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: The student Alex Goliger is renamed to Alexander Goliger
    */
    [TestMethod]
    public void Test_Modify_Student()
    {
      // arrange
      DomainHelper.AddStudent(student);
      int originalId = student.StudentId;
      Student actual;
      Student expected = new Student
      {
        StudentId = originalId,
        FirstName = "Alexander",
        LastName = "Goliger"
      };

      // act
      DomainHelper.ModifyStudent(student, "Alexander", "Goliger");
      actual = DomainHelper.FindStudent(originalId);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Modify_Student_By_Id()
    {
      // arrange
      DomainHelper.AddStudent(student);
      int originalId = student.StudentId;
      Student actual;
      Student expected = new Student
      {
        StudentId = originalId,
        FirstName = "Alexander",
        LastName = "Googlier"
      };

      // act
      DomainHelper.ModifyStudentById(originalId, "Alexander", "Googlier");
      actual = DomainHelper.FindStudent(originalId);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a new course called Calculus 1, running from 10 AM to 12 PM, is added
    */
    [TestMethod]
    public void Test_Add_Course()
    {
      // arrange
      Course actual;
      Course expected = new Course
      {
        CourseId = 8240,
        Title = "Calculus 1",
        StartHour = new TimeSpan(10, 0, 0),
        EndHour = new TimeSpan(12, 0, 0)
      };

      // act
      DomainHelper.AddCourse(course);
      actual = DomainHelper.FindCourse(course.CourseId);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a new course is added, and then immediately removed
    */
    [TestMethod]
    public void Test_Remove_Course()
    {
      // arrange
      CourseDTO toRemove = new CourseDTO(1234, "Java Programming", 8, 10);
      DomainHelper.AddCourse(toRemove);
      int actual;
      int expected = DataHelper.GetAllCourses().Count - 1;

      // act
      DomainHelper.RemoveCourse(toRemove);
      actual = DataHelper.GetAllCourses().Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: the course called Calculus 1 is modified
    */
    [TestMethod]
    public void Test_Modify_Course()
    {
      // arrange
      DomainHelper.AddCourse(course);
      int originalId = course.CourseId;
      Course actual;
      Course expected = new Course
      {
        CourseId = originalId,
        Title = "Calculus for Engineers",
        StartHour = new TimeSpan(8, 0, 0),
        EndHour = new TimeSpan(10, 0, 0)
      };

      // act
      DomainHelper.ModifyCourse(course, "Calculus for Engineers", 8, 10);
      actual = DomainHelper.FindCourse(originalId);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a student not currently registered for courses becomes registered for a course
    */
    [TestMethod]
    public void Test_Positive_Registration()
    {
      // arrange
      int actual;
      int expected = DataHelper.GetAllStudentCourses().Count + 1;

      //act
      DomainHelper.Register(student, course);
      actual = DataHelper.GetAllStudentCourses().Count;

      //assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a student is withdrawn from a course
    */
    [TestMethod]
    public void Test_Withdraw()
    {
      // arrange
      DomainHelper.Register(student, course);
      int actual;
      int expected = DomainHelper.GetCourseSchedule(student).Count - 1;

      // act
      DomainHelper.Withdraw(student, course);
      actual = DomainHelper.GetCourseSchedule(student).Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a student is found to not be full time
    */
    [TestMethod]
    public void Test_Not_Full_Time()
    {
      // arrange
      bool actual;
      bool expected = false;

      // act
      actual = DomainHelper.IsFullTime(student);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a student is found to be part time
    */
    [TestMethod]
    public void Test_Part_Time()
    {
      // arrange
      bool actual;
      bool expected = true;

      // act
      actual = DomainHelper.IsPartTime(student);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a student is found to be full time
    */
    [TestMethod]
    public void Test_Full_Time()
    {
      // arrange
      DomainHelper.ModifyCourse(course, "Calculus 1", 10, 12);
      CourseDTO c1 = new CourseDTO(4000, "Chemistry 101", 8, 10);
      DomainHelper.AddCourse(course);
      DomainHelper.AddCourse(c1);
      bool actual;
      bool expected = true;

      // act
      DomainHelper.Register(student, course);
      DomainHelper.Register(student, c1);
      actual = DomainHelper.IsFullTime(student);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /**
    * pre: none
    * post: a student is found to not be part time
    */
    [TestMethod]
    public void Test_Not_Part_Time()
    {
      // arrange
      DomainHelper.ModifyCourse(course, "Calculus 1", 10, 12);
      CourseDTO c1 = new CourseDTO(4000, "Chemistry 101", 8, 10);
      DomainHelper.AddCourse(course);
      DomainHelper.AddCourse(c1);
      bool actual;
      bool expected = false;

      // act
      DomainHelper.Register(student, course);
      DomainHelper.Register(student, c1);
      actual = DomainHelper.IsPartTime(student);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_No_Duplicate_Course()
    {
      // arrange
      DomainHelper.ModifyCourse(course, "Calculus 1", 10, 12);
      CourseDTO c1 = new CourseDTO(8500, "Calculus 1", 12, 14);
      DomainHelper.AddCourse(c1);
      DomainHelper.Register(student, course);
      int actual;
      int expected = DomainHelper.GetCourseSchedule(student).Count;
      //Course expected = DomainHelper.GetCourseSchedule(student)[DomainHelper.GetCourseSchedule(student).Count - 1];

      // act
      DomainHelper.Register(student, c1);
      actual = DomainHelper.GetCourseSchedule(student).Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Hours_Not_Exceeded()
    {
      // arrange
      DomainHelper.ModifyCourse(course, "Calculus 1", 10, 12);
      CourseDTO c1 = new CourseDTO(4000, "Chemistry 101", 8, 10);
      CourseDTO c2 = new CourseDTO(6000, "Computational Math", 12, 14);
      CourseDTO c3 = new CourseDTO(2000, "Macroeconomics", 15, 16);
      DomainHelper.AddCourse(course);
      DomainHelper.AddCourse(c1);
      DomainHelper.AddCourse(c2);
      DomainHelper.AddCourse(c3);
      DomainHelper.Register(student, course);
      DomainHelper.Register(student, c1);
      DomainHelper.Register(student, c2);
      int actual;
      int expected = DomainHelper.GetCourseSchedule(student).Count;

      // act
      DomainHelper.Register(student, c3);
      actual = DomainHelper.GetCourseSchedule(student).Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_No_Start_Course_Conflict()
    {
      // arrange
      DomainHelper.ModifyCourse(course, "Calculus 1", 10, 12);
      CourseDTO c1 = new CourseDTO(1500, "College Writing 1", 10, 11);
      DomainHelper.AddCourse(course);
      DomainHelper.AddCourse(c1);
      DomainHelper.Register(student, course);
      int actual;
      int expected = DomainHelper.GetCourseSchedule(student).Count;

      // act
      DomainHelper.Register(student, c1);
      actual = DomainHelper.GetCourseSchedule(student).Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_No_End_Course_Conflict()
    {
      // arrange
      DomainHelper.ModifyCourse(course, "Calculus 1", 10, 12);
      CourseDTO c1 = new CourseDTO(1000, "College Algebra", 11, 12);
      DomainHelper.AddCourse(course);
      DomainHelper.AddCourse(c1);
      DomainHelper.Register(student, course);
      int actual;
      int expected = DomainHelper.GetCourseSchedule(student).Count;

      // act
      DomainHelper.Register(student, c1);
      actual = DomainHelper.GetCourseSchedule(student).Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Course_Capacity()
    {
      // arrange
      CourseDTO course = new CourseDTO(3500, "US Government", 8, 10);
      DomainHelper.AddCourse(course);
      StudentDTO s1 = new StudentDTO(12345678, "Max", "Goliger");
      for (int i = 0; i < 20; i++)
      {
        StudentDTO s = new StudentDTO(i + 1, "Student", "#" + (i + 1));
        DomainHelper.Register(s, course);
      }

      int actual;
      int expected = 20;

      // act
      DomainHelper.Register(s1, course);
      actual = Validation.GetEnrolledStudents(course).Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestCleanup]
    public void Cleanup()
    {
      GC.Collect();
    }
  }
}
