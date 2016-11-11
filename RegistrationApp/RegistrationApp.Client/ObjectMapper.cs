using RegistrationApp.Data;
using RegistrationApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Client
{
  internal class ObjectMapper
  {
    public static StudentDTO ConvertToStudentDTO(Student s)
    {
      return new StudentDTO(s.StudentId, s.FirstName, s.LastName);
    }

    public static CourseDTO ConvertToCourseDTO(Course c)
    {
      return new CourseDTO(c.CourseId, c.Title, c.StartHour.Hours, c.EndHour.Hours);
    }
  }
}
