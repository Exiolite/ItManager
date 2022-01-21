using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class OSDescriptionTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<OSDescription> _content = new ObservableCollection<OSDescription>();

        public ObservableCollection<OSDescription> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public OSDescription AddNewItem()
        {
            var item = new OSDescription();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }

    }
}
