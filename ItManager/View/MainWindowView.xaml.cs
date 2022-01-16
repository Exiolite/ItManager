using ItManager.Model;
using ItManager.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ItManager.View
{
    public partial class MainWindowView : Window
    {
        public static MainWindowView Instance { get; private set; }
        public MainWindowView()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
