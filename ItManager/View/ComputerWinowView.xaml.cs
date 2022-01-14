using ItManager.Model;
using ItManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private void OnClickAddTask(object sender, RoutedEventArgs e)
        {
            var c = (Control)sender;
            var pc = (Computer)c.DataContext;
            pc.Tasks.Add(new Task());
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
