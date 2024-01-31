﻿using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using toastr.Net.OptionEnums;
using toastr.Net;
using static DataModels.CapExTSDBStoredProcedures;
using System.Threading;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Net;
using LinqToDB;
using static LinqToDB.Common.Configuration;
using static Azure.Core.HttpHeader;
using static LinqToDB.Reflection.Methods.LinqToDB;
using System.Reflection.Emit;

namespace CapExTSVS.Controllers
{
    public class Administrator : Controller
    {
        /// <summary>
        /// Use Controler Controls
        /// </summary>
        /// 


        /// <summary>
        /// vendor Master
        /// </summary>
        /// 
        #region"Vendor Master Module"
        public IActionResult VendorMapping()
        {

            ViewBag.flag = flag;
            ViewData["GridData"] = bindgrdVendordata();







            return View();
        }

        public IActionResult VendorMappingData(VendorMastercustom vendorMastercustom)
        {

            if (flag == 0)
            {

                string ID = "";
                if (vendorMastercustom.Id != null)
                {

                    var output = UspCapexSelVendorMaster(vendorMastercustom, ID);
                    ViewBag.Message2 = Notification.PopupSave();
                    ViewData["GridData"] = bindgrdVendordata();

                }

            }
            else if (flag == 1)
            {
                string ID = "";
                if (vendorMastercustom.Id != null)
                {
                    ID = vendorMastercustom.Id.ToString();

                    var output = UspCapexSelVendorMaster(vendorMastercustom, ID);
                    ViewBag.Message2 = Notification.PopupUpdate();
                    ViewData["GridData"] = bindgrdVendordata();

                    flag = 0;
                }


            }
            return View("VendorMapping");
        }


        #endregion"Vendor Master Module"

        /// <summary>
        /// End vendor Master
        /// </summary>
        /// 

        /// <summary>
        /// User Rights
        /// </summary>
        ///

        #region"user Rights"


        public IActionResult UserRights()
        {
           CapexSelUserRightsResult da= new CapexSelUserRightsResult();
          
            ViewData["UserRightGrid"] = da as IQueryable<CapexSelUserRightsResult>;
            UserRightsBind();
            return View();
        }

        public IActionResult UserRightsSearch(string Data)
        {
            UserRightsBind();
            
            var data =_dbcontext.CapexSelEmployeeMaster(Data).SingleOrDefault();
            if(data !=null)
            {
                userRights UserRights = new userRights();
                //userRights.Rights
                //userRights.id = data.PersonalID;
                UserRights.Username = data.EmployeeName;
                UserRights.UserCode = data.PersonalID;



                //_dbcontext.CapexSaveUserRight
                fillgrid(UserRights);
                View("UserRights", UserRights);

                //     lblMSG.Text = uf.saveuserright(lblEmpCode.Text.Trim(), ddlRights.SelectedValue.ToString(), Session["usr"].ToString());
                //fillgrid();
            }
            else
            {
                ViewBag.Message2= Notification.PopupNotFound("Employee Not Found");
            }

           
            return View("UserRights");
        }



        public IActionResult UserRightsSave(userRights Data)
        {
            UserRightsBind();


            var da = _dbcontext.CapexSaveUserRight(Data.UserCode, Data.Rights,user.id.ToString());
            ViewBag.Message2 = Notification.PopupSave();
            fillgrid(Data);
            
            return View("UserRights", Data);
        }


        public IActionResult UserRightsDelete(String id)
        {

            var da1 = id.Split(',');
            var da = _dbcontext.CapexSelUserRights(da1[1], da1[0]).SingleOrDefault();
            var d=_dbcontext.CapexDelUserRight(da.EmployeeId,da.RightId,da.EmployeeName);
            UserRightsBind();

            ViewBag.Message2 = Notification.PopupSaveCustom("Data Delete SuccessFully");
            return View("UserRights");
        }

            private void fillgrid(userRights Data)
        {

            ViewData["UserRightGrid"] = _dbcontext.CapexSelUserRights(Data.UserCode, Data.Rights.ToString()).AsQueryable() ;
            //ViewData["UserRightGrid"] = _dbcontext.CapexSelEmployeeMaster(Data.UserCode).AsQueryable();
            
        }




        public void UserRightsBind()
        {

            
            ViewData["UserRights"]= _dbcontext.CapexSelRightsList().ToList();

        }





