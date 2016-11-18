using AddressBook.Domain;
using AddressBook.Domain.AddressBookServiceReference;
using AddressBook.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace AddressBook.Client
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Contact> _contacts;
    private string _personIdentifierSelected;
    private EditMode _editMode;

    public MainWindow()
    {
      InitializeComponent();
      BindStates();
      _contacts = RetrieveContacts();
      ContactListDataGrid.ItemsSource = _contacts;
      ContactListDataGrid.SelectionChanged += ContactListDataGrid_SelectionChanged;
      ContactListDataGrid.MouseDoubleClick += ContactListDataGrid_MouseDoubleClick;
      AddContactButton.IsEnabledChanged += Button_IsEnabledChanged;
      RemoveContactButton.IsEnabledChanged += Button_IsEnabledChanged;
      ChangeContactButton.IsEnabledChanged += Button_IsEnabledChanged;
    }

    #region Button Events
    private void Button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      Button button = sender as Button;
      var dockPanel = button.Content as DockPanel;
      if (dockPanel != null && dockPanel.Children.Count >= 2)
      {
        TextBlock textBlock = dockPanel.Children[1] as TextBlock;
        if (textBlock != null && button.IsEnabled)
        {
          textBlock.Foreground = Brushes.Yellow;
        }
        else if (textBlock != null && !button.IsEnabled)
        {
          textBlock.Foreground = Brushes.DarkBlue;
        }
      }
    }

    private void Button_MouseEnter(object sender, MouseEventArgs e)
    {
      Button button = sender as Button;
      if (button != null)
      {
        button.Background = Brushes.DarkBlue;
        var dockPanel = button.Content as DockPanel;
        if (dockPanel != null && dockPanel.Children.Count >= 2)
        {
          var text = dockPanel.Children[1] as TextBlock;
          if (text != null)
          {
            text.Foreground = Brushes.DarkBlue;
          }
        }
      }
    }

    private void Button_MouseLeave(object sender, MouseEventArgs e)
    {
      Button button = sender as Button;
      if (button != null)
      {
        button.Background = Brushes.DarkBlue;
        var dockPanel = button.Content as DockPanel;
        if (dockPanel != null && dockPanel.Children.Count >= 2)
        {
          var text = dockPanel.Children[1] as TextBlock;
          if (text != null)
          {
            text.Foreground = Brushes.Yellow;
          }
        }
      }
    }

    private void TakeAnActionPanelButton_Click(object sender, RoutedEventArgs e)
    {
      Button button = sender as Button;
      if (button != null)
      {
        switch (button.Name)
        {
          case "AddContactButton":
            InvokeAddNewContact();
            break;
          case "RemoveContactButton":
            var isPlural = ContactListDataGrid.SelectedItems.Count > 1;
            var message = string.Format("Are you sure you want to delete the selected contact{0}? This operation cannot be undone.", isPlural ? "s" : string.Empty);
            var result = MessageBox.Show(message, "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
              InvokeRemoveContacts();
            }
            break;
          case "ChangeContactButton":
            InvokeChangeContact();
            break;
        }
      }
    }

    private void AddChangeContactPanelButton_Click(object sender, RoutedEventArgs e)
    {
      Button button = sender as Button;
      if (button != null)
      {
        switch (button.Name)
        {
          case "ConfirmAddChangeContactButton":
            if (_editMode == EditMode.Adding)
            {
              List<string> errors;
              if (!TryAddNewContact(out errors))
              {
                //TODO: print error message if validation fails
                StringBuilder builder = new StringBuilder();
                builder.Append("The following errors occured. Please resolve the following errors and try again:");
                builder.AppendLine();
                builder.AppendLine();
                foreach (var error in errors)
                {
                  builder.Append(error);
                  builder.AppendLine();
                }

                MessageBox.Show(builder.ToString(), "Could Not Add Contact", MessageBoxButton.OK, MessageBoxImage.Error);
              }
              else
              {
                MessageBox.Show("Contact added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ShowMainMenu();
              }
            }
            else
            {
              List<string> errors;
              if (!TryUpdateContact(out errors))
              {
                //TODO: print error message if validation fails
                StringBuilder builder = new StringBuilder();
                builder.Append("The following errors occured. Please resolve the following errors and try again:");
                builder.AppendLine();
                builder.AppendLine();
                foreach (var error in errors)
                {
                  builder.Append(error);
                  builder.AppendLine();
                }

                MessageBox.Show(builder.ToString(), "Could Not Update Contact", MessageBoxButton.OK, MessageBoxImage.Error);
              }
              else
              {
                MessageBox.Show("Contact updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ShowMainMenu();
              }
            }
            break;
          case "CancelAddChangeContactButton":
            var result = MessageBox.Show("Are you sure you want to cancel? All unsaved changes will be lost.", "Confirm Cancellation", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
              //TODO: clear input fields
              ShowMainMenu();
            }
            break;
        }
      }
    }
    #endregion

    #region DataGrid Events
    private void ContactListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      DataGrid grid = sender as DataGrid;
      TextBlock removeTextBlock = null;
      var dockPanel = RemoveContactButton.Content as DockPanel;
      if (dockPanel != null && dockPanel.Children.Count >= 2)
      {
        removeTextBlock = dockPanel.Children[1] as TextBlock;
      }
      if (grid.SelectedItems.Count == 0)
      {
        ChangeContactButton.Visibility = Visibility.Hidden;
        RemoveContactButton.IsEnabled = false;
      }
      else if (grid.SelectedItems.Count == 1)
      {
        ChangeContactButton.Visibility = Visibility.Visible;
        RemoveContactButton.IsEnabled = true;
        if (removeTextBlock != null)
        {
          removeTextBlock.Text = "Remove Contact";
        }
      }
      else
      {
        ChangeContactButton.Visibility = Visibility.Hidden;
        RemoveContactButton.IsEnabled = true;
        if (removeTextBlock != null)
        {
          removeTextBlock.Text = "Remove Contacts";
        }
      }
    }

    private void ContactListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      DataGrid grid = sender as DataGrid;
      if (grid != null && grid.SelectedItems.Count == 1)
      {
        ChangeContactButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
      }
    }
    #endregion

    #region UtilityMethods
    private void ClearEditor()
    {
      FirstNameTextBox.Text = string.Empty;
      MiddleNameTextBox.Text = string.Empty;
      LastNameTextBox.Text = string.Empty;
      StreetTextBox.Text = string.Empty;
      CityTextBox.Text = string.Empty;
      StateComboBox.Text = string.Empty;
      ZipTextBox.Text = string.Empty;
      PhoneTextBox.Text = string.Empty;
      EmailTextBox.Text = string.Empty;
    }

    private void BindEditor()
    {
      var item = ContactListDataGrid.SelectedItem as Contact;
      if (item != null)
      {
        _personIdentifierSelected = item.PersonIdentifier;
        var person = DomainHelper.GetPerson(item.PersonIdentifier);
        FirstNameTextBox.Text = person.FirstName;
        MiddleNameTextBox.Text = person.MiddleName;
        LastNameTextBox.Text = person.LastName;
        StreetTextBox.Text = person.Street;
        CityTextBox.Text = person.City;
        StateComboBox.Text = person.State;
        ZipTextBox.Text = person.Zip;
        PhoneTextBox.Text = person.Phone;
        EmailTextBox.Text = person.Email;
      }
    }

    private void ShowMainMenu()
    {
      TakeAnActionPanel.Visibility = Visibility.Visible;
      AddChangeContactPanel.Visibility = Visibility.Collapsed;
      ClearEditor();
    }

    private void InvokeAddNewContact()
    {
      _editMode = EditMode.Adding;
      TakeAnActionPanel.Visibility = Visibility.Collapsed;
      AddChangeContactPanel.Visibility = Visibility.Visible;
      AddChangeContactLabel.Content = new TextBlock { Text = "Add Contact" };
      AddChangeContactSymbol.Text = "+";
      AddChangeContactSymbol.Foreground = Brushes.Green;
      AddChangeContactText.Text = "Add";
    }

    private void InvokeRemoveContacts()
    {
      var selected = ContactListDataGrid.SelectedItems;
      List<string> identifiersToRemove = new List<string>();
      foreach (var item in selected)
      {
        var contact = item as Contact;
        identifiersToRemove.Add(contact.PersonIdentifier);
        _contacts.Remove(contact);
      }

      ContactListDataGrid.ItemsSource = _contacts;
      ContactListDataGrid.Items.Refresh();
      ParameterizedThreadStart removeStart = new ParameterizedThreadStart(RemoveContactsByIdentifiers);
      Thread removeThread = new Thread(removeStart);
      removeThread.Start(identifiersToRemove);
    }

    private void RemoveContactsByIdentifiers(object identifiers)
    {
      var list = identifiers as List<string>;
      DomainHelper.RemoveContacts(list);
    }

    private void InvokeChangeContact()
    {
      _editMode = EditMode.Changing;
      TakeAnActionPanel.Visibility = Visibility.Collapsed;
      AddChangeContactPanel.Visibility = Visibility.Visible;
      AddChangeContactLabel.Content = new TextBlock { Text = "Change Contact" };
      AddChangeContactSymbol.Text = "~";
      AddChangeContactSymbol.Foreground = Brushes.Orange;
      AddChangeContactText.Text = "Change";
      BindEditor();
    }

    private List<Contact> RetrieveContacts()
    {
      List<PersonRecord> contacts = DomainHelper.GetAllContacts();
      var result = (from c in contacts
                    select new Contact
                    {
                      PersonIdentifier = c.PersonIdentifier,
                      Name = string.Format("{0}{1}{2}",
                       c.Name.FirstName,
                       !string.IsNullOrWhiteSpace(c.Name.MiddleName) ? ' ' + c.Name.MiddleName + ' ' : " ",
                       c.Name.LastName),
                      Address = string.Format("{0}, {1}, {2} {3}", c.Address.Street, c.Address.City, c.Address.State, c.Address.Zip),
                      PhoneNumber = FormatPhone(c.Phone.Phone),
                      Email = c.Email.Email
                    }).ToList();
     
      return result;
    }

    private bool TryAddNewContact(out List<string> errors)
    {
      //TODO: validate and add contact to db if applicable
      var contact = new ContactDTO
      {
        FirstName = FirstNameTextBox.Text,
        MiddleName = MiddleNameTextBox.Text,
        LastName = LastNameTextBox.Text,
        Street = StreetTextBox.Text,
        City = CityTextBox.Text,
        State = StateComboBox.Text,
        Zip = ZipTextBox.Text,
        Phone = PhoneTextBox.Text,
        Email = EmailTextBox.Text
      };

      var result = DomainHelper.TryAddNewContact(contact, out errors);
      if (result != null)
      {
        _contacts.Add(new Contact
        {
          PersonIdentifier = result,
          Name = string.Format("{0}{1}{2}",
                      contact.FirstName,
                      !string.IsNullOrWhiteSpace(contact.MiddleName) ? ' ' + contact.MiddleName + ' ' : " ",
                      contact.LastName),
          Address = string.Format("{0}, {1}, {2} {3}", contact.Street, contact.City, contact.State, contact.Zip),
          PhoneNumber = FormatPhone(contact.Phone),
          Email = contact.Email
        });
        ContactListDataGrid.ItemsSource = _contacts;
        ContactListDataGrid.Items.Refresh();

        return true;
      }

      return false;
    }

    private bool TryUpdateContact(out List<string> errors)
    {
      //TODO: validate and add contact to db if applicable
      var contact = new ContactDTO
      {
        FirstName = FirstNameTextBox.Text,
        MiddleName = MiddleNameTextBox.Text,
        LastName = LastNameTextBox.Text,
        Street = StreetTextBox.Text,
        City = CityTextBox.Text,
        State = StateComboBox.Text,
        Zip = ZipTextBox.Text,
        Phone = PhoneTextBox.Text,
        Email = EmailTextBox.Text,
        PersonIdentifier = _personIdentifierSelected
      };
      
      if (DomainHelper.TryUpdateContact(contact, out errors))
      {
        var current = _contacts.Find(x => x.PersonIdentifier == _personIdentifierSelected);
        current.Name = string.Format("{0}{1}{2}",
                      contact.FirstName,
                      !string.IsNullOrWhiteSpace(contact.MiddleName) ? ' ' + contact.MiddleName + ' ' : " ",
                      contact.LastName);
        current.Address = string.Format("{0}, {1}, {2} {3}", contact.Street, contact.City, contact.State, contact.Zip);
        current.PhoneNumber = FormatPhone(contact.Phone);
        current.Email = contact.Email;

        ContactListDataGrid.ItemsSource = _contacts;
        ContactListDataGrid.Items.Refresh();

        return true;
      }

      return false;
    }

    private string FormatPhone(string phone)
    {
      var phoneRegex = new Regex("[^0-9]+");
      var strippedPhone = phoneRegex.Replace(phone, string.Empty);
      if (strippedPhone.Length == 7)
      {
        return string.Format("{0}-{1}", strippedPhone.Substring(0, 3), strippedPhone.Substring(3));
      }
      else if (strippedPhone.Length == 10)
      {
        return string.Format("({0}) {1}-{2}", strippedPhone.Substring(0, 3), strippedPhone.Substring(3, 3), strippedPhone.Substring(6));
      }
      else if (strippedPhone.Length == 11)
      {
        return string.Format("+{0} ({1}) {2}-{3}", strippedPhone.Substring(0, 1), strippedPhone.Substring(1, 3), strippedPhone.Substring(4, 3), strippedPhone.Substring(7));
      }
      else
      {
        return strippedPhone;
      }
    }

    private void BindStates()
    {
      var states = from state in DomainHelper.GetAllStates()
                   select state.State;

      StateComboBox.ItemsSource = states;
    }
    #endregion

    #region Key Events
    private void Input_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key.Equals(Key.Enter))
      {
        ConfirmAddChangeContactButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
      }
    }
    #endregion
  }

  public class Contact
  {
    public string PersonIdentifier { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
  }

  public enum EditMode
  {
    Adding = 0, Changing = 1
  }
}
