using RegistrationApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Domain
{
  public static class Validation
  {
    public static bool CanAddCourse(Course c)
    {
      return (GetCourseLength(c) == 1 && GetNumberOfOneHourCourses() < 10)
        || (GetCourseLength(c) == 2 && GetNumberOfTwoHourCourses() < 5);
    }

    public static int GetCourseLength(Course c)
    {
      return c.EndHour.Hours - c.StartHour.Hours;
    }

    public static bool ValidateRegistration(StudentDTO student, CourseDTO course)
    {
      return (DomainHelper.CountNumberOfHours(student) + course.Length) <= 6
        && !DomainHelper.GetCourseSchedule(student).ContainsKey(course.CourseId)
        && !CourseConflicts(student, course)
        && !IsDuplicateCourse(student, course)
        && GetEnrolledStudents(course).Count < 20;
    }

    private static int GetNumberOfOneHourCourses()
    {
      return DataHelper.GetAllCourses().Where(c => GetCourseLength(c.Value) == 1).Count();
    }

    private static int GetNumberOfTwoHourCourses()
    {
      return DataHelper.GetAllCourses().Where(c => GetCourseLength(c.Value) == 2).Count();
    }

    private static bool IsDuplicateCourse(StudentDTO student, CourseDTO course)
    {
      foreach (KeyValuePair<int, Course> x in DomainHelper.GetCourseSchedule(student))
      {
        if (course.Title == x.Value.Title)
        {
          return true;
        }
      }

      return false;
    }

    private static bool CourseConflicts(StudentDTO student, CourseDTO course)
    {
      // In order to avoid a schedule conflict, the given course cannot start at the same time
      // as any other course in the student's schedule, or sometime in the middle of a course.
      // Likewise, the given course cannot end sometime in the middle of another course, or 
      // at the end of another course.
      foreach (KeyValuePair<int, Course> x in DomainHelper.GetCourseSchedule(student))
      {
        if ((course.StartHour >= x.Value.StartHour.Hours && course.StartHour < x.Value.EndHour.Hours)
          || (course.EndHour <= x.Value.EndHour.Hours && course.EndHour > x.Value.StartHour.Hours))
        {
          return true;
        }
      }

      return false;
    }

    public static Dictionary<int, Student> GetEnrolledStudents(CourseDTO course)
    {
      var studentCourses = DataHelper.GetAllStudentCourses().Where
        (
          x =>
          x.Value.CourseId == course.CourseId
        );

      Dictionary<int, Student> students = new Dictionary<int, Student>();
      foreach (KeyValuePair<int, StudentCourse> sc in studentCourses)
      {
        students.Add(sc.Value.StudentId, DomainHelper.FindStudent(sc.Value.StudentId));
      }

      return students;
    }
  }
}
