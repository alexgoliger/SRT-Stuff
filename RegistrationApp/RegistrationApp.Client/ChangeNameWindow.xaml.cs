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
  /// Interaction logic for ChangeNameWindow.xaml
  /// </summary>
  public partial class ChangeNameWindow : Window
  {
    StudentDTO s;
    public ChangeNameWindow()
    {
      InitializeComponent();
      CenterWindowOnScreen();
    }

    public ChangeNameWindow(int id, string first, string last) : this()
    {
      Student_Id_block.Text = id.ToString();
      First_Name_Current_block.Text = first;
      Last_Name_Current_block.Text = last;
      s = new StudentDTO(id, first, last);
    }

    private void Submit_btn_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrWhiteSpace(First_Name_New_txt.Text))
      {
        new InvalidInput("You did not enter a valid first name!", s, "ChangeName").Show();
        Close();
      }
      else if (string.IsNullOrWhiteSpace(Last_Name_New_txt.Text))
      {
        new InvalidInput("You did not enter a valid last name!", s, "ChangeName").Show();
        Close();
      }
      else
      {
        DomainHelper.ModifyStudentById(s.StudentId, First_Name_New_txt.Text, Last_Name_New_txt.Text);
        new ChangeNameSuccess().Show();
        Close();
      }
    }

    private void Cancel_btn_Click(object sender, RoutedEventArgs e)
    {
      new MainWindow().Show();
      Close();
    }

    private void CenterWindowOnScreen()
    {
      Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
      Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (Height / 2);
    }
  }
}
