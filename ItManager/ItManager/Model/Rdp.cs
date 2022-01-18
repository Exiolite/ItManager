namespace ItManager.Model
{
    public class Rdp : Model
    {
        private string _pdrFilePath = "RdpFilePath";
        public string RdpFilePath
        {
            get { return _pdrFilePath; }
            set { _pdrFilePath = value; OnPropertyChanged(nameof(RdpFilePath)); }
        }
    }
}
