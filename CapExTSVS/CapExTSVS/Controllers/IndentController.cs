using CapExTSVS.Models;
using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static DataModels.CapExTSDBStoredProcedures;
using static LinqToDB.Common.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CapExTSVS.Controllers
{
    public class IndentController : Controller
    {
        private readonly ILogger<IndentController> _logger;
        public CapExTSDB _dbcontext;

        public IndentController(ILogger<IndentController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();

        }

        public IActionResult ViewIndent()
        {
            HttpContext.Session.SetString("usr", "E00001376");
            //HttpContext.Session.GetString("usr");



            //var da = _DBContext.IndentMasters.Select(a => a).ToList();
            //var a = _dbcontext.CapexfChkUserRight(HttpContext.Session.GetString("usr").ToString(), "6").ToList();


            
            if (_dbcontext.CapexfChkUserRight(HttpContext.Session.GetString("usr").ToString(), "6").SingleOrDefault().Column1 == "True")
            {

                var data = _dbcontext.IndentSelApprovalHistory(HttpContext.Session.GetString("usr"), "10091", "17").ToList(); //txtCapexCode.Text.Trim(), ddlStatus.SelectedValue.ToString()
                ViewData["GridBind"] = data;
              

            }
            else
            {
                Response.Redirect("noentry.aspx");
            }

            return View();
        }


        [HttpGet]
        public IList<CapexSelddlResult>  validateUserAuth(string d)
        {
            //return View();
           var dt = _dbcontext.CapexSelddl(d, "bu");
            
            return dt.ToList();
        }


        private void fillddlbu()
        {
           // DataTable dt = _dbcontext.CapexSelddl(ddlcom.SelectedValue, "bu");
            //ddlbu.Items.Clear();
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    ddlbu.DataSource = dt;
            //    ddlbu.DataTextField = "Des";
            //    ddlbu.DataValueField = "Code";
            //    ddlbu.DataBind();
            //}
            //ddlbu.Items.Insert(0, new ListItem("Select", "0"));
            //ddlbu.SelectedValue = "0";
        }



        public  IActionResult IndDashboard()
        {
            return View();
        }

        public void LoadDropDown()
       {
           
            // com List
            var dt = _dbcontext.CapexSelddl("", "com");
            ViewData["com"]= dt.ToList();

            //Purchaser List
            var dtpurchaser = _dbcontext.CapexSelddl("", "SELECT_TAG_PURCHASER");
            ViewData["Purchaser"] = dtpurchaser.ToList();
        }


        public IActionResult IndentApproval()
        {
            HttpContext.Session.SetString("usr", "E00001376");

            var data = _dbcontext.IndentSelPendingforApproval(HttpContext.Session.GetString("usr")).ToList(); //txtCapexCode.Text.Trim(), ddlStatus.SelectedValue.ToString()
            ViewData["GridBindIndentApproval"] = data;

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult createIndent()
        {
            LoadDropDown();
            return View();
        }

        [HttpPost]
        public IActionResult createIndent(IndentCreate Data)
        {







            
            DateTime TentativeStartDate = DateTime.ParseExact(Data.TentativeStartDate.ToString("MM/dd/yyyy"), "MM/dd/yyyy", null);
            DateTime TentativeCompletionDate = DateTime.ParseExact(Data.TentativeCompletionDate.ToString("MM/dd/yyyy"), "MM/dd/yyyy", null);
            DateTime today = DateTime.Today;

            if (Data.TentativeStartDate.ToString() == "" || TentativeStartDate < today)//Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"))
            {
                //showmsg("Please Enter Valid Start Date");
                //txtTentativeStartDate.Focus();
                return null;
            }
            else if (Data.TentativeCompletionDate.ToString().Trim() == "" || TentativeCompletionDate < today || TentativeCompletionDate < TentativeStartDate)
            {
                //showmsg("Please Enter Valid Completion Date, it must be greather than Start date.");
                //txtTentativeCompletionDate.Focus();
                return null;
            }

            var tagpurchaser = "";
            //foreach (var item in lstTagPurchaser.Items)
            //{
            //    if (item.Selected)
            //    {
            //        // Perform an action with the selected item (item.Text or item.Value)
            //        if (tagpurchaser == "")
            //            tagpurchaser = item.Value;
            //        else
            //            tagpurchaser += "," + item.Value;
            //    }
            //}


            // var rateProposed = "";//txtRateProposed.Text.Trim()
           // var budgettype = ddlbudget.SelectedValue.ToString();

           // decimal Amount;
           // decimal.TryParse(txtRateProposed.Text, out Amount);
            // var Amount = txtRateProposed.Text.Trim();
           // var remarks = txt_Remarks.Text.Trim();

            var outs =  _dbcontext.IndentMasterInsert(
                    Data.IndentID,
                    Data.Company,
                    Data.BU,
                    Data.LocatioWork,
                    Data.TypeofWorkDetails,
                    Data.EnclosureBQQFile,
                    Data.EnclosureDrawingFile,
                    Data.RateProposed,
                    Data.BudgetType,
                    TentativeStartDate,
                   TentativeCompletionDate,
                    Data.ProposedContractorName,
                    Data.VendorExistingLocation,
                    Data.ContractorDetailsAddressGST,
                    Data.Userid,
                    Data.CapexType,
                    Data.Remarks,
                    Data.TagPurchaser,
                    Data.Tat

                );



            if (outs.ToString().Contains("successfully") == true)
            {
                string[] digits = Regex.Split(outs.ToString(), @"[^0-9\.]+");
               // sendmail(digits[1].ToString());
                //var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("" + outs + "");
               // var script = string.Format("alert({0});window.location ='IndentRequest.aspx';", message);
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            }
            else
            {
               // showmsg(outs);
                return null;
            }



            //var data = _dbcontext.IndentMasterInsert.Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
            //if (Data != null)
            //{
            //    //data.EmployeeCity = Model.EmployeeCity;
            //    //data.EmployeeName = Model.EmployeeName;
            //    //data.EmployeeSalary = Model.EmployeeSalary;

            //   var da=  _dbcontext.IndentMasterInsert(
            //        Data.IndentID,
            //        Data.Company,
            //        Data.BU,
            //        Data.LocatioWork,
            //        Data.TypeofWorkDetails,
            //        Data.EnclosureBQQFile,
            //        Data.EnclosureDrawingFile,
            //        Data.RateProposed,
            //        Data.BudgetType,
            //        Data.TentativeStartDate,
            //        Data.TentativeCompletionDate,
            //        Data.ProposedContractorName,
            //        Data.VendorExistingLocation,
            //        Data.ContractorDetailsAddressGST,
            //        Data.Userid,
            //        Data.CapexType,
            //        Data.Remarks,
            //        Data.TagPurchaser,
            //        Data.Tat

            //    );
            //    //_dbcontext.IndentMasterInsert.SaveChanges(Data);
            //}
            return View();
        }








        //[HttpPost]
        //public ActionResult CreateEdit(Employee Model)
        //{
        //    ////var data = _context.Employees.Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
        //    //if (data != null)
        //    //{
        //    //    //data.EmployeeCity = Model.EmployeeCity;
        //    //    //data.EmployeeName = Model.EmployeeName;
        //    //    //data.EmployeeSalary = Model.EmployeeSalary;
        //    //    //_context.SaveChanges();
        //    //}

        //    return RedirectToAction("index");
        //}
        //public IActionResult createIndent(string lang = "de")
        //{
        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}