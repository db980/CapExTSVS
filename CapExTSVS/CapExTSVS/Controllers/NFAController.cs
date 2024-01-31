using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using MVC_CRUD_LIST.Repository;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using static DataModels.CapExTSDBStoredProcedures;
using static LinqToDB.Common.Configuration;


namespace CapExTSVS.Controllers
{
    public class NFAController : Controller
    {

        private readonly ILogger<NFAController> _logger;
        public CapExTSDB _dbcontext;

        public string Datamatric { get; set; }

        CapexItems ne = new CapexItems();
        EmployeeRepository rep = new EmployeeRepository();
        //CapexItems<CapexmainRequestItems> da = new CapexItems<CapexmainRequestItems>();

        static List<CapexmainRequestItems> cty = new List<CapexmainRequestItems>();
        List<CapexShowApproval_RequestForm> da3 = null;
        //CapexItems<CapexmainRequestItems> da = new CapexItems<CapexmainRequestItems>();


        public NFAController(ILogger<NFAController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();

            
        }
        public IActionResult NFADraftRequest()
        {
            ViewData["NFADraftRequestGrid"] = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").ToList();


            return View();
        }



        protected void CapexbindddlCompany()
        {

            ViewData["CapexbindddlCompany"] = _dbcontext.CapexSelddl("", "com").ToList();

        }

        public IActionResult CapexApprovalHistory()
        {

            ViewData["CapexSelApprovalHistoryGrid"] = _dbcontext.CapexSelApprovalHistory(user.id, "", "0").ToList();

            return View();
        }

        public IActionResult CapexmainRequest()
        {

            CapexbindddlCompany();
            ViewData["Items"] = rep.SelectAllEmployees();

            ViewData["Item2"] = da3;
            //var da = DataMatrix(Datamatric);
            //ViewData["Item2"] = da;
            return View();
        }

        public IActionResult CapexApproval()
        {


            ViewData["CapexApprovalGrid"] = _dbcontext.CapexSelPendingforApproval(user.id).ToList();





            return View();
        }

        public IActionResult CapexmainRequest2(CapexmainRequest data)
        {


             CapexmainRequestItems Items = new CapexmainRequestItems();

        var count = rep.SelectAllEmployees().Count()+1;

        CapexbindddlCompany();

            Items.Description = data.Description;
            Items.Qty = data.Qty;
            Items.TexRate = data.TexRate;
            Items.Uom = data.Uom;
             Items.ID = count.ToString();

            //InsertEmployeeList(Items);




            rep.InsertEmployee(Items);         //CapexItems<CapexmainRequestItems>.SelectEmployeeList();
            //da.Items1.Add(Items);
            //da.Items1.Add(Items);
           var da= rep.SelectAllEmployees();


            ViewData["Items"] = da.ToList();
            
            return  RedirectToAction("CapexmainRequest");
        }



        [HttpGet]
       public List<CapexmainRequestItems> DataList1(string Description, string UOM, string Qty, string TaxRate)
        {

           
            CapexmainRequestItems Items = new CapexmainRequestItems();
            var count = rep.SelectAllEmployees().Count() + 1;

            CapexbindddlCompany();

            Items.Description =Description.ToString();
            Items.Qty = Qty.ToString();
            Items.TexRate = TaxRate.ToString();
            Items.Uom = UOM.ToString();
            Items.ID = count.ToString();

            //InsertEmployeeList(Items);




            rep.InsertEmployee(Items);         //CapexItems<CapexmainRequestItems>.SelectEmployeeList();
                                               //da.Items1.Add(Items);
                                               //da.Items1.Add(Items);
            var da = rep.SelectAllEmployees();


            ViewData["Items"] = da.ToList();
            return da;
        }


        public IActionResult Dropdownchange2(string ID)
        {


            return null;
        }






        [HttpGet]
        public IList<UspCapexSelComProjectResult> CapexBindddlProject(string id)
        {

            var dt = _dbcontext.UspCapexSelComProject(id).ToList();
            Vender<SelActiveVendorListResult>.Items1.AddRange(_dbcontext.SelActiveVendorList(id).ToList());

           
            //_dbcontext.CapexSelCapexType();


            return dt.ToList();
        }



        [HttpGet]
        public IList<SelActiveVendorListResult> CapexBindddlProjectVender(string id)
        {
           var da = Vender<SelActiveVendorListResult>.Items1.ToList();

            

            return da;

        }

        [HttpGet]
        public string CapexBindddlProjectAddress(string id)
        {
            var da1 = id.Split('-');
            var da = _dbcontext.CapexSelVendorAddressDetails(da1[1].Trim()).SingleOrDefault();


            return da.Column1 != null ? da.Column1:"" ;

        }


