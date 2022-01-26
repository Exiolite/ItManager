using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class UserTable : Internal.Model
    {
        #region PropContent
        private ObservableCollection<User> _content = new ObservableCollection<User>();

        public ObservableCollection<User> PropContent
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropContent)); }
        }
        #endregion

        public User AddNewItem()
        {
            var item = new User();
            PropContent.Add(item);
            item.PropId = PropContent.IndexOf(item);
            return item;
        }

        public User GetById(int id)
        {
            return PropContent.FirstOrDefault(x => x.PropId == id);
        }

        public User Add(User item)
        {
            PropContent.Add(item);
            return item;
        }
        public void Merge(User item)
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