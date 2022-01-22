namespace Models
{
    public class Consts
    {
        #region Models.External
        public const string CompanyName = "Компания";
        public const string CompanyDescription = "Описание"; // TODO: To merge
        public const string DomainName = "Доменное имя";
        public const string ComputerName = "Компьютер";
        public const string ServerName = "Сервер";
        public const string ComputerDescription = "Описание"; // with this
        public const string StaffFirstName = "Имя";
        public const string StaffSureName = "Фамилия";
        public const string StaffSecondName = "Отчество";
        #endregion

        #region View.Localization
        public string File { get => "Файл"; }
        public string FileNew{ get => "Новый"; }
        public string FileOpen{ get => "Открыть"; }
        public string FileSave{ get => "Сохранить"; }
        public string FileSaveAs{ get => "Сохранить как"; }

        public string StructureCompanies { get => "Компании"; }
        public string StructureDevices { get => "Устройства"; }
        public string StructureDevicesComputers { get => "Компьютеры"; }
        public string StructureDevicesServers { get => "Серверы"; }
        public string StructureDevicesPrinters { get => "Принтеры"; }
        public string StructureDevicesWLAN { get => "WLAN"; }
        public string StructureStuff { get => "Сотрудники"; }

        public string ContextMenuOpenAsNewWindow { get => "Открыть в новом окне"; }
        public string ContextMenuAddCompany { get => "Добавить Компанию"; }
        public string ContextMenuAddComputer { get => "Добавить Компьютер"; }
        public string ContextMenuAddServer { get => "Добавить Сервер"; }
        public string ContextMenuAddPrinter { get => "Добавить Принтер"; }
        public string ContextMenuAddWLAN { get => "Добавить WLAN"; }
        public string ContextMenuAddStuff { get => "Добавить Сотрудника"; }

        public string CompanyDomain { get => "Домен"; }
        public string CompanyDomainName { get => "Имя: "; }

        #endregion
    }
}
