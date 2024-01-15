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




    public   class EmployeeRegistration
    {
 public string step1_txt_name                  { get; set; }
 public string step1_txt_dob                   { get; set; }
 public string MeasurementSystem               { get; set; }
 public string step1_txt_father                { get; set; }
 public string step1_txt_mother                { get; set; }
 public string step1_txt_address               { get; set; }
 public string step1_text_postcode             { get; set; }
 public string step1_txt_hometel               { get; set; }
 public string step1_txt_mobilenumber          { get; set; }
 public string step_2_text_name                { get; set; }
 public string step_2_txt_relationship         { get; set; }
 public string step_2_txt_Postcode             { get; set; }
 public string step_2_address                  { get; set; }
 public string step_2_txt_tel                  { get; set; }
 public string step_2_txt_mobile               { get; set; }
 public string step_2_txt_personalnumber       { get; set; }
 public string step_3_txt_name                 { get; set; }
 public string step_3_txt_relationship         { get; set; }
 public string step_3_txt_tel                  { get; set; }
 public string step_3_txt_workmobile           { get; set; }
 public string step_3_txt_personalnumber       { get; set; }
 public string step_3_drop_medicalcondition    { get; set; }
 public string step_3_txt_medicalcondition     { get; set; }
 public string step_4_txt_bankname             { get; set; }
 public string step_4_txt_accountnumber        { get; set; }
 public string step_4_txt_ifsc_code            { get; set; }
 public string step_4_txt_branch_address       { get; set; }
 public  IFormFile step_5_file_photo               { get; set; }
 public IFormFile step_5_file_addhar              { get; set; }
 public IFormFile step_5_file_pancard             { get; set; }
 public IFormFile step_5_educationproof           { get; set; }
 public IFormFile step_5_file_experience_letter   { get; set; }
 public IFormFile step_5_file_nocletter           { get; set; }
    }


    public class NEmp_Detail
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Father_name { get; set; }
        public string Mother_Name { get; set; }
        public string Home_address { get; set; }
        public string Post_code { get; set; }
        public string Home_tel { get; set; }
        public string Mobile { get; set; }
        public string EName { get; set; }
        public string ERelationship { get; set; }
        public string EContact_address { get; set; }
        public string EPost_code { get; set; }
        public string EHome_tel { get; set; }
        public string EWorkMobile { get; set; }
        public string Personalmobile { get; set; }
        public string ETName { get; set; }
        public string ETRelationship { get; set; }
        public string ETHome_tel { get; set; }
        public string ETWorkMobile { get; set; }
        public string ETPersonalmobile { get; set; }
        public string Medicalcondition_drop { get; set; }
        public string Medicalcondition { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFsc_code { get; set; }
        public string Branch_address { get; set; }
        public int ID { get; set; }
    }



}
