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
  /// Interaction logic for WithdrawWindow.xaml
  /// </summary>
  public partial class WithdrawWindow : Window
  {
    StudentDTO s;

    public WithdrawWindow()
    {
      InitializeComponent();
      CenterWindowOnScreen();
    }

    public WithdrawWindow(int id, string first, string last) : this()
    {
      Student_Id_block.Text = id.ToString();
      First_Name_block.Text = first;
      Last_Name_block.Text = last;
      s = new StudentDTO(id, first, last);
      if (DomainHelper.GetCourseSchedule(s).Count == 0)
      {
        new EmptyScheduleWindow().Show();
        Close();
      }
      DisplayStudentSchedule();
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

    private void Withdraw_btn_Click(object sender, RoutedEventArgs e)
    {
      CourseDTO c = null;
      try
      {
        c = ObjectMapper.ConvertToCourseDTO(DomainHelper.FindCourse(int.Parse(Course_Id_txt.Text)));
      }
      catch (Exception)
      {
        new InvalidInput("You did not enter a valid course ID!", s, "Withdraw").Show();
        Close();
      }

      if (c != null)
      {
        bool success = DomainHelper.Withdraw(s, c);
        if (success)
        {
          new WithdrawSuccess(s.StudentId, s.FirstName, s.LastName).Show();
          Close();
        }

        else
        {
          new WithdrawFailure(s.StudentId, s.FirstName, s.LastName).Show();
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
      new WithdrawWindow(s.StudentId, s.FirstName, s.LastName).Show();
      Close();
    }
  }
}