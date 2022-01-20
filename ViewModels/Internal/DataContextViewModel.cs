using Addons.Model;
using Models.Internal;

namespace ViewModels.Internal
{
    public class DataContextViewModel : ViewModel
    {
        private DataContext _dataContext = new DataContext();
        public DataContext DataContext
        {
            get { return _dataContext; }
            set { _dataContext = value; }
        }
    }
}
