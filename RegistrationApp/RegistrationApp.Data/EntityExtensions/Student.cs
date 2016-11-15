using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Data
{
  public partial class Student
  {
    public override bool Equals(object obj)
    {
      Student s = obj as Student;
      return s != null ?
        StudentId == s.StudentId && FirstName == s.FirstName && LastName == s.LastName
        : false;
    }
  }
}
