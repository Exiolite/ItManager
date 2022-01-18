namespace ItManager.Model
{
    public class Printer : Model
    {
        private string _name = "New Printer";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private string _ip = "0.0.0.0";
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; OnPropertyChanged("Ip"); }
        }
    }
}
