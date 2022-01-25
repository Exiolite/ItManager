namespace ViewModels.External
{
    public class RemoteViewModel : ViewModel
    {
        #region PropAnyDeskViewModel
        private AnyDeskViewModel _remoteViewModelCollection;

        public AnyDeskViewModel PropAnyDeskViewModel
        {
            get { return _remoteViewModelCollection; }
            set { _remoteViewModelCollection = value; NotifyPropertyChanged(nameof(PropAnyDeskViewModel)); }
        }

        #endregion

        #region PropComputerViewModel
        private ComputerViewModel _computerViewModel;

        public ComputerViewModel PropComputerViewModel
        {
            get { return _computerViewModel; }
            set { _computerViewModel = value; NotifyPropertyChanged(nameof(PropComputerViewModel)); }
        }

        #endregion

        public RemoteViewModel()
        {
            
        }

        public RemoteViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            PropAnyDeskViewModel = new AnyDeskViewModel(computerViewModel);
        }
    }
}
