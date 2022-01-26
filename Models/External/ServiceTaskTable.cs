using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ServiceTaskTable : Internal.Model
    {
        #region PropContent
        private ObservableCollection<ServiceTask> _content = new ObservableCollection<ServiceTask>();

        public ObservableCollection<ServiceTask> PropContent
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropContent)); }
        }
        #endregion

        public ServiceTask Add(int targetId)
        {
            var item = new ServiceTask();
            PropContent.Add(item);
            item.PropId = PropContent.IndexOf(item);
            item.PropTargetId = targetId;
            return item;
        }

        public ServiceTask GetById(int id)
        {
            return PropContent.FirstOrDefault(x => x.PropId == id);
        }

        public void Merge(ServiceTask item)
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