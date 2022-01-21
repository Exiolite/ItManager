namespace ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region Singleton
        public static MainViewModel Instance { get; set; }
        public MainViewModel()
        {
            Instance = this;
            ExternalDataContext.CompanyTable.AddNewCompany();
        }
        #endregion

        #region property InternalDataContext
        private Models.Internal.DataContext _dataContext = new Models.Internal.DataContext();

        public Models.Internal.DataContext InternalDataContext
        {
            get { return _dataContext; }
            set { _dataContext = value; NotifyPropertyChanged(nameof(InternalDataContext)); }
        }

        #endregion

        #region property ExternalDataContext
        private Models.External.DataContext _externalDataContext = new Models.External.DataContext();

        public Models.External.DataContext ExternalDataContext
        {
            get { return _externalDataContext; }
            set { _externalDataContext = value; NotifyPropertyChanged(nameof(ExternalDataContext)); }
        }

        #endregion
    }
}
