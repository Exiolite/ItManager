using System.Windows;
using System.Windows.Controls;
using ItManager.ViewModel;

namespace ItManager.View.UserControls
{
    public partial class CompaniesListView : UserControl
    {
        public CompaniesListView()
        {
            InitializeComponent();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lw = (ListBox)sender;
            MainWindowView.Instance.CompanyView.DataContext = (CompanyViewModel)lw.SelectedItem;
        }
    }
}