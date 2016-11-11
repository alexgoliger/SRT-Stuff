using RegistrationApp.Data;
using RegistrationApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistrationApp.Client
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      CenterWindowOnScreen();
      DisplayAvailableCourses();
    }

    public MainWindow(int id, string first, string last) : this()
    {
      Student_Id_txt.Text = id.ToString();
      First_Name_txt.Text = first;
      Last_Name_txt.Text = last;
    }

    private void Register_btn_Click(object sender, RoutedEventArgs e)
    {
      bool validInput = ValidateInput();
      if (validInput && StudentIsValid())
      {
        new RegistrationWindow(int.Parse(Student_Id_txt.Text), First_Name_txt.Text, Last_Name_txt.Text).Show();
        Close();
      }
      else if (validInput && !StudentIsValid())
      {
        new InvalidInput("A different student with the same ID already exists!").Show();
        Close();
      }
    }

    private void Withdraw_btn_Click(object sender, RoutedEventArgs e)
    {
      bool validInput = ValidateInput();
      if (validInput && StudentIsValid())
      {
        StudentDTO s = new StudentDTO(int.Parse(Student_Id_txt.Text), First_Name_txt.Text, Last_Name_txt.Text);
        if (DomainHelper.GetCourseSchedule(s).Count > 0)
        {
          new WithdrawWindow(s.StudentId, s.FirstName, s.LastName).Show();
          Close();
        }
        else
        {
          new EmptyScheduleWindow().Show();
          Close();
        }
      }
      else if (validInput && !StudentIsValid())
      {
        new InvalidInput("A different student with the same ID already exists!").Show();
        Close();
      }
    }

    private void View_Your_Courses_btn_Click(object sender, RoutedEventArgs e)
    {
      Current_Courses_list.Items.Clear();
      bool validInput = ValidateInput();
      if (validInput && StudentIsValid())
      {
        DisplayStudentSchedule();
      }
      else if (validInput && !StudentIsValid())
      {
        new InvalidInput("A different student with the same ID already exists!").Show();
        Close();
      }
    }

    private void DisplayStudentSchedule()
    {
      StudentDTO s = new StudentDTO(int.Parse(Student_Id_txt.Text), First_Name_txt.Text, Last_Name_txt.Text);
      var l = DomainHelper.GetCourseSchedule(s);
      foreach (KeyValuePair<int, Course> c in l)
      {
        Current_Courses_list.Items.Add(c.Value);
      }
    }

    private void Change_Name_btn_Click(object sender, RoutedEventArgs e)
    {
      bool validInput = ValidateInput();
      if (validInput && StudentIsValid())
      {
        new ChangeNameWindow(int.Parse(Student_Id_txt.Text), First_Name_txt.Text, Last_Name_txt.Text).Show();
        Close();
      }
      else if (validInput && !StudentIsValid())
      {
        new InvalidInput("A different student with the same ID already exists!").Show();
        Close();
      }
    }

    private void DisplayAvailableCourses()
    {
      var l = DomainHelper.GetAllCourses();
      foreach (var c in l)
      {
        CourseDTO course = ObjectMapper.ConvertToCourseDTO(c.Value);
        if (Domain.Validation.GetEnrolledStudents(course).Count < 20)
        {
          Available_Courses_list.Items.Add(course);
        }
      }
    }

    private bool ValidateInput()
    {
      int id = -1;
      try
      {
        id = int.Parse(Student_Id_txt.Text);
        if (id <= 0)
        {
          throw new Exception();
        }
      }
      catch (Exception)
      {
        new InvalidInput("You did not enter a valid student ID!").Show();
        Close();
        return false;
      }

      if (string.IsNullOrWhiteSpace(First_Name_txt.Text))
      {
        new InvalidInput("You did not enter a valid first name!").Show();
        Close();
        return false;
      }

      if (string.IsNullOrWhiteSpace(Last_Name_txt.Text))
      {
        new InvalidInput("You did not enter a valid last name!").Show();
        Close();
        return false;
      }

      return true;
    }

    private bool StudentIsValid()
    {
      int id = int.Parse(Student_Id_txt.Text);
      Student student = DomainHelper.FindStudent(id);
      Student s = new Student { StudentId = id, FirstName = First_Name_txt.Text, LastName = Last_Name_txt.Text };
      if (student != null && student.Equals(s))   // a student with this information exists
      {
        return true;
      }
      else if (student != null && !student.Equals(s)) // a student with this ID exists, but with a different name
      {
        return false;
        
      }
      else    // a student with this ID does not exist, so the student is considered new
      {
        return true;
      }
    }

    private void CenterWindowOnScreen()
    {
      Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
      Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (Height / 2);
    }

    private void Exit_btn_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