        #endregion


        /// <summary>
        /// End vendor Master
        /// </summary>
        /// 



        /// <summary>
        /// Company BU
        /// </summary>
        /// 
        #region"End Company/ BU"

        public IActionResult AddCompanyBu()
        {

            FillComaBUgrid();
            return View();
        }


        //public IActionResult AddCompanyBu(CapexComBUMasterCustom data)
        //{
        //    return View();
        //}
        public void FillComaBUgrid()
        {
            //flag = 0;
            ViewData["ComaBUgrid"] =  _dbcontext.UspCapexSelComBUMaster("", "", "").ToList();
           
        }


        
        public IActionResult FillBUEdit( string id)
        {
            flag = 1;
            CapexComBUMasterCustom bUMaster = new CapexComBUMasterCustom();
            //userRights.Rights
            //userRights.id = data.PersonalID;


            var a = _dbcontext.UspCapexSelComBUMaster("", "", "").Where(a => a.IndID == Convert.ToInt32(id)).SingleOrDefault();

            bUMaster.Des = a.Des;
            bUMaster.CompCode = a.CompCode;
            bUMaster.BU = a.BU;
            bUMaster.IndID = a.IndID;
            ViewData["ComaBUgrid"] = _dbcontext.UspCapexSelComBUMaster("", "", "").ToList();
            return View("AddCompanyBu", bUMaster);
        }


   


        public IActionResult AddCompanyBuSaved(CapexComBUMasterCustom data)
        {
            
            var da=_dbcontext.UspCapexSaveCompanyBu(data.IndID.ToString(), data.CompCode,data.Des, data.BU,data.Status.ToString());
            FillComaBUgrid();
            return View("AddCompanyBu");
        }


        #endregion"End Company/ BU"


        /// <summary>
        /// END Company BU
        /// </summary>
        /// 


        /// <summary>
        /// Capex Type Mapping
        /// </summary>
        /// 

        #region"Capex Type Mapping"


        public IActionResult CapexTypeMapping()
        {
            CapexbindddlCompany();
            CapexbindddlGrid();


            return View();
        }



        protected void CapexbindddlGrid()
        {
            ViewData["CapexbindddlGrid"]  = _dbcontext.UspCapexCapexTypeMapping("GET_CAPEXTYPE_BY_COMPANY_NAME", "", "", "", "", "", "", "", "").ToList();

            // _dbcontext.UspCapexCapexTypeMapping("", "com").ToList();

        }

        protected void CapexbindddlCompany()
        {

             ViewData["CapexbindddlCompany"]  = _dbcontext.CapexSelddl("", "com").ToList();
           
        }

     
        public IActionResult CapexEditCompany(string id)
        {
            CapexbindddlGrid();
            CapexbindddlCompany();
            UspCapexCapexTypeMappingResultComm data = new UspCapexCapexTypeMappingResultComm();

            var a = _dbcontext.UspCapexCapexTypeMapping("GET_CAPEXTYPE_BY_COMPANY_NAME", "", "", "", "", "", "", "", "").Where(a=>a.CTID== Convert.ToInt32( id)).SingleOrDefault();

            data.CTID = a.CTID;
            data.CapexType = a.CapexType;
            data.Comp_code = a.Comp_code;
            data.Des = a.Des;
            data.BU = a.BU;
            data.ReqType = a.ReqType;
            data.BudgetType = a.BudgetType;


            return View("CapexTypeMapping",data);
        }

  

        public IActionResult CapexSaveCompany(UspCapexCapexTypeMappingResultComm data)
        {
            CapexbindddlGrid();
            CapexbindddlCompany();

            var data1 = _dbcontext.UspCapexCapexTypeMapping("INSERT_UPDATE", data.CTID.ToString(), data.CapexType, data.Des,
                                                data.Comp_code.ToString(),data.BU,
                                               data.ReqType,data.BudgetType, user.id);
            ViewBag.Message2 = Notification.PopupSaveCustom("Data Create/Update Successfully");
            return View("CapexTypeMapping");
        }


        [HttpGet]
        public  IList<UspCapexSelComProjectResult> CapexBindddlProject(string id)
        {
           
           var dt = _dbcontext.UspCapexSelComProject(id).ToList();

           

            return dt.ToList();
        }


        #endregion"End Capex Type Mapping"




