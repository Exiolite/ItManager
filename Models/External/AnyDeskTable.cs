using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class AnyDeskTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<AnyDesk> _content = new ObservableCollection<AnyDesk>();

        public ObservableCollection<AnyDesk> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public AnyDesk AddNewCompany()
        {
            var item = new AnyDesk();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }
    }
}
