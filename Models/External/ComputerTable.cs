using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ComputerTable : Internal.Model
    {
        #region property Computers
        private ObservableCollection<Computer> _content = new ObservableCollection<Computer>();

        public ObservableCollection<Computer> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public Computer AddNewItem()
        {
            var item = new Computer();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }
    }
}
