﻿using System.Collections.ObjectModel;

namespace Models.External
{
    public sealed class AnyDeskTable : Internal.Model
    {
        #region property Content
        private ObservableCollection<AnyDesk> _content = new ObservableCollection<AnyDesk>();

        public ObservableCollection<AnyDesk> Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(Content)); }
        }
        #endregion

        public AnyDesk AddNew(int computeId)
        {
            var item = new AnyDesk() { ComputerId = computeId };
            Content.Add(item);
            item.Id = Content.IndexOf(item);
            return item;
        }


        public AnyDesk GetById(int id)
        {
            return Content.FirstOrDefault(x => x.Id == id);
        }
        public AnyDesk Add(AnyDesk item)
        {
            Content.Add(item);
            return item;
        }

        public void Merge(AnyDesk item)
        {
            var i = Content.FirstOrDefault(i => i.Id == item.Id);

            if (i != null)
            {
                i = item;
                return;
            }

            Add(item);

            item.PropertyIsEdited = false;
        }

        public void Drop()
        {
            Content.Clear();
        }
    }
}
