using ItManager.ViewModel;
using System.Windows.Controls;

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
