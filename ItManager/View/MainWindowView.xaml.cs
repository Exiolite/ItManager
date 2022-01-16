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
    }
}
