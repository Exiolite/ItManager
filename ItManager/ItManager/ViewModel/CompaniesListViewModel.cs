using ItManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class CompaniesListViewModel : ViewModel
    {
        public CompaniesListViewModel() { }
        public CompaniesListViewModel(ObservableCollection<Company> companies)
        {
            Companies = companies;
            CompanyViewModels = new ObservableCollection<CompanyViewModel>();
            foreach (var company in Companies)
            {
                CompanyViewModels.Add(new CompanyViewModel(company));
            }
        }



        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get => _companies;
            set { _companies = value; NotifyPropertyChanged(nameof(Companies)); }
        }

        private ObservableCollection<CompanyViewModel> _companyViewModels;
        public ObservableCollection<CompanyViewModel> CompanyViewModels
        {
            get => _companyViewModels;
            set { _companyViewModels = value; NotifyPropertyChanged(nameof(CompanyViewModels)); }
        }



        private ICommand _addNewCompanyCommand;
        public ICommand AddNewCompanyCommand =>
            _addNewCompanyCommand ??= new Command.Command(AddNewCompanyExecuted, CanAddNewCompany, false);

        private void AddNewCompanyExecuted(object obj)
        {
            var company = new Company();
            Companies.Add(company);
            CompanyViewModels.Add(new CompanyViewModel(company));
        }
        private bool CanAddNewCompany(object arg) => true;
    }
}
