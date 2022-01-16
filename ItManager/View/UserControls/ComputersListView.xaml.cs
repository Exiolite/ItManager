using ItManager.ViewModel;
using System.Windows.Controls;

namespace ItManager.View.UserControls
{    public partial class ComputersListView : UserControl
    {
        public ComputersListView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var lw = (ListView)sender;
            var computerWindowView = new ComputerWinowView();
            computerWindowView.DataContext = (ComputerViewModel)lw.SelectedItem;
            computerWindowView.Show();
        }
    }
}
