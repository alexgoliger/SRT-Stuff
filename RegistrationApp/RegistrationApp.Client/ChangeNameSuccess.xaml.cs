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
  /// Interaction logic for ChangeNameSuccess.xaml
  /// </summary>
  public partial class ChangeNameSuccess : Window
  {
    public ChangeNameSuccess()
    {
      InitializeComponent();
      CenterWindowOnScreen();
    }

    private void Back_btn_Click(object sender, RoutedEventArgs e)
    {
      new MainWindow().Show();
      Close();
    }

    private void Done_btn_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void CenterWindowOnScreen()
    {
      Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
      Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (Height / 2);
    }
  }
}
