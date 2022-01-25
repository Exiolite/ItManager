using System.Windows;
using System.Windows.Controls;
using ViewModels;
using ViewModels.Internal;

namespace View.Internal
{
    public partial class FileDialogWindow : Window
    {
        public FileDialogWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            var viewModel = (FileViewModel)listBox.DataContext;
            var selectedItem = (string)listBox.SelectedItem;
            viewModel.PropFileOperation.PropCurrentFileName = selectedItem;
        }
    }
}
