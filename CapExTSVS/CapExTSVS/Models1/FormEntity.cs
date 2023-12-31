﻿using LinqToDB.Mapping;

namespace CapExTSVS.Models1
{

    public class IndentCreate
    {
        //public int IndentID { get; set; }
        //public string ? Company { get; set; }
        //public string ? BU { get; set; }
        //public string ?CapexType { get; set; }
        //public string? LocationWork { get; set; }
        //public string? TypeofWorkDetails { get; set; }

        //// Optional file paths
        //public string ?EnclosureBQQFile { get; set; }
        //public string? EnclosureDrawingFile { get; set; }

        //public decimal RateProposed { get; set; }
        //public string ?BudgetType { get; set; }

        //public DateTime? TentativeStartDate { get; set; }
        //public DateTime? TentativeCompletionDate { get; set; }

        //public string? ProposedContractorName { get; set; }
        //public string? VendorExistingLocation { get; set; }
        //public string? ContractorDetailsAddressGST { get; set; }

        //public int Userid { get; set; }
        //public string? Remarks { get; set; }
        //public string? TagPurchaser { get; set; }
        //public int Tat { get; set; } // Assuming Tat is an integer, adjust if needed





         public  string IndentID { get; set; }
        public  string Company { get; set; }
        public  string BU { get; set; }
        public  string LocatioWork { get; set; }
        public  string TypeofWorkDetails { get; set; }
        public  string EnclosureBQQFile { get; set; }
        public  string EnclosureDrawingFile { get; set; }
        public  decimal? RateProposed { get; set; }
        public  string BudgetType { get; set; }
        public DateTime  TentativeStartDate { get; set; }
        public DateTime  TentativeCompletionDate { get; set; }
        public  string ProposedContractorName { get; set; }
        public  string VendorExistingLocation { get; set; }
        public  string ContractorDetailsAddressGST { get; set; }
        public  string Userid { get; set; }
        public  string CapexType { get; set; }
        public  string Remarks { get; set; }
        public  string TagPurchaser { get; set; }
        public int? Tat { get; set; }


    }


    public partial class UspCapexSelVendorMasterResultCustom
    {
        public int Id { get; set; }
        public string? Vendor_Code { get; set; }
        public string? CompanyCode { get; set; }
        public string? Firm_Name { get; set; }
        public string ?Firm_Contact_Number { get; set; }
        public string ?Firm_Email_Address { get; set; }
        public string ?City { get; set; }
    }
    public class Logindata
    {
        public string EID { get; set; }
        public string Password { get; set; }

    }

    public class StatFlag
    {
        public string Flag { get; set; }
        
    }
    public static class user
    {
        public static string id { get; set; }
        public static string Name { get; set; }

    }


    public  class userRights
    {
        public  string id { get; set; }
        public  string Username { get; set; }
        public  string UserCode { get; set; }

        public  int Rights { get; set; }

    }




    public partial class VendorMastercustom
    {
        [Column(), Identity] public int Id { get; set; } // int
        [Column("Vendor_Code"), PrimaryKey, NotNull] public string VendorCode { get; set; } // varchar(20)
        [Column(), Nullable] public string CompanyCode { get; set; } // nvarchar(10)
        [Column("Firm_Name"), Nullable] public string FirmName { get; set; } // varchar(250)
        [Column("Firm_Contact_Number"), Nullable] public string FirmContactNumber { get; set; } // varchar(50)
        [Column("Firm_Email_Address"), Nullable] public string FirmEmailAddress { get; set; } // varchar(250)
        [Column(), Nullable] public string Address { get; set; } // varchar(500)
        [Column(), Nullable] public string City { get; set; } // varchar(250)
        [Column(), Nullable] public string District { get; set; } // varchar(150)
        [Column(), Nullable] public string State { get; set; } // varchar(150)
        [Column("Pin_Code"), Nullable] public string PinCode { get; set; } // varchar(10)
        [Column("Contact_Person_Name"), Nullable] public string ContactPersonName { get; set; } // varchar(250)
        [Column("Contact_Person_Contact_Number"), Nullable] public string ContactPersonContactNumber { get; set; } // varchar(50)
        [Column("Contact_Person_Email_Address"), Nullable] public string ContactPersonEmailAddress { get; set; } // varchar(250)
        [Column(), Nullable] public string Gst { get; set; } // varchar(200)
        [Column(), Nullable] public string Remarks { get; set; } // varchar(2000)
        [Column(), Nullable] public bool? Status { get; set; } // bit
        [Column("Create_Date"), Nullable] public DateTime? CreateDate { get; set; } // datetime
        [Column("Created_By"), Nullable] public string CreatedBy { get; set; } // varchar(20)
        [Column("Updated_By"), Nullable] public string UpdatedBy { get; set; } // varchar(20)
        [Column("Updated_Date"), Nullable] public DateTime? UpdatedDate { get; set; } // datetime
    }

    public partial class CapexComBUMasterCustom
    {
        [Column(), Identity] public int IndID { get; set; } // int
        [Column("Comp_code"), PrimaryKey(1), NotNull] public string CompCode { get; set; } // varchar(10)
        [Column(), Nullable] public string Des { get; set; } // varchar(100)
        [Column(), PrimaryKey(2), NotNull] public string BU { get; set; } // varchar(100)
        [Column(), Nullable] public bool? Status { get; set; } // bit
    }


    public partial class UspCapexCapexTypeMappingResultComm
    {
        public int CTID { get; set; }
        public string CapexType { get; set; }
        public string Comp_code { get; set; }
        public string Des { get; set; }
        public string BU { get; set; }
        public string ReqType { get; set; }
        public string BudgetType { get; set; }
    }


    public partial class UspEmployeeCompanyMappingResultcomm
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string CompanyIds { get; set; }
    }


    public partial class UspCapexSelIndentMappingRightsResultComm
    {
        public int IndID { get; set; }
        public string Comp_code { get; set; }
        public string BU { get; set; }
        public string EMPCode { get; set; }
        public string EmpName { get; set; }
        public string RM_Lvl { get; set; }
        public string Approver1 { get; set; }
        public string BU_Lvl { get; set; }
        public string Approver2 { get; set; }
    }
}
