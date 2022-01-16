using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class AllComputersViewModel : INotifyPropertyChanged
    {
        #region CTOR
        public AllComputersViewModel() { }
        public AllComputersViewModel(CompaniesListViewModel companiesListViewModel)
        {
            ComputerViewModels = new ObservableCollection<Tuple<string, ComputerViewModel>>();

            foreach (var companyViewModel in companiesListViewModel.CompanyViewModels)
            {
                foreach (var computerViewModel in companyViewModel.DevicesViewModel.ComputersListViewModel.ComputerViewModels)
                {
                    ComputerViewModels.Add(new Tuple<string, ComputerViewModel>(companyViewModel.Company.Name, computerViewModel));
                }
            }
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region CompaniesProperty
        private ObservableCollection<Tuple<string, ComputerViewModel>> _computerViewModels;
        public ObservableCollection<Tuple<string, ComputerViewModel>> ComputerViewModels
        {
            get { return _computerViewModels; }
            set { _computerViewModels = value; NotifyPropertyChanged(nameof(ComputerViewModels)); }
        }
        #endregion
    }
}
