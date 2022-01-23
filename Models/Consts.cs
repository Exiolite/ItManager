namespace Models
{
    public class Consts
    {
        #region Models.External
        public const string CompanyName = "New Company";
        public const string CompanyDescription = "Description"; // TODO: To merge
        public const string DomainName = "domain";
        public const string ComputerName = "PC";
        public const string ServerName = "New Server";
        public const string ComputerDescription = "Description"; // with this
        public const string StaffFirstName = "FirstName";
        public const string StaffSecondName = "SecondName";
        public const string StaffSureName = "SureName";
        #endregion

        #region View.Localization
        public string File { get => "File"; }
        public string FileDialog { get => "Dialog"; }
        public string FileNew{ get => "New"; }
        public string FileOpen{ get => "Open"; }
        public string FileOpenAs{ get => "Open As"; }
        public string FileSave{ get => "Save"; }
        public string FileSaveAs{ get => "Save As"; }

        public string StructureCompanies { get => "Company"; }
        public string StructureDevices { get => "Devices"; }
        public string StructureDevicesComputers { get => "Computers"; }
        public string StructureDevicesServers { get => "Servers"; }
        public string StructureDevicesPrinters { get => "Printers"; }
        public string StructureDevicesWLAN { get => "WLAN"; }
        public string StructureStuff { get => "Stuff"; }

        public string ContextMenuOpenAsNewWindow { get => "Open in new window"; }
        public string ContextMenuAddCompany { get => "Add Company"; }
        public string ContextMenuAddComputer { get => "Add Computer"; }
        public string ContextMenuAddServer { get => "Add Server"; }
        public string ContextMenuAddPrinter { get => "Add Printer"; }
        public string ContextMenuAddWLAN { get => "Add WLAN"; }
        public string ContextMenuAddStuff { get => "Add Stuff"; }

        public string CompanyDomain { get => "Domain"; }
        public string CompanyDomainName { get => "Name: "; }

        #endregion
    }
}
