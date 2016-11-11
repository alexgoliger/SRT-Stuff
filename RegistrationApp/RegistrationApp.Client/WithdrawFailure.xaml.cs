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
  /// Interaction logic for WithdrawFailure.xaml
  /// </summary>
  public partial class WithdrawFailure : Window
  {
    private int _id;
    private string _firstName;
    private string _lastName;

    public WithdrawFailure()
    {
      InitializeComponent();
      CenterWindowOnScreen();
    }

    public WithdrawFailure(int id, string first, string last) : this()
    {
      _id = id;
      _firstName = first;
      _lastName = last;
    }

    private void Back_btn_Click(object sender, RoutedEventArgs e)
    {
      new WithdrawWindow(_id, _firstName, _lastName).Show();
      Close();
    }

    private void Done_btn_Click(object sender, RoutedEventArgs e)
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
