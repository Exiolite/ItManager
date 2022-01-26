using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ComputerTable : Internal.Model
    {
        #region PropContent
        private ObservableCollection<Computer> _content = new ObservableCollection<Computer>();

        public ObservableCollection<Computer> PropContent
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropContent)); }
        }
        #endregion

        public Computer AddNewItem()
        {
            var item = new Computer();
            PropContent.Add(item);
            item.PropId = PropContent.IndexOf(item);
            return item;
        }

        public Computer GetById(int id)
        {
            return PropContent.FirstOrDefault(x => x.PropId == id);
        }

        public Computer Add(Computer item)
        {
            PropContent.Add(item);
            return item;
        }

        public void Merge(Computer item)
        {
            if (PropContent.FirstOrDefault(i => i.PropId == item.PropId) != null)
                PropContent.Remove(PropContent.FirstOrDefault(i => i.PropId == item.PropId));
            PropContent.Add(item);
            item.PropIsEdited = false;
        }

        public void Drop()
        {
            PropContent.Clear();
        }
    }
}
