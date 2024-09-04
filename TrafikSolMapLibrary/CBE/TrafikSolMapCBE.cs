using System.Collections.ObjectModel;

namespace TrafikSolMapLibrary.CBE
{
    public class TrafikSolMapCBE
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int TrafikID { get; set; }
        public int PositionID { get; set; }
        public int VID { get; set; }
        public int ProjectID { get; set; }
        public double Position { get; set; }
        public int PointType { get; set; }
        public bool Alive { get; set; }
        public int SystemID { get; set; }
        public string? Details { get; set; }
        public string? Location { get; set; }
        public string? IPAddress { get; set; }
        public int SubSysID { get; set; }
        public int TSubSystemMID { get; set; }
        public int VendorID { get; set; }
        public string? VendorDesc { get; set; }
        public string? Vendor { get; set; }
        public string? Address { get; set; }
        public string? Model { get; set; }
        public string? VendorModel { get; set; }
        public string? SerialNo { get; set; }
        public bool Verified { get; set; }
        public string? ShortDetails { get; set; }
        public int ProjectTypeID { get; set; }
        public string? ProjectTypeName { get; set; }
        public string? ProjectName { get; set; }
        public string? SubsystemName { get; set; }
        public string? SubsystemType { get; set; }
        public string? RecordInsertedBy { get; set; }
        public DateTime RecordInsertedDate { get; set; }
        public DateTime SubsystemInstallationDate { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public string? EmailID { get; set; }
        public string? ContactPerson { get; set; }
        public long ContactNo1 { get; set; }
        public long ContactNo2 { get; set; }
        public long LandlineNo { get; set; }
        public string? GstNo { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int Landmark { get; set; }
        public string? PermanentAddress { get; set; }
        public int PermanentPincode { get; set; }
        public string? BillingAddress { get; set; }
        public int BillingPincode { get; set; }
        public int SubSystemTypeID { get; set; }
        public string? SystemImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SrNo { get; set; }

        public ObservableCollection<TrafikSolMapCBE> TSubSystemMasterDetailsBECollection = null;

        public ObservableCollection<TrafikSolMapCBE> TPositionMasterCollection = null;

        public ObservableCollection<TrafikSolMapCBE> ProjectTypeCollection = null;

        public ObservableCollection<TrafikSolMapCBE> ProjectDetailsCollection = null;

        public ObservableCollection<TrafikSolMapCBE> SubsystemTypeCollection = null;

        public ObservableCollection<TrafikSolMapCBE> SubsystemDetailsCollection = null;

        public ObservableCollection<TrafikSolMapCBE> TSubsystemVendorCollection = null;

        public ObservableCollection<TrafikSolMapCBE> ProjectReportCollection = null;
    }
}
