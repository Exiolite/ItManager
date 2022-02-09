using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.External;

namespace View.External
{
    /// <summary>
    /// Interaction logic for LayoutCompanyStructureView.xaml
    /// </summary>
    public partial class LayoutCompanyStructureView : UserControl
    {
        public LayoutCompanyStructureView()
        {
            InitializeComponent();
        }

        private void ClickOpenCompanyInNewWindow(object sender, MouseButtonEventArgs e)
        {
            var libBox = (ListBox)sender;
            var viewModel = (CompanyViewModel)libBox.SelectedItem; ;
            var window = new CompanyWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenComputerInNewWindow(object sender, MouseButtonEventArgs e)
        {
            var libBox = (ListBox)sender;
            var viewModel = (ComputerViewModel)libBox.SelectedItem;
            var window = new ComputerWindowView();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenUserInNewWindow(object sender, MouseButtonEventArgs e)
        {
            var libBox = (ListBox)sender;
            var viewModel = (UserViewModel)libBox.SelectedItem;
            var window = new UserWindow();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenServiceRequestInNewWindow(object sender, MouseButtonEventArgs e)
        {
            var libBox = (ListBox)sender;
            var viewModel = (ServiceRequestViewModel)libBox.SelectedItem;
            var window = new ServiceRequestWindow();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ClickOpenADUserInNewWindow(object sender, MouseButtonEventArgs e)
        {
            var libBox = (ListBox)sender;
            var viewModel = (ADUserViewModel)libBox.SelectedItem;
            var window = new ADUserWindow();

            window.DataContext = viewModel;
            window.Show();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var libBox = (ListBox)sender;
            var viewModel = (ComputerViewModel)libBox.SelectedItem;
            var window = new ComputerWindowView();

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
