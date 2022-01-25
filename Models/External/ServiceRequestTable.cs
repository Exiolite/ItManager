using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ServiceRequestTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<ServiceRequest> _content = new ObservableCollection<ServiceRequest>();

        public ObservableCollection<ServiceRequest> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public ServiceRequest AddAsCompany(int targetId)
        {
            var item = new ServiceRequest();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            item.PropCompanyId = targetId;
            return item;
        }

        public ServiceRequest GetByCompanyId(int id)
        {
            return Content.FirstOrDefault(x => x.PropCompanyId == id);
        }

        public void Merge(ServiceRequest item)
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