        [HttpGet]
        public string CapexBindddlValuChange(string id)
        {
            var da1 = id.Split(',');
            //var da = Vender<SelActiveVendorListResult>.Items1.Where();


            return null;//da.Column1;

        }


        [HttpGet]
        public IList<CapexShowApproval_RequestForm> CapexBindddlValuChange1(string id)
        {
            Datamatric = id;
            var da=DataMatrix(id) ;
            ViewData["Item2"] = da;
            return da;
        }


        public IList<CapexShowApproval_RequestForm> DataMatrix(string id)
        {
            var da= id.Split(",");

            var da2 = _dbcontext.CapexSelCapexType(user.id, da[0].Trim(), da[1].Trim(), da[2].Trim(), da[3].Trim()).ToList();
          
            // _dbcontext.
            if (da2.Any())
            {
                da3 = _dbcontext.CapexShowApproval_RequestForm1("0", da2.SingleOrDefault().CTID.ToString(), user.id, "NA").ToList();

            }


           
           
            return da3.ToList();

        }



        [HttpPost]
        public void Form2(object da)
        {

        }


        [HttpPost]
        public ActionResult AddFriend(IFormCollection fm)
        {
            DataTable DT = new DataTable();
            DataTable DTV = new DataTable();


            var Comp_code = fm["Comp_code"].ToString()+ "/" + fm["BU"].ToString().Split(",")[0]+ "/" + fm["ReqType"].ToString()+"/"+ fm["BudgetType"].ToString() ;
          
           

            DT.Columns.Add("ItemName");
            DT.Columns.Add("PlantCode");
            DT.Columns.Add("Categories");
            DT.Columns.Add("UOM");
            DT.Columns.Add("Quantity");
            DT.Columns.Add("TaxRate");


            DTV.Columns.Add("LineItem");
            DTV.Columns.Add("ItemName");
            DTV.Columns.Add("UOM");
            DTV.Columns.Add("Quantity");
            DTV.Columns.Add("InitialRate");
            DTV.Columns.Add("InitialAmount");
            DTV.Columns.Add("FinalRate");
            DTV.Columns.Add("FinalAmount");
            DTV.Columns.Add("TaxRate");
            DTV.Columns.Add("FinalAmountWithTax");
            DTV.Columns.Add("Remarks");


            var Data = rep.SelectAllEmployees().ToList();
            foreach(var da in Data)
            {
                DT.Rows.Add( da.Description, "1010", Comp_code, da.Uom,da.Qty,da.TexRate);
            }








            


            //HttpFileCollectionBase files = Request.Files;

            //Write your database insertHttpFileCollectionBase files = Request.Files;   code / activities


            //_dbcontext.CapexFAddAttachment(null,"", user.id, fm["BU"].ToString().Split(",")[1],
            //                    0,.ToString(), , ,,,
            //                    "", );

            _dbcontext.CapexFAddAttachment("", "", user.id, "FileType",
                100, fm["F3_TermCondition"].ToString(), fm["F3_PaymentTerms"].ToString(), fm["F3_Delivery"].ToString(), fm["F3_Freight"].ToString(), fm["F3_InstalationCost"].ToString(),
                fm["Remark"].ToString(), DTV);


            //string outs = ba.Capex_insert_draft("New","", drp_budget.SelectedValue.ToString(), txt_pname.Text.Trim(), txt_pdesc.Text.Trim(), "",
            //                                   txt_purpose.Text.Trim(), txt_compdate.Text.Trim(), "", DT, "0", rbtnSelectQuote.SelectedValue.ToString(), drp_ImportedIndigenous.SelectedValue.ToString(),
            //                                   txt_jst.Text.Trim(), Session["usr"].ToString(), ViewState["GuidValue"].ToString(), ViewState["ReqID"].ToString(), pass, "", "", "", "", " ",
            //                                   txtIndentID.Text.Trim(), txtBenefit.Text.Trim(), IRRPaybackV, CashOutflowV, txtPaybackPeriodValue.Text.Trim(), txtProjectedCashOutflowValue.Text.Trim(), CFCAmount);



            return RedirectToAction("create");

        }


        public class FriendModel
        {
            public string FriendName { get; set; }
            public string Phone { get; set; }
            public string State { get; set; }
        }


        [HttpGet]
        public ActionResult ChangeData(string id)
        {



            //HttpFileCollectionBase files = Request.Files;

            //Write your database insertHttpFileCollectionBase files = Request.Files;   code / activities
           
            return RedirectToAction("create");

        }


    }
}
