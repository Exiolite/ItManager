using ItManager.ViewModel;
using System.Windows.Controls;

namespace ItManager.View.UserControls
{
    public partial class ServersListView : UserControl
    {
        public ServersListView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var lw = (ListView)sender;
            var serverWindowView = new ServerWindowView();
            serverWindowView.DataContext = (ServerViewModel)lw.SelectedItem;
            serverWindowView.Show();
        }
    }
}
