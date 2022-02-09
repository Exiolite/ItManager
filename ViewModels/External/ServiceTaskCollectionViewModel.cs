using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceTaskCollectionViewModel : ViewModel
    {
        #region CMDAdd
        private ICommand _add;
        public ICommand CMDAdd
        {
            get
            {
                if (_add == null) _add = new Command(this.AddE, this.CAdd, false);
                return _add;
            }
        }
        private void AddE(object obj)
        {
            var serviceTask = Add(PropComputerViewModel);
            PropServiceTaskViewModels.Add(new ServiceTaskViewModel(serviceTask));
        }
        private bool CAdd(object arg) => true;
        #endregion

        #region PropServiceTaskViewModels
        private ObservableCollection<ServiceTaskViewModel> _serviceTaskViewModels;

        public ObservableCollection<ServiceTaskViewModel> PropServiceTaskViewModels
        {
            get { return _serviceTaskViewModels; }
            set { _serviceTaskViewModels = value; NotifyPropertyChanged(nameof(PropServiceTaskViewModels)); }
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


        public ServiceTaskCollectionViewModel()
        {

        }


        public ServiceTaskCollectionViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            
            Initialize();
        }

        private void Initialize()
        {
            PropServiceTaskViewModels = new ObservableCollection<ServiceTaskViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropServiceTaskCollection.Where(s => s.PropTargetId == _computerViewModel.PropComputer.PropId))
            {
                PropServiceTaskViewModels.Add(new ServiceTaskViewModel(item));
            }
        }

        public ServiceTask Add(ComputerViewModel computerViewModel)
        {
            var item = new ServiceTask();

            MainViewModel.Instance.ExternalDataContext.PropServiceTaskCollection.Add(item);

            item.PropId = MainViewModel.Instance.ExternalDataContext.PropServiceTaskCollection.IndexOf(item);
            item.PropTargetId = computerViewModel.PropComputer.PropId;

            return item;
        }

        public ServiceTask Add(ServiceTask serviceTask)
        {
            MainViewModel.Instance.ExternalDataContext.PropServiceTaskCollection.Add(serviceTask);

            serviceTask.PropId = MainViewModel.Instance.ExternalDataContext.PropServiceTaskCollection.IndexOf(serviceTask);
            serviceTask.PropTargetId = PropComputerViewModel.PropComputer.PropId;

            return serviceTask;
        }

        #region TOREMOVE
        private ICommand _setComputerServiceTemplateCommand;
        public ICommand SetComputerServiceTemplateCommand
        {
            get
            {
                if (_setComputerServiceTemplateCommand == null)
                    _setComputerServiceTemplateCommand = new Command(this.SetComputerServiceTemplateExecute, this.CanSetComputerServiceTemplate, false);
                return _setComputerServiceTemplateCommand;
            }
        }
        private void SetComputerServiceTemplateExecute(object obj)
        {
            Add(new ServiceTask() { PropName = "Disk Cleanup" });
            Add(new ServiceTask() { PropName = "Standalone Backup" });
            Add(new ServiceTask() { PropName = "Disk S.M.A.R.T. Check" });
            Add(new ServiceTask() { PropName = "Virus Scan" });
            Add(new ServiceTask() { PropName = "Windows Update" });
            Add(new ServiceTask() { PropName = "Move Backup To RO" });

            Initialize();
        }
        private bool CanSetComputerServiceTemplate(object arg) => true;


        private ICommand _setDomainServerServiceTemplateCommand;
        public ICommand SetDomainServerServiceTemplateCommand
        {
            get
            {
                if (_setDomainServerServiceTemplateCommand == null)
                    _setDomainServerServiceTemplateCommand = new Command(this.SetDomainServerServiceTemplateExecute, this.CanDomainSetServerServiceTemplate, false);
                return _setDomainServerServiceTemplateCommand;
            }
        }
        private void SetDomainServerServiceTemplateExecute(object obj)
        {
            Add(new ServiceTask() { PropName = "Checkpoint" });
            Add(new ServiceTask() { PropName = "Windows Update" });
            Add(new ServiceTask() { PropName = "Virus Scan" });
            Add(new ServiceTask() { PropName = "Check Domain" });

            Initialize();
        }
        private bool CanDomainSetServerServiceTemplate(object arg) => true;


        private ICommand _setHyperVServerServiceTemplateCommand;
        public ICommand SetHyperVServerServiceTemplateCommand
        {
            get
            {
                if (_setHyperVServerServiceTemplateCommand == null)
                    _setHyperVServerServiceTemplateCommand = new Command(this.SetHyperVServerServiceTemplateExecute, this.CanSetHyperVServerServiceTemplate, false);
                return _setHyperVServerServiceTemplateCommand;
            }
        }
        private void SetHyperVServerServiceTemplateExecute(object obj)
        {
            Add(new ServiceTask() { PropName = "WindowsUpdate" });
            Add(new ServiceTask() { PropName = "Virus Scan" });
            Add(new ServiceTask() { PropName = "Raid Health" });

            Initialize();
        }
        private bool CanSetHyperVServerServiceTemplate(object arg) => true;
        #endregion
    }
}
