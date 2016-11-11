using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Data
{
  public static class DataHelper
  {
    private static RegistrationEntities db = new RegistrationEntities();

    public static void AddStudent(Student s)
    {
      db.Students.Add(s);
      db.SaveChanges();
    }

    public static void RemoveStudent(int studentId)
    {
      Student s = db.Students.Find(studentId);
      if (s != null)
      {
        db.Students.Remove(s);
        db.SaveChanges();
      }
    }
    /*
    public static void ModifyStudent(Student original, Student changed)
    {
      Student found = db.Students.Find(original.StudentId);
      if (found != null && found.Equals(original))
      {
        found.FirstName = changed.FirstName;
        found.LastName = changed.LastName;
        db.SaveChanges();
      }
    }*/

    public static void ModifyStudentById(int id, string firstName, string lastName)
    {
      Student original = db.Students.Find(id);
      if (original != null)
      {
        original.FirstName = firstName;
        original.LastName = lastName;
        db.SaveChanges();
      }
    }

    public static void AddCourse(Course c)
    {
      db.Courses.Add(c);
      db.SaveChanges();
    }

    public static void RemoveCourse(int courseId)
    {
      Course c = db.Courses.Find(courseId);
      if (c != null)
      {
        db.Courses.Remove(c);
        db.SaveChanges();
      }
    }

    /*public static void ModifyCourse(Course original, Course changed)
    {
      Course found = db.Courses.Find(original.CourseId);
      if (found != null && found.Equals(original))
      {
        found.Title = changed.Title;
        found.StartHour = changed.StartHour;
        found.EndHour = changed.EndHour;
        db.SaveChanges();
      }
    }*/

    public static void ModifyCourseById(int id, string title, int startHour, int endHour)
    {
      Course original = db.Courses.Find(id);
      if (original != null)
      {
        original.Title = title;
        original.StartHour = new TimeSpan(startHour, 0, 0);
        original.EndHour = new TimeSpan(endHour, 0, 0);
        db.SaveChanges();
      }
    }

    /*public static int AddStudentCourse(StudentCourse sc)
    {
      db.StudentCourses.Add(sc);
      db.SaveChanges();

      return sc.StudentCourseId;
    }*/

    public static int AddStudentCourse(int studentId, int courseId)
    {
      var sc = new StudentCourse { StudentId = studentId, CourseId = courseId };
      db.StudentCourses.Add(sc);
      db.SaveChanges();

      return sc.StudentCourseId;
    }

    public static bool RemoveStudentCourse(StudentCourse sc)
    {
      int id = FindStudentCourseId(sc);
      StudentCourse studentCourse = db.StudentCourses.Find(id);
      if (id > 0 && studentCourse != null)
      {
        db.StudentCourses.Remove(studentCourse);
        db.SaveChanges();
        return true;
      }

      return false;
    }

    /*public static void RemoveStudentCourse(Student s, Course c)
    {
      StudentCourse sc = new StudentCourse
      {
        StudentId = s.StudentId,
        CourseId = c.CourseId
      };

      RemoveStudentCourse(sc);
    }*/

    /*public static void RemoveStudentCourse(int studentCourseId)
    {
      StudentCourse sc = db.StudentCourses.Find(studentCourseId);
      db.StudentCourses.Remove(sc);
      db.SaveChanges();
    }*/

    public static Dictionary<int, Student> GetAllStudents()
    {
      return db.Students.ToDictionary(student => student.StudentId);
    }

    public static Dictionary<int, Course> GetAllCourses()
    {
      return db.Courses.ToDictionary(course => course.CourseId);
    }

    public static Dictionary<int, StudentCourse> GetAllStudentCourses()
    {
      return db.StudentCourses.ToDictionary(StudentCourse => StudentCourse.StudentCourseId);
    }

    private static int FindStudentCourseId(StudentCourse studentCourse)
    {
      foreach (StudentCourse sc in db.StudentCourses)
      {
        if (sc.Equals(studentCourse))
        {
          return sc.StudentCourseId;
        }
      }

      return -1;
    }
  }
}