        /// <summary>
        /// End Capex Type Mapping
        /// </summary>
        /// 

        #region"Company Mapping"


        public IActionResult EmployeeCompanyMapping()
        {

            BindGridCompanyMapping();

            companymappingdropdown();
            return View();
        }
        
        public void companymappingdropdown()
        {
            ViewData["companymappingdropdown"] =_dbcontext.CapexSelddl("", "com").ToList();

            //return da;
        }

        public IActionResult SearchCompanyMapping(string data)
        {
            //BindGridCompanyMapping(data);

            return View("EmployeeCompanyMapping");
        }

        public IActionResult AddCompanyMapping(UspEmployeeCompanyMappingResultcomm data)
        {

           var da = _dbcontext.UspEmployeeCompanyMapping("INSERT_UPDATE", data.EmpCode, data.CompanyIds, user.id);
            BindGridCompanyMapping();
            return View("EmployeeCompanyMapping");
        }

         public void  BindGridCompanyMapping()
        {
            ViewData["BindGridCompanyMapping"] = "";
            companymappingdropdown();
            ViewData["BindGridCompanyMapping"]  = _dbcontext.UspEmployeeCompanyMapping("GET_MAPPING_BY_EMP_CODE", "", "", "").ToList();

        }




        #endregion"Company Mapping"


        /// <summary>
        /// Company Mapping
        /// </summary>
        /// 



        /// <summary>
        /// End Company Mapping
        /// </summary>
        /// 






        private readonly ILogger<Administrator> _logger;
        public CapExTSDB _dbcontext;
        public static int flag=0;
        public Administrator(ILogger<Administrator> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();

        }
   


     


      

         public IActionResult IndentMapping()
        {
            CapexbindddlCompany();

            ViewData["IndentMappingGrid"] = _dbcontext.CapexSelEmployeeMaster("").ToList();
            
            return View();
        }


        public IActionResult IndentSavingMapping(UspCapexSelIndentMappingRightsResultComm data)
        {
             //_dbcontext.UspCapexSelIndentMappingRights
                return View("IndentMapping");
        }

        public IActionResult IndentEditDataMapping(string id)
        {
            UspCapexSelIndentMappingRightsResultComm data = new UspCapexSelIndentMappingRightsResultComm();
            var da= _dbcontext.UspCapexSelIndentMappingRights("GET_INDENT_MAPPING_BY_EMPID_COMCODE", "","", id, "", "", "").SingleOrDefault();


            _dbcontext.CapexSelUserRights("","");
           
        //    data.IndID = da.IndID;
        //data.Comp_code= da.Comp_code
        //data.BU = da.BU 
        //data.EMPCode = da.EMPCode 
        //data.EmpName = da.EmpName 
        //data.RM_Lvl = da.RM_Lvl 
        //data.Approver1 = da.Approver1 
        //data.BU_Lvl = da.BU_Lvl 
        //data.Approver2 = da.Approver2 

            return View("IndentEditDataMapping");
        }



         public IActionResult NfaMapping()
        {
            NFAMappingGrid1();
            return View();
        }


        public void NFAMappingGrid1()
        {

           
           
            ViewData["NFAMappingGrid1"]  = _dbcontext.UspCapexCapexTypeMapping("GET_CAPEXTYPE_BY_COMPANY_NAME", "", "", "", "", "","","", "").ToList();


        }


        public IActionResult NFAMappingEditSetect(string Id )
        {
            NFAMappingGrid1();

            ViewData["UspCapexPayApprovalCatEmpMapping"] = _dbcontext.UspCapexPayApprovalCatEmpMapping("GET_CAPEXPAY_APPROVAL_BY_CAPEXID", Id, "", "", "", "", "", "", "", "", "", "", "", "", true, "").ToList();
           
            return View("NfaMapping");
        }


        public IActionResult NFAMappingEditSetect3(string Id)
        {

            NFAMappingGrid1();
            ViewData["UspCapexPayApprovalCatEmpMapping"] = _dbcontext.UspCapexPayApprovalCatEmpMapping("GET_CAPEXPAY_APPROVAL_BY_CAPEXID", Id, "", "", "", "", "", "", "", "", "", "", "", "", true, "").ToList();


            ViewData["UspCapexPayApprovalCatEmpMapping3"] = _dbcontext.UspCapexPayApprovalCatEmpMapping_2("GET_CAPEXPAY_APPROVAL_EMP_MAPPING_BY_CAPEXID", Id, "", "", "", "", "", "", "", "", "", "", "", "", true, "").ToList();


           // ID CapexID EMPCode App_1   App_2 App_3   App_4 App_5   App_6

            return View("NfaMapping");

        }





