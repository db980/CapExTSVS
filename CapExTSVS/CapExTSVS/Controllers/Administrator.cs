using CapExTSVS.Models1;
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

            


        /// <summary>
        /// END Company BU
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
   


        public IActionResult CapexTypeMapping()
        {
            return View();
        }


        public IActionResult EmployeeCompanyMapping()
        {
            return View();
        }

         public IActionResult IndentMapping()
        {
            return View();
        }

        public IActionResult NfaMapping()
        {
            return View();
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


       

    }
}
