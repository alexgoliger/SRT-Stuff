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
  /// Interaction logic for InvalidInput.xaml
  /// </summary>
  public partial class InvalidInput : Window
  {
    private string _window;
    private int _id;
    private string _first;
    private string _last;

    public InvalidInput()
    {
      InitializeComponent();
      CenterWindowOnScreen();
    }

    public InvalidInput(string message) : this()
    {
      Message_block.Text = message;
      _window = "Main";
    }

    public InvalidInput(string message, string window = "Main") : this()
    {
      Message_block.Text = message;
      _window = window;
    }

    public InvalidInput(string message, StudentDTO s, string window = "Main") : this()
    {
      Message_block.Text = message;
      _window = window;
      _id = s.StudentId;
      _first = s.FirstName;
      _last = s.LastName;
    }

    private void OK_btn_Click(object sender, RoutedEventArgs e)
    {
      if (_window == "Main")
      {
        new MainWindow().Show();
        Close();
      }

      else if (_window == "Registration")
      {
        new RegistrationWindow(_id, _first, _last).Show();
        Close();
      }

      else if (_window == "Withdraw")
      {
        new WithdrawWindow(_id, _first, _last).Show();
        Close();
      }
      
      else if (_window == "ChangeName")
      {
        new ChangeNameWindow(_id, _first, _last).Show();
        Close();
      }

      else
      {
        new MainWindow().Show();
        Close();
      }
    }

    private void CenterWindowOnScreen()
    {
      Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
      Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (Height / 2);
    }
  }
}
