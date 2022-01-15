using ItManager.Model;
using System.Windows;
using System.Windows.Controls;

namespace ItManager.View
{
    public partial class ComputerWinowView : Window
    {
        public ComputerWinowView()
        {
            InitializeComponent();
        }

        private void OnClickAnyDeskConnect(object sender, RoutedEventArgs e)
        {
            var c = (Control)sender;
            var pc = (Computer)c.DataContext;
            pc.AnyDesk.Connect();

        }

        private void OnEditAnyDesk(object sender, RoutedEventArgs e)
        {
            var anyDeskWindowView = new AnyDeskWindowView();
            var c = (Control)sender;
            var pc = (Computer)c.DataContext;
            anyDeskWindowView.DataContext = pc.AnyDesk;
            anyDeskWindowView.Show();
        }
    }
}
