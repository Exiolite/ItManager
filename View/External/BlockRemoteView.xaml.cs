using System.Windows.Controls;
using ViewModels.External;

namespace View.External
{
    public partial class BlockRemoteView : UserControl
    {
        public BlockRemoteView()
        {
            InitializeComponent();
        }

        private void AnyDeskClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var control = (Button)sender;
            var dataContext = (RemoteViewModel)control.DataContext;
            var anyDeskWindow = new AnyDeskWindow();

            anyDeskWindow.DataContext = dataContext.PropAnyDeskViewModel;
            anyDeskWindow.Show();
        }
    }
}
