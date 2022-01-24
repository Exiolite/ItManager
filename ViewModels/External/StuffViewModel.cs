using Models.External;

namespace ViewModels.External
{
    public sealed class StuffViewModel : ViewModel
    {
        #region property Stuff
        private Stuff _stuff;

        public Stuff PropertyStuff
        {
            get { return _stuff; }
            set { _stuff = value; NotifyPropertyChanged(nameof(PropertyStuff)); }
        }

        #endregion


        public StuffViewModel()
        {

        }


        public StuffViewModel(Stuff stuff)
        {
            PropertyStuff = stuff;
        }
    }
}
