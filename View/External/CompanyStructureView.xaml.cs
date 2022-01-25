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
            var control = (MenuItem)sender;
            var viewModel = (CompanyViewModel)control.DataContext;
            var window = new CompanyWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenComputerInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var control = (MenuItem)sender;
            var viewModel = (ComputerViewModel)control.DataContext;
            var window = new ComputerWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenServerInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var control = (MenuItem)sender;
            var viewModel = (ServerViewModel)control.DataContext;
            var window = new ServerWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenStuffInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var control = (MenuItem)sender;
            var viewModel = (UserViewModel)control.DataContext;
            var window = new UserWindow();

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
