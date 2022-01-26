using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class CompanyTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<Company> _content = new ObservableCollection<Company>();

        public ObservableCollection<Company> PropContent
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropContent)); }
        }
        #endregion

        public Company AddNewCompany()
        {
            var item = new Company();
            PropContent.Add(item);
            item.PropId = PropContent.IndexOf(item);
            return item;
        }

        public void Merge(Company item)
        {
            if(PropContent.FirstOrDefault(i => i.PropId == item.PropId) != null)
                PropContent.Remove(PropContent.FirstOrDefault(i => i.PropId == item.PropId));
            PropContent.Add(item);
            item.PropIsEdited = false;
        }
    }
}
