namespace Models
{
    public class Consts
    {
        #region Models.External
        public const string CompanyName = "Новая Компания";
        public const string Description = "Описание";
        public const string DomainName = "domain";
        public const string ComputerName = "PC";
        public const string ServerName = "Новый Сервер";
        public const string StaffSureName = "Фамилия";
        public const string StaffFirstName = "Имя";
        public const string StaffSecondName = "Отчество";
        #endregion

        #region View.Localization
        public string File { get => "Файл"; }
        public string FileNew{ get => "Новый"; }
        public string FileOpen{ get => "Открыть"; }
        public string FileOpenAs{ get => "Открыть как"; }
        public string FileSave{ get => "Сохранить"; }
        public string FileSaveAs{ get => "Сохранить как"; }

        public string StructureCompanies { get => "Компания"; }
        public string StructureDevices { get => "Устройства"; }
        public string StructureDevicesComputers { get => "Компьютеры"; }
        public string StructureDevicesServers { get => "Серверы"; }
        public string StructureDevicesPrinters { get => "Принтеры"; }
        public string StructureDevicesWLAN { get => "WLAN"; }
        public string StructureStuff { get => "Сотрудники"; }

        public string ContextMenuOpenAsNewWindow { get => "Открыть в новом окне"; }
        public string ContextMenuAdd { get => "Добавить"; }

        public string CompanyDomain { get => "Домен"; }
        public string CompanyDomainName { get => "Доменное имя: "; }

        #endregion
    }
}
