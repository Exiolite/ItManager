using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceTaskTableViewModel : ViewModel
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


        public ServiceTaskTableViewModel()
        {

        }


        public ServiceTaskTableViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;

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
    }
}
