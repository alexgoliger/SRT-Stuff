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
using System.Windows.Shapes;

namespace RegistrationApp.Client
{
  /// <summary>
  /// Interaction logic for RegistrationWindow.xaml
  /// </summary>
  public partial class RegistrationWindow : Window
  {
    StudentDTO s;

    public RegistrationWindow()
    {
      InitializeComponent();
      CenterWindowOnScreen();
      DisplayAvailableCourses();
    }

    public RegistrationWindow(int id, string first, string last) : this()
    {
      Student_Id_block.Text = id.ToString();
      First_Name_block.Text = first;
      Last_Name_block.Text = last;
      s = new StudentDTO(id, first, last);
      DisplayStudentSchedule();
    }

    private void DisplayAvailableCourses()
    {
      var l = DomainHelper.GetAllCourses();
      foreach (var c in l)
      {
        CourseDTO course = ObjectMapper.ConvertToCourseDTO(c.Value);
        if (Domain.Validation.GetEnrolledStudents(course).Count < 20)
        {
          Available_Courses_box.Items.Add(course);
        }
      }
    }

    private void DisplayStudentSchedule()
    {
      var l = DomainHelper.GetCourseSchedule(s);
      foreach (KeyValuePair<int, Course> c in l)
      {
        Current_Courses_box.Items.Add(c.Value);
      }
    }

    private void CenterWindowOnScreen()
    {
      Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
      Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (Height / 2);
    }

    private void Register_btn_Click(object sender, RoutedEventArgs e)
    {
      CourseDTO c = null;
      try
      {
        c = ObjectMapper.ConvertToCourseDTO(DomainHelper.FindCourse(int.Parse(Course_Id_txt.Text)));
      }
      catch (Exception)
      {
        new InvalidInput("You did not enter a valid course ID!", s, "Registration").Show();
        Close();
      }
      
      if (c != null)
      {
        int regId = DomainHelper.Register(s, c);
        if (regId > 0)
        {
          new RegistrationSuccess(s.StudentId, s.FirstName, s.LastName).Show();
          Close();
        }

        else
        {
          new RegistrationFailure(s.StudentId, s.FirstName, s.LastName).Show();
          Close();
        }
      }
    }

    private void Done_btn_Click(object sender, RoutedEventArgs e)
    {
      new MainWindow().Show();
      Close();
    }

    private void RefreshWindow()
    {
      new RegistrationWindow(s.StudentId, s.FirstName, s.LastName).Show();
      Close();
    }
  }
}
