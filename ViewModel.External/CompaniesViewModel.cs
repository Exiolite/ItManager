using ItManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class CompaniesViewModel : ViewModel
    {
        private ObservableCollection<CompanyViewModel> _companyViewModels = new ObservableCollection<CompanyViewModel>();

        public ObservableCollection<CompanyViewModel> CompanyViewModels
        {
            get 
            {
                _companyViewModels = new ObservableCollection<CompanyViewModel>();
                foreach (var company in App.DataContext.Data.CompaniesCollection)
                {
                    _companyViewModels.Add(new CompanyViewModel(company));
                }
                return _companyViewModels; 
            }
            set { _companyViewModels = value; NotifyPropertyChanged(nameof(CompanyViewModels)); }
        }
    }
}