            public IActionResult Edit(int id)
        {
            flag = 1;
            ViewData["GridData"] = bindgrdVendordata();
            VendorMastercustom model = new VendorMastercustom();
           var model12 = bindgrdVendordata().Where(a => a.Id == id).SingleOrDefault();

            var model1= _dbcontext.UspCapexSelVendorDtl(model12.Vendor_Code).SingleOrDefault();


            bindddlCompany();


            model.Id = model1.Id;
            model.VendorCode = model1.VendorCode;
            model.CompanyCode = model1.CompanyCode;
            model.FirmName = model1.FirmName;
            model.FirmContactNumber = model1.FirmContactNumber;
            model.FirmEmailAddress = model1.FirmEmailAddress;
            model.Address = model1.Address;
            model.City = model1.City;
            model.District = model1.District;
            model.State = model1.State;
            model.PinCode = model1.PinCode;
            model.ContactPersonName = model1.ContactPersonName;
            model.ContactPersonContactNumber = model1.ContactPersonContactNumber;
            model.ContactPersonEmailAddress = model1.ContactPersonEmailAddress;
            model.Gst = model1.Gst;
            model.Remarks = model1.Remarks;
            model.Status = model1.Status;
            model.CreateDate = model1.CreateDate;
            model.CreatedBy = model1.CreatedBy;
            model.UpdatedBy = model1.UpdatedBy;
            model.UpdatedDate = model.UpdatedDate;

            return View("VendorMapping", model);
        }   



        public IActionResult CapexmainRequest()
        {
            return View();
        }

        public IActionResult CapexApproval()
        {

            return View();
        }





        /// <summary>
        /// Use End Controler Controls
        /// </summary>




        /// <summary>
        /// Create Custom Function Dropdown Data
        /// </summary>


        protected void bindddlCompany()
        {


            var dt = _dbcontext.CapexSelddl("", "com");
            ViewData["com"] = dt.ToList();




        }


        protected IList<UspCapexSelVendorMasterResult> bindgrdVendordata()
        {
            bindddlCompany();
            var dt = _dbcontext.UspCapexSelVendorMaster("GET_VENDOR_MASTER", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "").ToList();

            return dt;
          
        }




        protected dynamic UspCapexSelVendorMaster(VendorMastercustom vendorMastercustom,string ID)
        {
                    var output = _dbcontext.UspCapexSelVendorMaster("INSERT_UPDATE_VENDOR_MASTER", ID, vendorMastercustom.CompanyCode, vendorMastercustom.VendorCode, vendorMastercustom.FirmName,
                                   vendorMastercustom.ContactPersonContactNumber, vendorMastercustom.Address, vendorMastercustom.FirmEmailAddress, vendorMastercustom.City, vendorMastercustom.District, vendorMastercustom.State,
                                   vendorMastercustom.PinCode, vendorMastercustom.ContactPersonName, vendorMastercustom.ContactPersonContactNumber, vendorMastercustom.ContactPersonEmailAddress, vendorMastercustom.Gst,
                                    vendorMastercustom.Remarks, user.id.ToString());//Session["usr"].ToString());
            return output;

        }



        public IActionResult EmployeeRegistration()
        {


            EmployeeRegistrationGridLoad();


            return View();
        }


        public void EmployeeRegistrationGridLoad()
        {
            ViewData["EmployeeRegistrationGrid"] = _dbcontext.UserCreateEmployee_Stor(

                 "SELECTFull", "@EmployeeName",
                 "@EmployeeSubgroup",
                 "@EmployeeStatus",
                 "@Department",
                 "@EmailId",
                 "@contactno",
                 "@VERTICAL",
                 "@HODD",
                 "@REPOR",
                 "@PersonalID",
                 "@id"

                  ).ToList();
        }


            


