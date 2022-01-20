using System.Text.Json;
using System.IO;
using Microsoft.Win32;
using System;
using Models.Internal;

namespace ViewModels.Internal
{
    public class ImportExportViewModel : ViewModel
    {
        #region FileBuilderClass
        private class FileBuilder
        {
            public FileBuilder()
            {

            }

            public FileBuilder(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public FileBuilder(string fileName)
            {
                _fileName = fileName;
            }

            public FileBuilder(string fileName, DataContext dataContext)
            {
                _dataContext = dataContext;
                _fileName = fileName;
            }



            private DataContext _dataContext;
            private string _fileName;



            public FileBuilder SaveDialog()
            {
                var saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                    _fileName = saveFileDialog.FileName;

                return this;
            }

            public FileBuilder OpenDialog()
            {
                var dlg = new OpenFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                    _fileName = dlg.FileName;

                return this;
            }

            public FileBuilder Write()
            {
                if (!string.IsNullOrEmpty(_fileName))
                    File.WriteAllText(_fileName, JsonSerializer.Serialize(_dataContext));
                return this;
            }

            public DataContext ReadIfExistOrNew()
            {
                if (File.Exists(_fileName))
                {
                    var text = File.ReadAllText(_fileName);
                    return JsonSerializer.Deserialize<DataContext>(text);
                }
                return new DataContext();
            }
        }
        #endregion



        public static void Write(string fileName, DataContext dataContextViewModel)
        {
            new FileBuilder(fileName, dataContextViewModel).Write();
        }

        public static void WriteWithSaveDialog(DataContext dataContextViewModel)
        {
            new FileBuilder(dataContextViewModel).SaveDialog().Write();
        }

        public static DataContext Read(string fileName)
        {
            return new FileBuilder(fileName).ReadIfExistOrNew();
        }

        public static DataContext ReadWithOpenDialog()
        {
            return new FileBuilder().OpenDialog().ReadIfExistOrNew();
        }
    }
}
