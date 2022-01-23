using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ViewModels.Internal;

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
            var control = (MenuItem)sender;
            var dataContext = (FileViewModel)control.DataContext;
            var fileDialogWindowView = new FileDialogWindow();

            fileDialogWindowView.DataContext = dataContext;
            fileDialogWindowView.Show();
        }
    }
}
