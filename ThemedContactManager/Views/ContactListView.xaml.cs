using System.Windows.Controls;
using ThemedContactManager.ViewModels;

namespace ThemedContactManager.Views
{
    public partial class ContactListView : UserControl
    {
        public ContactListView()
        {
            InitializeComponent();
            this.DataContext = new ContactViewModel();
        }
    }
}
