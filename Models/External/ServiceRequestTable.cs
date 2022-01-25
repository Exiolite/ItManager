using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class ServiceRequestTable : Internal.Model
    {
        #region PropContent
        private ObservableCollection<ServiceRequest> _content = new ObservableCollection<ServiceRequest>();

        public ObservableCollection<ServiceRequest> PropContent
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropContent)); }
        }
        #endregion

        public ServiceRequest AddAsCompany(int targetId)
        {
            var item = new ServiceRequest();
            PropContent.Add(item);
            item.PropId = PropContent.IndexOf(item);
            item.PropCompanyId = targetId;
            return item;
        }

        public ServiceRequest GetByCompanyId(int id)
        {
            return PropContent.FirstOrDefault(x => x.PropCompanyId == id);
        }

        public void Merge(ServiceRequest item)
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