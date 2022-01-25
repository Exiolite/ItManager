using System.Windows;
using ViewModels;

namespace Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
        }
    }
}
