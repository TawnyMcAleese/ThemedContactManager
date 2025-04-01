using System.Collections.ObjectModel;
using System.Windows.Input;
using ThemedContactManager.Models;

namespace ThemedContactManager.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new();

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string Phone { get => _phone; set { _phone = value; OnPropertyChanged(); } }

        private string _firstName = "";
        private string _lastName = "";
        private string _email = "";
        private string _phone = "";

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ContactViewModel()
        {
            AddCommand = new RelayCommand(_ => AddContact());
            DeleteCommand = new RelayCommand(_ => DeleteContact(), _ => SelectedContact != null);
        }

        private void AddContact()
        {
            var newContact = new Contact
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = Phone
            };

            Contacts.Add(newContact);
            SelectedContact = newContact;

            FirstName = LastName = Email = Phone = "";
        }

        private void DeleteContact()
        {
            if (SelectedContact != null)
            {
                Contacts.Remove(SelectedContact);
                SelectedContact = null;
            }
        }
    }
}
