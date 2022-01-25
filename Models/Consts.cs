using System.Collections.ObjectModel;

namespace Models
{
    public class Consts
    {
        public static string ComputerTypePersonal { get => "Персональный"; }
        public static string ComputerTypeServer { get => "Сервер"; }
        public static string ComputerTypeVirtual { get => "Виртуальный"; }



        #region filename
        public static string InternalDataFileName = "InternalData.json";
        #endregion

        public string HInfo { get => "Информация"; }
        public string HRemote { get => "Удаленный Доступ"; }
        public string HServicePlan { get => "Сервисный План"; }
        public string HDomain { get => "Домен"; }

        #region Models.External
        public const string CompanyName = "Новая Компания";
        public const string Description = "Описание";
        public const string DomainName = "domain";
        public const string ComputerName = "PC";
        public const string ServerName = "Новый Сервер";
        public const string StaffSureName = "Фамилия";
        public const string StaffFirstName = "Имя";
        public const string StaffSecondName = "Отчество";
        public const string UserPhoneNumber= "+79990001122";
        #endregion

        #region View.Localization
        public string File { get => "Файл"; }
        public string FileNew{ get => "Новый"; }
        public string FileOpen{ get => "Открыть"; }
        public string FileOpenAs{ get => "Открыть как"; }
        public string FileSave{ get => "Сохранить"; }
        public string FileSaveAs{ get => "Сохранить как"; }
        public string FileSynchronizeWithServer{ get => "Синхронизировать"; }

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
