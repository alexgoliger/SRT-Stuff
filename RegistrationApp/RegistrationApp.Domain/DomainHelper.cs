using RegistrationApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Domain
{
  public static class DomainHelper
  {
    public static int AddStudent(StudentDTO s)
    {
      if (s.StudentId > 0
        && !DataHelper.GetAllStudents().ContainsKey(s.StudentId))
      {
        DataHelper.AddStudent(ObjectMapper.ConvertToStudent(s));
      }

      return -1;
    }

    public static void RemoveStudent(StudentDTO s)
    {
      var student = ObjectMapper.ConvertToStudent(s);
      if (DataHelper.GetAllStudents().Contains(new KeyValuePair<int, Student>(student.StudentId, student)))
      {
        DataHelper.RemoveStudent(student.StudentId);
      }
    }

    public static void ModifyStudent(StudentDTO original, string firstName, string lastName)
    {
      original.FirstName = firstName;
      original.LastName = lastName;
      DataHelper.ModifyStudentById(original.StudentId, firstName, lastName);
    }

    public static void ModifyStudentById(int studentId, string firstName, string lastName)
    {
      DataHelper.ModifyStudentById(studentId, firstName, lastName);
    }

    public static int AddCourse(CourseDTO c)
    {
      Course c1 = ObjectMapper.ConvertToCourse(c);
      if (c1.CourseId > 0
        && !DataHelper.GetAllCourses().ContainsKey(c1.CourseId)
        && Validation.CanAddCourse(c1))
      {
        DataHelper.AddCourse(c1);
        return c1.CourseId;
      }

      return -1;
    }

    public static void RemoveCourse(CourseDTO c)
    {
      var course = ObjectMapper.ConvertToCourse(c);
      if (DataHelper.GetAllCourses().Contains(new KeyValuePair<int, Course>(course.CourseId, course)))
      {
        DataHelper.RemoveCourse(course.CourseId);
      }
    }

    public static void ModifyCourse(CourseDTO original, string title, int startHour, int endHour)
    {
      original.Title = title;
      original.StartHour = startHour;
      original.EndHour = endHour;
      DataHelper.ModifyCourseById(original.CourseId, title, startHour, endHour);
    }

    public static void ModifyCourseById(int id, string title, int startHour, int endHour)
    {
      DataHelper.ModifyCourseById(id, title, startHour, endHour);
    }

    public static int Register(StudentDTO s, CourseDTO c)
    {
      if (Validation.ValidateRegistration(s, c)
        && DataHelper.GetAllStudents().ContainsKey(s.StudentId)
        && DataHelper.GetAllCourses().ContainsKey(c.CourseId))
      {
        /*var student = ObjectMapper.ConvertToStudent(s);
        var course = ObjectMapper.ConvertToCourse(c);
        var studentCourse = new StudentCourse { Student = student, Course = course };
        return DataHelper.AddStudentCourse(studentCourse);*/
        return DataHelper.AddStudentCourse(s.StudentId, c.CourseId);
      }

      else if (Validation.ValidateRegistration(s, c)
        && !DataHelper.GetAllStudents().ContainsKey(s.StudentId)
        && DataHelper.GetAllCourses().ContainsKey(c.CourseId))
      {
        /*var student = ObjectMapper.ConvertToStudent(s);
        var course = ObjectMapper.ConvertToCourse(c);
        var studentCourse = new StudentCourse { Student = student, Course = course };
        return DataHelper.AddStudentCourse(studentCourse);*/
        DataHelper.AddStudent(ObjectMapper.ConvertToStudent(s));
        return DataHelper.AddStudentCourse(s.StudentId, c.CourseId);
      }

      return -1;
    }

    public static bool Withdraw(StudentDTO s, CourseDTO c)
    {
      //var student = ObjectMapper.ConvertToStudent(s);
      //var course = ObjectMapper.ConvertToCourse(c);
      var studentCourse = new StudentCourse { StudentId = s.StudentId, CourseId = c.CourseId };
      if (DataHelper.GetAllStudentCourses().ContainsValue(studentCourse))
      {
        return DataHelper.RemoveStudentCourse(studentCourse);
      }

      return false;
    }

    public static bool IsFullTime(StudentDTO s)
    {
      return CountNumberOfHours(s) > 3;
    }

    public static bool IsPartTime(StudentDTO s)
    {
      return CountNumberOfHours(s) <= 3;
    }

    public static Dictionary<int, Course> GetCourseSchedule(StudentDTO student)
    {
      Dictionary<int, StudentCourse> studentCourses = DataHelper.GetAllStudentCourses();
      Dictionary<int, Course> courses = new Dictionary<int, Course>();
      foreach (KeyValuePair<int, StudentCourse> sc in studentCourses)
      {
        Course course = FindCourse(sc.Value.CourseId);
        if (sc.Value.StudentId == student.StudentId && course != null)
        {
          courses.Add(course.CourseId, course);
        }
      }

      return courses;
    }

    public static int CountNumberOfHours(StudentDTO s)
    {
      int numberOfHours = 0;
      foreach (KeyValuePair<int, Course> course in GetCourseSchedule(s))
      {
        numberOfHours += Validation.GetCourseLength(course.Value);
      }

      return numberOfHours;
    }

    public static Student FindStudent(int studentId)
    {
      Student s = new Student();
      if (DataHelper.GetAllStudents().TryGetValue(studentId, out s))
      {
        return s;
      }

      return null;
    }

    /*public static int GetCourseId(CourseDTO course)
    {
      Course c = DataHelper.GetAllCourses().Find
        (
          x =>
          x.Title == course.Title
          && x.StartHour.Hours == course.StartHour
          && x.EndHour.Hours == course.EndHour
        );

      return c != null ? c.CourseId : -1;
    }*/

    public static Course FindCourse(int courseId)
    {
      Course c = new Course();
      if (DataHelper.GetAllCourses().TryGetValue(courseId, out c))
      {
        return c;
      }

      return null;
    }

    public static Dictionary<int, Course> GetAllCourses()
    {
      return DataHelper.GetAllCourses();
    }
  }
}
