﻿using Models.External;
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
            var serviceTask = PropertyServiceTaskTable.Add(PropertyId);
            PropertyServiceTaskViewModels.Add(new ServiceTaskViewModel(serviceTask));
        }
        private bool CAdd(object arg) => true;
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
            foreach (var item in PropertyServiceTaskTable.PropContent.Where(s => s.PropTargetId == _id))
            {
                PropertyServiceTaskViewModels.Add(new ServiceTaskViewModel(item));
            }
        }
    }
}
