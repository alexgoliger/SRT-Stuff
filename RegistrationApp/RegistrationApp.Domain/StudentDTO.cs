using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Domain
{
  public class StudentDTO
  {
    public int StudentId { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public StudentDTO(int id, string firstName, string lastName)
    {
      StudentId = id;
      FirstName = firstName;
      LastName = lastName;
    }

    public override bool Equals(object obj)
    {
      StudentDTO s = obj as StudentDTO;
      return s != null ?
        StudentId == s.StudentId && FirstName == s.FirstName && LastName == s.LastName
        : false;
    }

    public override int GetHashCode()
    {
      return StudentId + FirstName.GetHashCode() * LastName.GetHashCode();
    }
  }
}