        public IActionResult EmployeeRegistrationEdit(string id)
        {
            var da=id.Split(",");
            

            if (da[1]=="Edit")
            {
                EmployeeRegistration data = new EmployeeRegistration();
                var fet = _dbcontext.UserCreateEmployee_Stor(

                 "SELECT", "@EmployeeName",
                   "@EmployeeSubgroup",
                   "@EmployeeStatus",
                   "@Department",
                   "@EmailId",
                   "@contactno",
                   "@VERTICAL",
                   "@HODD",
                   "@REPOR",
                   "@PersonalID",
                   da[0].ToString()

                  ).SingleOrDefault();





                data.PersonalID = fet.PersonalID;
                data.EmployeeName = fet.EmployeeName;
                data.EmployeeSubgroup = fet.EmployeeSubgroup;
                data.EmailId = fet.EmailId;
                data.EmployeeStatus = fet.EmployeeStatus;
                data.Department = fet.Department;
                data.contactno = fet.contactno;
                data.VERTICAL = fet.VERTICAL;
                data.HODD = fet.HODD;
                data.REPOR = fet.REPOR;


                data.ID = fet.ID;







        EmployeeRegistrationGridLoad();
                return View("EmployeeRegistration", data);

            }

            if (da[1] == "DEL")
            {
               


                var fet = _dbcontext.UserCreateEmployee_Stor(

                 "DELETE", "@EmployeeName",
               "@EmployeeSubgroup",
               "@EmployeeStatus",
               "@Department",
               "@EmailId",
               "@contactno",
               "@VERTICAL",
               "@HODD",
               "@REPOR",
               "@PersonalID",
               da[0].ToString()

                  ).ToList();




                ViewBag.Message2 = Notification.PopupSaveCustom("Data Delete SuccessFully");
                EmployeeRegistrationGridLoad();
                return View("EmployeeRegistration");


            }

            EmployeeRegistrationGridLoad();
            return View("EmployeeRegistration");
                

        }



        
            public IActionResult EmployeeRegistrationSave(EmployeeRegistration data)
        {

            try
            {


                var dat= data.ID == null? ViewBag.flag = 0: ViewBag.flag = 1;

                if (ViewBag.flag==0)
                {

               

                 var sa=_dbcontext.UserCreateEmployee_Stor(

                        "INSERT",
                          data.EmployeeName,
          data.EmployeeSubgroup,
          data.EmployeeStatus,
          data.Department,
          data.EmailId,
          data.contactno,
          data.PersonalID,
          data.PersonalID,
          data.PersonalID,
          data.PersonalID,
          ""

                );

                    ViewBag.Message2 =Notification.PopupSave();
                }

                if (ViewBag.flag == 1)
                {



                    var sa = _dbcontext.UserCreateEmployee_Stor(

                 "UPDATE",

              data.EmployeeName,
              data.EmployeeSubgroup,
              data.EmployeeStatus,
              data.Department,
              data.EmailId,
              data.contactno,
              data.VERTICAL,
              data.PersonalID,
              data.PersonalID,
              data.PersonalID,
              data.ID.ToString()
               );

                    ViewBag.Message2 =Notification.PopupUpdate();



                }
                EmployeeRegistrationGridLoad();
                return View("EmployeeRegistration");

            }
            catch (Exception ex)
            {
                ViewBag.Message2 =Notification.PopupError();

                EmployeeRegistrationGridLoad();
                return View("EmployeeRegistration");
            }



           
        }








        public IActionResult UserCreate()
        {



            UserCreateGrid();
            UserCreateDrop();
            return View();
        }

        public void UserCreateDrop()
        {
            ViewData["UserCreateDropdown"] = _dbcontext.UserCreateEmployee_Stor(

                "SELECTFull", "@EmployeeName",
   "@EmployeeSubgroup",
   "@EmployeeStatus",
   "@Department",
   "@EmailId",
   "@contactno",
   "@VERTICAL",
   "@HODD",
   "@REPOR",
   "@PersonalID",
   "@id"

                 ).ToList();
        }


        public void UserCreateGrid()
        {

            ViewData["UserCreateGrid"]  = _dbcontext.UserCreate_Stor("", "", "", "UserCreateMasterGetFull").ToList();





        }
        public IActionResult UserCreateEdit(UserMasterTempComm data )
        {
           var da= _dbcontext.UserCreate_Stor(data.EmpCode, data.Password, data.IsActive, "UserCreate_Update").ToList();

            ViewBag.Message2 = Notification.PopupUpdate();
            UserCreateGrid();
            UserCreateDrop();
            return View("UserCreate");
        }




    }
}
