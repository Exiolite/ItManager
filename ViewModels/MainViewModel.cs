using Models;
using ViewModels.Internal;

namespace ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region Singleton
        public static MainViewModel Instance { get; set; }

        public Consts Consts { get; set; } = new Consts();

        public MainViewModel()
        {
            Instance = this;
            MainViewModel.Instance.InternalDataContext = MainViewModel.Instance.InternalDataContext.PropFileOperation.ReadInternalDataIfExist();
        }
        #endregion

        #region PropFileViewModel
        private FileViewModel _fileViewModel = new FileViewModel();

        public FileViewModel PropFileViewModel
        {
            get { return _fileViewModel; }
            set { _fileViewModel = value; NotifyPropertyChanged(nameof(PropFileViewModel)); }
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
