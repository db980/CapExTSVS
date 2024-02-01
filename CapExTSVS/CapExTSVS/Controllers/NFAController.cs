using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.Web.Helpers;
using MoreLinq;
using MVC_CRUD_LIST.Repository;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Pipelines;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using toastr.Net;
using static DataModels.CapExTSDBStoredProcedures;



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
            uploadfile(data.IRRPaybackfile,"NFA");
            uploadfile(data.cashoverFlowFile,"NFA");

            //_dbcontext.CapexUSPCapexmasterModified( string @Assettype, string @OldAssetCode, string @Budgeted, string @PName,
            //    string @PDescription, string @CapitalExpenseAsset, string @Purpose, DateTime ? @EdateCompletion, 
            //    string @PurchaseLocation, DataTable @dtLineItem, decimal ? @TotalValueInINR, string @SelectQuote, string @ImportedIndigenous,
            //    string @VendorJustification, string @CreatedBy, string @FileGuidValue, string @flag, string @DrawingList, string @IndentID, 
            //    string @Benefit, string @IRRPaybackPeriod, string @ProjectedCashOutflow, string @IRRPaybackPeriodValue, string @ProjectedCashOutflowValue, 
            //    decimal ? @CFCAmount)

            //    CapexUSPCapexmaster_draft
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


            try
            {

            
           


            DataTable DT = new DataTable();
            DataTable DTV = new DataTable();


            var Comp_code = fm["Comp_code"].ToString()+ "/" + fm["BU"].ToString().Split(",")[0]+ "/" + fm["ReqType"].ToString()+"/"+ fm["BudgetType"].ToString() ;


                DT.Columns.Add("ID");
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
            foreach(var da1 in Data)
            {
                DT.Rows.Add(da1.ID,da1.Description, "1010", Comp_code, da1.Uom,da1.Qty,da1.TexRate);
            }
            foreach (var da2 in Data)
            {
                DTV.Rows.Add(da2.ID , da2.Description, da2.Uom,da2.Qty,"0","0","0","0",  da2.TexRate,"0","test");
            }






               var daAtt= _dbcontext.CapexAttachedTransFileId().SingleOrDefault().Column1;


            _dbcontext.CapexFAddAttachment("", daAtt.ToString(), user.id, "FileType",
                100, fm["F3_TermCondition"].ToString(), fm["F3_PaymentTerms"].ToString(), fm["F3_Delivery"].ToString(), fm["F3_Freight"].ToString(), fm["F3_InstalationCost"].ToString(),
                fm["Remark"].ToString(), DTV);


            //string outs = _dbcontext.CapexUSPCapexmasterDraft("New", "", drp_budget.SelectedValue.ToString(), txt_pname.Text.Trim(), txt_pdesc.Text.Trim(), "",
            //                                   txt_purpose.Text.Trim(), txt_compdate.Text.Trim(), "", DT, "0", rbtnSelectQuote.SelectedValue.ToString(), drp_ImportedIndigenous.SelectedValue.ToString(),
            //                                   txt_jst.Text.Trim(), Session["usr"].ToString(), ViewState["GuidValue"].ToString(), ViewState["ReqID"].ToString(), pass, "", "", "", "", " ",
            //                                   txtIndentID.Text.Trim(), txtBenefit.Text.Trim(), IRRPaybackV, CashOutflowV, txtPaybackPeriodValue.Text.Trim(), txtProjectedCashOutflowValue.Text.Trim(), CFCAmount);

          var da=  _dbcontext.CapexUSPCapexmasterDraft("New", "OldAssetCode", "Budgeted", "PName", "PDescription", "CapitalExpenseAsset", "@Purpose", Convert.ToDateTime(fm["exced_daw_of_corelation"].ToString().Split(",")[1]), "@PurchaseLocation", DT,  0, "@SelectQuote", "@ImportedIndigenous",
                "@VendorJustification", "@CreatedBy", daAtt.ToString(), "New", "@DrawingList", "", "@Benefit", "@IRRPaybackPeriod", "@ProjectedCashOutflow", "@IRRPaybackPeriodValue", "@ProjectedCashOutflowValue", 0);


                ViewBag.Message2 = Notification.PopupSaveCustom("Qutation Create SuccessFully");
                return RedirectToAction("create");

            }
            catch (Exception ex)
            {
                ViewBag.Message2 = Notification.PopupCustomeError("Qutation Failed");
                return Json("fail");
            }

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


        [HttpPost]
        public  string UploadFile(IFormFile id)
        {
            // do something here
            return null;
        }



        private  string uploadfile(IFormFile fileup, string SubFolder)
        {
            string loc = "";
            try
            {
                if (fileup.Length > 0)
                {

                    string fn = System.IO.Path.GetFileName(fileup.FileName).Replace(".", DateTime.Now.ToString("ddMMyyyyhhmmss") + ".").Replace(" ", "");
                    String SaveLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);//Server.MapPath("").ToString().Substring(0, Server.MapPath("").ToString().Length - 0) + "\\uploadFiles\\NFA\\" + fn;

                    try
                    {




                       

                        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "UploadsFiles");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path).CreateSubdirectory(SubFolder);
                            
                        }





                        //var fileName = ContentDispositionHeaderValue
                        //       .Parse(fileup.ContentDisposition)
                        //       .FileName.ToString().Replace(".", DateTime.Now.ToString("ddMMyyyyhhmmss") + ".").Replace(" ", "")
                        //       .Trim('"');

                        //var filePath = _hostingEnvironment.WebRootPath + "\\wwwroot\\" + fileName;
                        // filePath.SaveAsAsync(fileup);
                        //using (var stream = new MemoryStream())
                        //{
                        //    fileup.CopyTo(stream);

                        //}

                       
                        using (FileStream fileStream = new FileStream(Path.Combine(path ,SubFolder), FileMode.OpenOrCreate,FileAccess.ReadWrite))
                        {
                            

                              var memoryStream = new MemoryStream();
                             fileStream.CopyToAsync(memoryStream);
                            memoryStream.CopyTo(fileStream);

                           
                            //fileup.CopyToAsync(fileStream);


                        }
                        //fileStream.Close();


                        loc = fn;
                    }
                    catch
                    {
                        //Response.Write("Error: " & Exc.Message);
                    }
                }
            }
            catch { }
            return loc;
        }



    }
}
