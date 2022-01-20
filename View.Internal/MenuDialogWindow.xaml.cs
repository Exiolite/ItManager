using System.Windows;

namespace ItManager.View.Internal
{
    public partial class MenuDialogWindow : Window
    {
        public static MenuDialogWindow Instance { get; private set; }
        public MenuDialogWindow()
        {
            InitializeComponent();
            if (Instance != null)
                Instance.Close();
            Instance = this;
        }
    }
}
