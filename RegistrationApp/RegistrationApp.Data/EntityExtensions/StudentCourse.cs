using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Data
{
  public partial class StudentCourse
  {
    public override bool Equals(object obj)
    {
      var sc = obj as StudentCourse;
      return sc != null ? sc.StudentId == StudentId && sc.CourseId == CourseId
        : false;
    }
  }
}
