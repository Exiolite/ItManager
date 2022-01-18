using System.Collections.ObjectModel;

namespace ItManager.Model
{
    public class ItManagerData : Model
    {
        private ObservableCollection<Company> _companies = new();
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set { _companies = value; OnPropertyChanged(nameof(Companies)); }
        }
    }
}
