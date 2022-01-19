using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using ItManager.Model.Internal;

namespace ItManager.ViewModel
{
    public class InternalDataViewModel : ViewModel
    {
        private const string Name = "InternalData.json";
        private static string FullName = "InternalData.json";


        public InternalDataViewModel()
        {
            FullName = $"{Environment.CurrentDirectory}\\{Name}";
            if (File.Exists(Name))
            {
                Load();
            }
            else
            {
                Save();
            }
        }

        public void Load()
        {
            InternalData = JsonSerializer.Deserialize<InternalData>(File.ReadAllText(FullName));
            MessageBox.Show(InternalData.Files.RecentOpenedFileNames[1]);
        }

        public void Save()
        {
            File.WriteAllText(FullName, JsonSerializer.Serialize(InternalData));
        }


        private InternalData _internalData = new InternalData();
        public InternalData InternalData
        {
            get => _internalData;
            set { _internalData = value; NotifyPropertyChanged(nameof(InternalData)); }
        }
    }
}
