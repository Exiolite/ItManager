using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceTaskTableViewModel : ViewModel
    {
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
            var serviceTask = PropertyServiceTaskTable.Add(PropertyId);
            PropertyServiceTaskViewModels.Add(new ServiceTaskViewModel(serviceTask));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property ServiceTaskViewModels
        private ObservableCollection<ServiceTaskViewModel> _serviceTaskViewModels;

        public ObservableCollection<ServiceTaskViewModel> PropertyServiceTaskViewModels
        {
            get { return _serviceTaskViewModels; }
            set { _serviceTaskViewModels = value; NotifyPropertyChanged(nameof(PropertyServiceTaskViewModels)); }
        }

        #endregion

        #region property ServiceTaskTable
        private ServiceTaskTable _content;

        public ServiceTaskTable PropertyServiceTaskTable
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropertyServiceTaskTable)); }
        }

        #endregion

        #region property Id
        private int _id;

        public int PropertyId
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(nameof(PropertyId)); }
        }

        #endregion


        public ServiceTaskTableViewModel()
        {

        }


        public ServiceTaskTableViewModel(ServiceTaskTable taskTable, int id)
        {
            PropertyServiceTaskTable = taskTable;
            PropertyId = id;

            PropertyServiceTaskViewModels = new ObservableCollection<ServiceTaskViewModel>();
            foreach (var item in PropertyServiceTaskTable.Content.Where(s => s.PropertyTargetId == _id))
            {
                PropertyServiceTaskViewModels.Add(new ServiceTaskViewModel(item));
            }
        }
    }
}
