namespace ItManager.Model.External
{
    public class DataContext : Model
    {
        #region DataProperty
        private Data _data = new Data();

        public Data Data
        {
            get { return _data; }
            set { _data = value; }
        }
        #endregion
    }
}
