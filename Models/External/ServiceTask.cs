namespace Models.External
{
    public sealed class ServiceTask : Model
    {
        #region PropTargetId
        private int _targetId = -1;

        public int PropTargetId
        {
            get { return _targetId; }
            set { _targetId = value; NotifyPropertyChanged(nameof(PropTargetId)); PropIsEdited = true; }
        }

        #endregion

        #region PropName
        private string _name = "New Task";

        public string PropName
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(PropName)); PropIsEdited = true; }
        }

        #endregion

        #region PropDescription
        private string _description = "Description";

        public string PropDescription
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(PropDescription)); PropIsEdited = true; }
        }

        #endregion

        #region PropIsStarted
        private bool _isStarted;

        public bool PropIsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; NotifyPropertyChanged(nameof(PropIsStarted)); PropIsEdited = true; }
        }

        #endregion

        #region PropIsEnded
        private bool _isEnded;

        public bool PropIsEnded
        {
            get { return _isEnded; }
            set { _isEnded = value; NotifyPropertyChanged(nameof(PropIsEnded)); PropIsEdited = true; }
        }

        #endregion
    }
}
