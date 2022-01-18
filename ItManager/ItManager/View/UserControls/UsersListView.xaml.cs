using ItManager.View.Windows;
using ItManager.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItManager.View.UserControls
{
    public partial class UsersListView : UserControl
    {
        public UsersListView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lw = (ListView)sender;
            var uwv = new UserWindowView();
            uwv.DataContext = (UserViewModel)lw.SelectedItem;
            uwv.Show();
        }
    }
}
