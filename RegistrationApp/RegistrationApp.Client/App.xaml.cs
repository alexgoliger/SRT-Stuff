using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RegistrationApp.Client
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private const string CHECK_CONNECTION_MESSAGE = "Please make sure that you are connected to the Internet and are not currently experiencing any network issues.";

    private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
      MessageBox.Show(string.Format("An unhandled exception just occurred: {0}{1}{2}", e.Exception.Message, Environment.NewLine, CHECK_CONNECTION_MESSAGE), "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
      e.Handled = true;
    }
  }
}
