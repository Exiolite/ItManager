using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class StuffTable : Internal.Model
    {
        #region property Companies
        private ObservableCollection<Stuff> _content = new ObservableCollection<Stuff>();

        public ObservableCollection<Stuff> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public Stuff AddNewItem()
        {
            var item = new Stuff();
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }
    }
}