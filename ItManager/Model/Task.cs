using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ItManager.Model
{
    public class Task : INotifyPropertyChanged
    {
        public Task() { }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region IsCompletedProperty
        private bool isCompleted = false;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; OnPropertyChanged("IsCompleted"); }
        }
        #endregion
        #region DescriptionProperty
        private string description = "No description...";
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
        #endregion
    }
}
