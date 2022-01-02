using ItManager.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ItManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var l = (Control)sender;
            
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lw = (ListView)sender;
            CompanyView.DataContext = (CompanyViewModel)lw.SelectedItem;
        }
    }
}
