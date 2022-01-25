using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class UserTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<User> _content = new ObservableCollection<User>();

        public ObservableCollection<User> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public User AddNewItem()
        {
            var item = new User();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }

        public User GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }

        public User Add(User item)
        {
            Content.Add(item);
            return item;
        }
        public void Merge(User item)
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