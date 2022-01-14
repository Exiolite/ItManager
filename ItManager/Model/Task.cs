using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ItManager.Model
{
    public class Task : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region IsStartedProperty
        private bool _isStarted;
        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; OnPropertyChanged("IsStarted"); }
        }
        #endregion
        #region IsCompletedProperty
        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; OnPropertyChanged("IsCompleted"); }
        }
        #endregion
        #region DescriptionProperty
        private string _description = "Description";
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }
        #endregion
    }
}
