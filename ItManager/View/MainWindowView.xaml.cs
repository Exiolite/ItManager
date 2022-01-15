using ItManager.Model;
using ItManager.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ItManager.View
{
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void OnClickCompany(object sender, SelectionChangedEventArgs e)
        {
            var lw = (ListBox)sender;
            CompanyView.DataContext = (DomainViewModel)lw.SelectedItem;
        }

        private void ComputerDoubleClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var computerWindowView = new ComputerWinowView();
            var c = (ListBox)sender;
            computerWindowView.DataContext = (ComputerViewModel)c.SelectedItem;
            computerWindowView.Show();
        }

        private void ServerDoubleClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var serverWindowView = new ServerWindowView();
            var c = (ListBox)sender;
            serverWindowView.DataContext = (ServerViewModel)c.SelectedItem;
            serverWindowView.Show();
        }
    }
}
