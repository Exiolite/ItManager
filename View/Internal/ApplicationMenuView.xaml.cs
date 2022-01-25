using System.Windows.Controls;
using ViewModels;

namespace View.Internal
{
    public partial class ApplicationMenuView : UserControl
    {
        public ApplicationMenuView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var fileDialogWindowView = new FileDialogWindow();
            fileDialogWindowView.DataContext = MainViewModel.Instance.PropFileViewModel;
            fileDialogWindowView.Show();
        }
    }
}
