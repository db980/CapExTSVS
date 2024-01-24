using LinqToDB.Mapping;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

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



    public partial class NFAMappingEdit
    {
       public string  F_capexId { get; set; }
        public string F_capexType { get; set; }
        public string F_AccountF { get; set; }
        public string F_AccountTo { get; set; }
        public string F_Dep_1 { get; set; }
        public string F_Dep_2 { get; set; }
        public string F_Fin_1 { get; set; }
        public string F_Fin_2 { get; set; }
        public string F_Fin_3 { get; set; }
        public string F_Fin_4 { get; set; }
        public string F_Fin_5 { get; set; }
        public string F_Fin_6 { get; set; }
        public string F_Remark { get; set; }



        public string S_Id { get; set; }
        public string S_capexId { get; set; }
        public string s_capexType { get; set; }
        
        public string s_App_1 { get; set; }
        public string s_App_2 { get; set; }
        public string s_App_3 { get; set; }
        public string s_App_4 { get; set; }
        public string s_App_5 { get; set; }
        public string s_App_6 { get; set; }
        public string Status { get; set; }
        public string Form { get; set; }
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
        public string ID { get; set; }
        public string PersonalID { get; set; }
        public string step1_Empolyee_Code { get; set; }
  public  IFormFile step_5_file_photo               { get; set; }
 public IFormFile step_5_file_addhar              { get; set; }
 public IFormFile step_5_file_pancard             { get; set; }
 public IFormFile step_5_educationproof           { get; set; }
 public IFormFile step_5_file_experience_letter   { get; set; }
 public IFormFile step_5_file_nocletter           { get; set; }
    }


    public class NEmp_DetailComm
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



        public string step1_Empolyee_Code { get; set; }
        public int ID { get; set; }
    }



    public partial class UserMasterTempComm
    {
        [Column("empCode"), Nullable] public string? EmpCode { get; set; } // varchar(20)
        [Column("password"), Nullable] public string? Password { get; set; } // varchar(50)
        [Column("isActive"), Nullable] public string? IsActive { get; set; } // varchar(10)
    }




    public partial class CapexmainRequest
    {
        public string IndentId { get; set; }
        public string AssetsType { get; set; }
        public string Company { get; set; }
        public string BUI { get; set; }
        public string EXPType { get; set; }
        public string Budget { get; set; }
        public string NFA { get; set; }
        public string Purpose { get; set; }
        public string ExpectedDate { get; set; }


        public string Description { get; set; }

        public string Uom { get; set; }

        public string Qty { get; set; }

        public string TexRate { get; set; }


        public string Imported { get; set; }

        public string Justification { get; set; }
        public string Benefit { get; set; }

        public string IRRPaybackfile { get; set; }
        public string IRRPaybackValue { get; set; }

        public string cashoverFlowFile { get; set; }

        public string cashoverFlowValue { get; set; }




    }


    public  class CapexmainRequestItems
    {
        public string Description { get; set; }

        public string Uom { get; set; }

        public string Qty { get; set; }

        public string TexRate { get; set; }
        public string ID { get; set; }
    }


    //public class CapexItems<T>
    //{

    //}

       static class Items<T>
    {
         public static List<T> Items1 = null;

       public   static void InsertEmployeeList(T emp)
        {

            Items1.Add(emp);
        }


        static Items()
        {
            Items1 = new List<T>();
        }

    }

        public  class CapexItems<T> :IEmployeeRepository
    {
        

        //public static void InsertEmployeeList(T emp)
        //{
        //    Items1.Add(emp);
        //}

        //public static List<T> SelectEmployeeList1()
        //{
        //    return Items1;
        //}

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployee<T1>(T1 emp)
        {
            Items<T1>.InsertEmployeeList(emp);
        }

        public List<T1> SelectAllEmployees<T1>()
        {
            return Items<T1>.Items1;
        }

        public T1 SelectEmployeeById<T1>(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee<T1>(T1 emp)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeRepository
    {
        List<T> SelectAllEmployees<T>();
        T SelectEmployeeById<T>(int id);
        void InsertEmployee<T>(T emp);
        void UpdateEmployee<T>(T emp);
        void DeleteEmployee(int id);
    }

    public static class Vender<T>
    {
        public static List<T> Items1 = new List<T>();
    }
}
