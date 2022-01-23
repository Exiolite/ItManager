using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class CompanyTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<Company> _content = new ObservableCollection<Company>();

        public ObservableCollection<Company> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public Company AddNewCompany()
        {
            var item = new Company();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }

        public Company GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }

        public Company Add(Company item)
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
