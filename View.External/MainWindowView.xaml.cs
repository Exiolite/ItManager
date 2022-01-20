using System.Windows;

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
