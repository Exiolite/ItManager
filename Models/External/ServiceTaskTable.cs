using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ServiceTaskTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<ServiceTask> _content = new ObservableCollection<ServiceTask>();

        public ObservableCollection<ServiceTask> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public ServiceTask Add(int targetId)
        {
            var item = new ServiceTask();
            Content.Add(item);
            item.Id = targetId;
            return item;
        }

        public ServiceTask GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }

        public ServiceTask Add(ServiceTask item)
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