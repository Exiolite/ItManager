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

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var computerWindowView = new ComputerWinowView();
            var c = (ListBox)sender;
            computerWindowView.DataContext = (Computer)c.SelectedItem;
            computerWindowView.Show();
        }
    }
}
