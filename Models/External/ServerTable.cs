using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ServerTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<Server> _content = new ObservableCollection<Server>();

        public ObservableCollection<Server> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public Server AddNew()
        {
            var item = new Server();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }

        public Server GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }

        public Server Add(Server item)
        {
            Content.Add(item);
            return item;
        }

        public void Merge(Server item)
        {
            if (Content.FirstOrDefault(i => i.Id == item.Id) != null)
                Content.Remove(Content.FirstOrDefault(i => i.Id == item.Id));
            Content.Add(item);
            item.PropertyIsEdited = false;
        }

        public void Drop()
        {
            Content.Clear();
        }
    }
}