using ItManager.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ItManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EditorWindowView : Window
    {
        public EditorWindowView()
        {
            InitializeComponent();
        }

        private void OnClickCompany(object sender, RoutedEventArgs e)
        {
            var l = (Control)sender;
            CompanyView.DataContext = (CompanyViewModel)l.DataContext;
        }
    }
}
