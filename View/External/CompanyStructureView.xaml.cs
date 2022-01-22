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

        private void OpenComputerInNewWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = (Button)sender;
            var computerViewModel = (ComputerViewModel)button.DataContext;
            var computerWindowView = new ComputerWindowView();

            computerWindowView.DataContext = computerViewModel;
            computerWindowView.Show();
        }
    }
}
