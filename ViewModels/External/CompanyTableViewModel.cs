﻿using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class CompanyTableViewModel : ViewModel
    {
        #region property
        private ObservableCollection<CompanyViewModel> _property;

        public ObservableCollection<CompanyViewModel> Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion


        public CompanyTableViewModel()
        {
            Property = new ObservableCollection<CompanyViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.CompanyTable.Content)
            {
                Property.Add(new CompanyViewModel(item));
            }
        }


        #region command AddNew
        private ICommand _commandAddNew;
        public ICommand CommandAddNew
        {
            get
            {
                if (_commandAddNew == null) _commandAddNew = new Command(this.AddNewE, this.CAddNew, false);
                return _commandAddNew;
            }
        }
        private void AddNewE(object obj)
        {
            Property.Add(new CompanyViewModel());
        }
        private bool CAddNew(object arg) => true;
        #endregion
    }
}
