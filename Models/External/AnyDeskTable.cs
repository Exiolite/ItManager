using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class AnyDeskTable : Internal.Model
    {
        #region property Content
        private ObservableCollection<AnyDesk> _content = new ObservableCollection<AnyDesk>();

        public ObservableCollection<AnyDesk> PropContent
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropContent)); }
        }
        #endregion

        public AnyDesk AddNew(int computeId)
        {
            var item = new AnyDesk() { PropComputerId = computeId };
            PropContent.Add(item);
            item.PropId = PropContent.IndexOf(item);
            return item;
        }

        public AnyDesk GetById(int id)
        {
            return PropContent.FirstOrDefault(x => x.PropId == id);
        }

        public AnyDesk GetOrCreateByComputer(int id)
        {
            var anyDesk = PropContent.FirstOrDefault(x => x.PropComputerId == id);
            if (anyDesk == null) return new AnyDesk() { PropComputerId = id};
            return anyDesk;
        }

        public AnyDesk Add(AnyDesk item)
        {
            PropContent.Add(item);
            return item;
        }

        public void Merge(AnyDesk item)
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
