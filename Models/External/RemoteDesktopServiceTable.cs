using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class RemoteDesktopServiceTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<RemoteDesktopService> _content = new ObservableCollection<RemoteDesktopService>();

        public ObservableCollection<RemoteDesktopService> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public RemoteDesktopService AddNewItem()
        {
            var item = new RemoteDesktopService();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }

        public RemoteDesktopService GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }

        public RemoteDesktopService Add(RemoteDesktopService item)
        {
            Content.Add(item);
            return item;
        }

        public void Drop()
        {
            Content.Clear();
        }
    }
}