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

        public Computer GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }

        public Computer Add(Computer item)
        {
            Content.Add(item);
            return item;
        }

        public void Merge(Computer item)
        {
            var i = Content.FirstOrDefault(i => i.Id == item.Id);

            if (i != null)
            {
                i = item;
                return;
            }

            Add(item);

            item.PropertyIsEdited = false;
        }

        public void Drop()
        {
            Content.Clear();
        }
    }
}
