using System.Windows.Controls;
using ViewModels.External;

namespace View.External
{
    public partial class CompanyStructureView : UserControl
    {
        public CompanyStructureView()
        {
            InitializeComponent();
        }

        private void ClickOpenCompanyInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var castedSender = (MenuItem)sender;
            var viewModel = (CompanyViewModel)castedSender.DataContext;
            var window = new CompanyWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenComputerInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = (Button)sender;
            var viewModel = (ComputerViewModel)button.DataContext;
            var window = new ComputerWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenServerInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = (Button)sender;
            var viewModel = (ServerViewModel)button.DataContext;
            var window = new ServerWindowView();

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
