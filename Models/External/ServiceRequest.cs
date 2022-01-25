﻿namespace Models.External
{
    public sealed class ServiceRequest : Model
    {
        #region property CompanyId
        private int _companyId = -1;

        public int PropCompanyId
        {
            get { return _companyId; }
            set { _companyId = value; NotifyPropertyChanged(nameof(PropCompanyId)); PropertyIsEdited = true; }
        }

        #endregion

        #region property Name
        private string _name = Consts.Request;

        public string PropertyName
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(PropertyName)); PropertyIsEdited = true; }
        }

        #endregion

        #region property Description
        private string _description = "Description";

        public string PropertyDescription
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(PropertyDescription)); PropertyIsEdited = true; }
        }

        #endregion

        #region property IsStarted
        private bool _isStarted;

        public bool PropertyIsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; NotifyPropertyChanged(nameof(PropertyIsStarted)); PropertyIsEdited = true; }
        }

        #endregion

        #region property IsEnded
        private bool _isEnded;

        public bool PropertyIsEnded
        {
            get { return _isEnded; }
            set { _isEnded = value; NotifyPropertyChanged(nameof(PropertyIsEnded)); PropertyIsEdited = true; }
        }

        #endregion
    }
}
