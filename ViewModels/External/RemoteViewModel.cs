using Models.External;

namespace ViewModels.External
{
    public class RemoteViewModel : ViewModel
    {
        public Computer AttachedComputer { get; set; }

        #region PropAnyDeskViewModel
        private AnyDeskViewModel _remoteViewModelCollection;

        public AnyDeskViewModel PropAnyDeskViewModel
        {
            get { return _remoteViewModelCollection; }
            set { _remoteViewModelCollection = value; NotifyPropertyChanged(nameof(PropAnyDeskViewModel)); }
        }

        #endregion

        public RemoteViewModel()
        {
            
        }

        public RemoteViewModel(Computer computer)
        {
            AttachedComputer = computer;
            PropAnyDeskViewModel = new AnyDeskViewModel(computer);
        }
    }
}
