using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class MasterTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<Master> _content = new ObservableCollection<Master>();

        public ObservableCollection<Master> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public Master AddNewItem()
        {
            var item = new Master();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }
    }
}