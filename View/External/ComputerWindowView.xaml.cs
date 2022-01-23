using System.Windows;
using System.Windows.Controls;
using ViewModels.External;

namespace View.External
{
    /// <summary>
    /// Interaction logic for ComputerWindowView.xaml
    /// </summary>
    public partial class ComputerWindowView : Window
    {
        public ComputerWindowView()
        {
            InitializeComponent();
        }

        private void Button_AnyDeskEdit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var control = (Button)sender;
            var dataContext = (ComputerViewModel)control.DataContext;
            var anyDeskWindow = new AnyDeskWindow();

            anyDeskWindow.DataContext = dataContext.PropertyAnyDeskViewModel;
            anyDeskWindow.Show();
        }
    }
}
