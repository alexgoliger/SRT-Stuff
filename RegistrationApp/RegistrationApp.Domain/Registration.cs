using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Domain
{
  public class Registration
  {/*
    private List<CourseDTO> courses;
    StudentDTO student;

    public void Initialize()
    {
      Console.Write("Please enter your first name. ");
      string firstName = Console.ReadLine();
      Console.Write("Please enter your last name. ");
      string lastName = Console.ReadLine();
      student = new StudentDTO(firstName, lastName);
      PopulateCourses();
      DisplayMenu();
    }

    private void PopulateCourses()
    {
      courses = new List<CourseDTO>
      { new CourseDTO("Chemistry 101", 0, 2),
        new CourseDTO("Calculus 1", 2, 4),
        new CourseDTO("Computational Math", 4, 6),
        new CourseDTO("Chemistry 101", 6, 8),
        new CourseDTO("Calculus 1", 8, 10),
        new CourseDTO("Intermediate Algebra", 0, 1),
        new CourseDTO("College Algebra", 1, 2),
        new CourseDTO("College Writing 1", 2, 3),
        new CourseDTO("College Algebra", 3, 4),
        new CourseDTO("College Writing 1", 4, 5),
        new CourseDTO("US Government", 5, 6),
        new CourseDTO("Microeconomics", 6, 7),
        new CourseDTO("Macroeconomics", 7, 8),
        new CourseDTO("Microeconomics", 8, 9),
        new CourseDTO("Macroecnomics", 9, 10)
      };
    }

    private void DisplayMenu()
    {
      string input = string.Empty;
      string input2 = string.Empty;
      while(input.ToLowerInvariant() != "n" || input2.ToLowerInvariant() != "n")
      {
        Console.WriteLine("The following courses are available: ");
        for (int i = 0; i < courses.Count; i++)
        {
          Console.WriteLine("#{0} {1}", i + 1, courses[i].ToString());
        }
        Console.Write("Would you like to register for a course? (Enter n for No.) ");
        input = Console.ReadLine();
        if(input.ToLowerInvariant() != "n")
        {
          PromptForCourse();
        }
        Console.Write("Would you like to withdraw from a course? (Enter n for No.) ");
        input2 = Console.ReadLine();
        if (input2.ToLowerInvariant() != "n")
        {
          PromptForWithdrawal();
        }
      }
    }

    private void PromptForCourse()
    {
      Console.Write("Please enter the number of the course you would like to register for. ");
      int input = int.Parse(Console.ReadLine());
      student.Register(courses[input - 1]);
    }

    private void PromptForWithdrawal()
    {
      Console.WriteLine("You are registered for the following courses: ");
      for (int i = 0; i < student.CourseSchedule.Count; i++)
      {
        Console.WriteLine("#{0} {1}", i + 1, student.CourseSchedule[i].ToString());
      }
      Console.Write("Please enter the number of the course you would like to withdraw from. ");
      int input = int.Parse(Console.ReadLine());
      student.Withdraw(student.CourseSchedule[input - 1]);
    }*/
  }
}
