using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServerTableViewModel : ViewModel
    {
        private int _companyId;


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
            PropertyServerTable.Add(new ServerViewModel(_companyId));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property PropertyServerTable
        private ObservableCollection<ServerViewModel> _serverTable;

        public ObservableCollection<ServerViewModel> PropertyServerTable
        {
            get { return _serverTable; }
            set { _serverTable = value; NotifyPropertyChanged(nameof(PropertyServerTable)); }
        }

        #endregion



        public ServerTableViewModel(int companyId)
        {
            _companyId = companyId;


            PropertyServerTable = new ObservableCollection<ServerViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.ServerTable.Content.Where(s => s.CompanyId == _companyId))
            {
                PropertyServerTable.Add(new ServerViewModel(item));
            }
        }
    }
}
