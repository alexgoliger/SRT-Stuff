using RegistrationApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Domain
{
  internal static class ObjectMapper
  {
    public static Student ConvertToStudent(StudentDTO s)
    {
      var student = new Student
      {
        StudentId = s.StudentId,
        FirstName = s.FirstName,
        LastName = s.LastName
      };

      return student;
    }

    public static Course ConvertToCourse(CourseDTO c)
    {
      var course = new Course
      {
        CourseId = c.CourseId,
        Title = c.Title,
        StartHour = new TimeSpan(c.StartHour, 0, 0),
        EndHour = new TimeSpan(c.EndHour, 0, 0)
      };

      return course;
    }
  }
}
