using ItManager.View.Windows;
using ItManager.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItManager.View.UserControls
{
    public partial class AdUsersListView : UserControl
    {
        public AdUsersListView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lw = (ListView)sender;
            var uwv = new AdUserWindowView();
            uwv.DataContext = (AdUserViewModel)lw.SelectedItem;
            uwv.Show();
        }
    }
}
