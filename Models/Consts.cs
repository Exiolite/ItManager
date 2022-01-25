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

        public static string HInfo { get => "Информация"; }
        public static string HRemote { get => "Удаленный Доступ"; }
        public static string HServicePlan { get => "Сервисный План"; }
        public static string HDomain { get => "Домен"; }

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
        public static string File { get => "Файл"; }
        public static string FileNew { get => "Новый"; }
        public static string FileOpen { get => "Открыть"; }
        public static string FileOpenAs { get => "Открыть как"; }
        public static string FileSave { get => "Сохранить"; }
        public static string FileSaveAs { get => "Сохранить как"; }
        public static string FileSynchronizeWithServer { get => "Синхронизировать"; }

        public static string StructureCompanies { get => "Компания"; }
        public static string StructureDevices { get => "Устройства"; }
        public static string StructureDevicesComputers { get => "Компьютеры"; }
        public static string StructureDevicesServers { get => "Серверы"; }
        public static string StructureDevicesPrinters { get => "Принтеры"; }
        public static string StructureDevicesWLAN { get => "WLAN"; }
        public static string StructureStuff { get => "Сотрудники"; }

        public static string ContextMenuOpenAsNewWindow { get => "Открыть в новом окне"; }
        public static string ContextMenuAdd { get => "Добавить"; }

        public static string CompanyDomain { get => "Домен"; }
        public static string CompanyDomainName { get => "Доменное имя: "; }
        public static string Request { get => "Запрос"; }

        #endregion
    }
}
