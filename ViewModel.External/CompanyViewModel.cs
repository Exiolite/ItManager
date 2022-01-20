using ItManager.Model;

namespace ItManager.ViewModel
{
    public class CompanyViewModel : ViewModel
    {
        public CompanyViewModel()
        {
            Company = new Company();
            App.DataContext.Data.CompaniesCollection.Add(Company);
            Company.Id = App.DataContext.Data.CompaniesCollection.IndexOf(Company);
            ComputersViewModel = new ComputersViewModel(Company.Id);
        }

        public CompanyViewModel(Company company)
        {
            Company = company;
            ComputersViewModel = new ComputersViewModel(Company.Id);
        }



        #region CompanyProperty
        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(Company)); }
        } 
        #endregion

        #region ComputersViewModelProperty
        private ComputersViewModel _computersViewModel;

        public ComputersViewModel ComputersViewModel
        {
            get { return _computersViewModel; }
            set { _computersViewModel = value; NotifyPropertyChanged(nameof(ComputersViewModel)); }
        } 
        #endregion
    }
}
