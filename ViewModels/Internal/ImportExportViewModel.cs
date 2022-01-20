using System.Text.Json;
using System.IO;
using Addons.Model;
using Microsoft.Win32;
using System;

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

            public FileBuilder(DataContextViewModel dataContextViewModel)
            {
                _dataContextViewModel = dataContextViewModel;
            }

            public FileBuilder(string fileName)
            {
                _fileName = fileName;
            }

            public FileBuilder(string fileName, DataContextViewModel dataContextViewModel)
            {
                _dataContextViewModel = dataContextViewModel;
                _fileName = fileName;
            }



            private DataContextViewModel _dataContextViewModel;
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
                    File.WriteAllText(_fileName, JsonSerializer.Serialize(_dataContextViewModel));
                return this;
            }

            public DataContextViewModel ReadIfExistOrNew()
            {
                if (File.Exists(_fileName))
                {
                    var text = File.ReadAllText(_fileName);
                    return JsonSerializer.Deserialize<DataContextViewModel>(text);
                }
                return new DataContextViewModel();
            }
        }
        #endregion



        public static void Write(string fileName, DataContextViewModel dataContextViewModel)
        {
            new FileBuilder(fileName, dataContextViewModel).Write();
        }

        public static void WriteWithSaveDialog(DataContextViewModel dataContextViewModel)
        {
            new FileBuilder(dataContextViewModel).SaveDialog().Write();
        }

        public static DataContextViewModel Read(string fileName)
        {
            return new FileBuilder(fileName).ReadIfExistOrNew();
        }

        public static DataContextViewModel ReadWithOpenDialog()
        {
            return new FileBuilder().OpenDialog().ReadIfExistOrNew();
        }
    }
}
