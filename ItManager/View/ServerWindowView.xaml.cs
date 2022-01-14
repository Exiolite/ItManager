using ItManager.Model;
using System.Windows;
using System.Windows.Controls;

namespace ItManager.View
{
    public partial class ServerWindowView : Window
    {
        public ServerWindowView()
        {
            InitializeComponent();
        }

        private void OnClickAddTask(object sender, RoutedEventArgs e)
        {
            var c = (Control)sender;
            var pc = (Server)c.DataContext;
            pc.Tasks.Add(new Task());
        }
    }
}
