namespace Models.External
{
    public class TeamViewer : Model
    {
        #region PropComputerId
        private int _computerId = -1;

        public int PropComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropComputerId)); PropIsEdited = true; }
        }

        #endregion

        #region PropTeamViewerId
        private string _teamViewerId = "123456789";

        public string PropTeamViewerId
        {
            get { return _teamViewerId; }
            set { _teamViewerId = value; NotifyPropertyChanged(nameof(PropTeamViewerId)); PropIsEdited = true; }
        }

        #endregion

        #region PropTeamViewerPassword
        private string _teamviewerPassword = "Password";

        public string PropTeamViewerPassword
        {
            get { return _teamviewerPassword; }
            set { _teamviewerPassword = value; NotifyPropertyChanged(nameof(PropTeamViewerPassword)); PropIsEdited = true; }
        }

        #endregion

        #region PropIsEnabled
        private bool _isEnabled = false;

        public bool PropIsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; NotifyPropertyChanged(nameof(PropIsEnabled)); }
        }

        #endregion
    }
}