using CapExTSVS.Models1;
using DataModels;
using Humanizer;
using LinqToDB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.SqlServer.Server;
using MoreLinq;
using MoreLinq.Extensions;
using MVC_CRUD_LIST.Repository;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Pipelines;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using toastr.Net;
using static DataModels.CapExTSDBStoredProcedures;



namespace CapExTSVS.Controllers
{
    public class NFAController : Controller
    {

        private readonly ILogger<NFAController> _logger;
        public CapExTSDB _dbcontext;
        IFormFileCollection file;
        public string Datamatric { get; set; }

        CapexItems ne = new CapexItems();
        EmployeeRepository rep = new EmployeeRepository();
        //CapexItems<CapexmainRequestItems> da = new CapexItems<CapexmainRequestItems>();

        static List<CapexmainRequestItems> cty = new List<CapexmainRequestItems>();
        List<CapexShowApproval_RequestForm> da3 = null;
        //CapexItems<CapexmainRequestItems> da = new CapexItems<CapexmainRequestItems>();
        string Flag;

        public NFAController(ILogger<NFAController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();


        }

        
         public IActionResult DraftFileUplode(DraftFileUplode data)
        {


           var da= _dbcontext.SaveConversationPost(uploadfile(data.File,"NFA", "ConversationPost"), Convert.ToInt32( data.Status.ToString()), data.Remarks.ToString(),user.id);


            return RedirectToAction("NFADraftRequest", new { data = data.Status.ToString() });
        }


        public IActionResult DraftFileUplodeApproval(DraftFileUplode data)
        {
            if(data.ApprovalStatus.ToString()!=null)
            {

                //exec CapexUpdateApprovalDetails @RequestNo = N'106168',@Empid = N'40000046',@Remarks = N'sdsda',@flag = N'Approve'


                    var da = _dbcontext.CapexUpdateApprovalDetails(data.Status, user.id,data.RemarkApproved,data.ApprovalStatus);

            }
            else
            {
                var da = _dbcontext.SaveConversationPost(uploadfile(data.File, "NFA", "ConversationPost"), Convert.ToInt32(data.Status.ToString()), data.Remarks.ToString(), user.id);

            }




            return RedirectToAction("NFADraftRequestApproval", new { data = data.Status.ToString() });
        }

        public IActionResult NFADraftRequest(string data)
        {

            if(data!=null)
            {

                CapexSelCapexRequestDetailsResultComm a;

                var Da = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").Where(a => a.RequestNo == Convert.ToInt32(data)).SingleOrDefault();

               // exec Capex_SelApprovalCapexDetails @RequestNo = N'100115'

                ViewData["NFADraftRequestGrid"] = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").ToList();
                ViewData["CapexSelCapexRequestDetails"] = Da;

                ViewData["CapexSelApprovalCapexDetails"] =_dbcontext.CapexSelApprovalCapexDetails(data).SingleOrDefault();
                ViewData["CapexSelApprovalCapexLineDetails"] =_dbcontext.CapexSelApprovalCapexLineDetails(data).ToList();
                ViewData["CapexSelApprovalCapexQuoteDetails"] =_dbcontext.CapexSelApprovalCapexQuoteDetails(data).ToList();
                ViewData["CapexFunSelApprovalMaterixNameByReq"] =_dbcontext.CapexFunSelApprovalMaterixNameByReq(data).ToList();
                ViewData["getConversationDetails"] =  _dbcontext.GetConversationDetails(data).ToList();

               ViewBag.js  = string.Format("call();");
                return View("NFADraftRequest", Da);


                

                //return View("NFADraftRequest");
            }
            else {
            var Da = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").ToList();
            ViewData["NFADraftRequestGrid"] = Da;
            }
            //            exec Capex_SelCapexRequestDetails @CreatedBy = N'40000046',@RequestNo = N'',@Status = N'0',@CWIPCODE = N''
            //,@INTERNALORDERNO = N'',@location = N'0',@CompCode = N'',@BU = N''
            return View();
        }




        public IActionResult NFADraftRequestApproval(string data)
        {

            if (data != null)
            {

                CapexSelCapexRequestDetailsResultComm a;

                var Da = _dbcontext.CapexSelPendingforApproval(user.id).Where(a => a.RequestNo == Convert.ToInt32(data)).SingleOrDefault();

                

                 ViewData["CapexSelCapexRequestDetails"] = Da;
                ViewData["CapexApprovalGrid"] = _dbcontext.CapexSelPendingforApproval(user.id).ToList();

                ViewData["CapexSelApprovalCapexDetails"] = _dbcontext.CapexSelApprovalCapexDetails(data).SingleOrDefault();
                ViewData["CapexSelApprovalCapexLineDetails"] = _dbcontext.CapexSelApprovalCapexLineDetails(data).ToList();
                ViewData["CapexSelApprovalCapexQuoteDetails"] = _dbcontext.CapexSelApprovalCapexQuoteDetails(data).ToList();
                ViewData["CapexFunSelApprovalMaterixNameByReq"] = _dbcontext.CapexFunSelApprovalMaterixNameByReq(data).ToList();
                ViewData["getConversationDetails"] = _dbcontext.GetConversationDetails(data).ToList();

                ViewBag.js = string.Format("call();");
                return View("CapexApproval", Da);




                //return View("NFADraftRequest");
            }
            else
            {
                var Da = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").ToList();
                ViewData["NFADraftRequestGrid"] = Da;
            }
            //            exec Capex_SelCapexRequestDetails @CreatedBy = N'40000046',@RequestNo = N'',@Status = N'0',@CWIPCODE = N''
            //,@INTERNALORDERNO = N'',@location = N'0',@CompCode = N'',@BU = N''
            return View();
        }



       


        public IActionResult NFADraftRequestApprovalHistory(string data)
        {

            if (data != null)
            {

                CapexSelCapexRequestDetailsResultComm a;

                var Da = _dbcontext.CapexSelPendingforApproval(user.id).Where(a => a.RequestNo == Convert.ToInt32(data)).SingleOrDefault();



                ViewData["CapexSelCapexRequestDetails"] = Da;
                ViewData["CapexApprovalGrid"] = _dbcontext.CapexSelPendingforApproval(user.id).ToList();

                ViewData["CapexSelApprovalCapexDetails"] = _dbcontext.CapexSelApprovalCapexDetails(data).SingleOrDefault();
                ViewData["CapexSelApprovalCapexLineDetails"] = _dbcontext.CapexSelApprovalCapexLineDetails(data).ToList();
                ViewData["CapexSelApprovalCapexQuoteDetails"] = _dbcontext.CapexSelApprovalCapexQuoteDetails(data).ToList();
                ViewData["CapexFunSelApprovalMaterixNameByReq"] = _dbcontext.CapexFunSelApprovalMaterixNameByReq(data).ToList();
                ViewData["getConversationDetails"] = _dbcontext.GetConversationDetails(data).ToList();
                ViewData["CapexSelApprovalHistoryGrid"] = _dbcontext.CapexSelApprovalHistory(user.id, "", "0").ToList();
                ViewBag.js = string.Format("call();");
                return View("CapexApprovalHistory", Da);




                //return View("NFADraftRequest");
            }
            else
            {
                var Da = ViewData["CapexSelApprovalHistoryGrid"] = _dbcontext.CapexSelApprovalHistory(user.id, "", "0").ToList();
                ViewData["NFADraftRequestGrid"] = Da;
            }
            //            exec Capex_SelCapexRequestDetails @CreatedBy = N'40000046',@RequestNo = N'',@Status = N'0',@CWIPCODE = N''
            //,@INTERNALORDERNO = N'',@location = N'0',@CompCode = N'',@BU = N''
            return View();
        }


        public IActionResult NFADraftRequestModel(string data)
        {
            CapexSelCapexRequestDetailsResultComm a;

            var Da = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").Where(a => a.RequestNo == Convert.ToInt32(data)).SingleOrDefault();


            ViewData["NFADraftRequestGrid"] = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "", "", "", "").ToList();

            return View("NFADraftRequest", Da);
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

        public IActionResult CapexmainRequestEdit(CapexmainRequest data)
        {
            if (data.EID != null && data.EID != "") ///update Query
            {


                var daFiles = _dbcontext.CapexSelReturnCapexFiles(data.EID).ToList();
                var daDetail = _dbcontext.CapexSelReturnCapexDetails(data.EID, user.id).SingleOrDefault();

                var daItems = _dbcontext.CapexSelReturnCapexItems(data.EID).ToList();

                CapexbindddlCompany();

                rep = new EmployeeRepository();

                CapexmainRequestItems Items = new CapexmainRequestItems();
                var count = rep.SelectAllEmployees().Count() + 1;

                int a = 1;


                foreach (var Items1 in daItems)
                {
                    Items.Description = Items1.ItemName.ToString();
                    Items.Qty = Items1.Quantity.ToString();
                    Items.TexRate = Items1.TaxRate.ToString();
                    Items.Uom = Items1.UOM.ToString();
                    Items.ID = a.ToString();
                    a++;
                }

                rep.InsertEmployee(Items);         
                var da = rep.SelectAllEmployees();


                ViewData["Items"] = da.ToList();




                data.IndentId = daDetail.IndentID.ToString()!=null? daDetail.IndentID.ToString():"0";
                data.AssetsType = daDetail.Assettype;
                data.Company = daDetail.CTDes.ToString().Split('/')[0];
                data.BUI = daDetail.CTDes.ToString().Split('/')[1];
                data.EXPType = daDetail.CTDes.ToString().Split('/')[2];
                data.Budget = daDetail.CTDes.ToString().Split('/')[3];
                data.NFA = daDetail.CTDes;
                data.Purpose = daDetail.Purpose;
                data.ExpectedDate = Convert.ToDateTime( daDetail.EdateCompletion);
                data.Description = (daDetail.PDescription !=null  ? daDetail.PDescription.ToString() : "");
                data.Imported = daDetail.ImportedIndigenous;
                data.Justification = daDetail.VendorJustification;
                data.Benefit = daDetail.Benefit;
                data.IRRPaybackValue = daDetail.IRRPaybackPeriodValue;
                data.cashoverFlowValue = daDetail.ProjectedCashOutflowValue;


               

                ViewBag.js = string.Format("DataItemListEdit();EditDropDown('"+ daDetail.CTDes.ToString() + "','"+ daDetail.ImportedIndigenous.ToString() + "','"+ daDetail.EdateCompletion.ToString() + "');CapexBindddlvaluechangeV2();"); 
            }

            return View("CapexmainRequest", data);

        }



        public IActionResult CapexmainRequestView(CapexmainRequest data)
        {
            return View("CapexmainRequest");
        }

        [HttpGet]
            public IActionResult CapexmainRequest2(CapexmainRequest data)
        {

            try
            {



                DataTable DT = new DataTable();
                DataTable DTV = new DataTable();

              var da3=  (data.EID != null ? Flag = data.EID : "");

                var Comp_code = data.Company + "/" + data.BUI.ToString().Split(",")[0] + "/" + data.EXPType.ToString() + "/" + data.Budget.ToString();


                DT.Columns.Add("ID");
                DT.Columns.Add("ItemName");
                DT.Columns.Add("PlantCode");
                DT.Columns.Add("Categories");
                DT.Columns.Add("UOM");
                DT.Columns.Add("Quantity");
                DT.Columns.Add("TaxRate");









                var Data = rep.SelectAllEmployees().ToList();
                foreach (var da1 in Data)
                {
                    DT.Rows.Add(da1.ID, da1.Description, "1010", Comp_code, da1.Uom, da1.Qty, da1.TexRate);
                }


                //InsertEmployeeList(Items);
                var IRRPaybackfile = uploadfile(data.IRRPaybackfile, "NFA", "IRRPaybackfile");
                var cashoverFlowFile = uploadfile(data.cashoverFlowFile, "NFA", "cashoverFlowFile");
                var daAtt = _dbcontext.CapexAttachedTransFileId().SingleOrDefault().Column1;

                var capextype = _dbcontext.UspCapexCapexTypeMapping("GET_CAPEXTYPE_BY_COMPANY_NAME", "", "", "", "", "", "", "", "").ToList();

                var capextype2= capextype.Where(a => a.CapexType == data.NFA.ToString().Trim()).SingleOrDefault();

                CapexmainRequestItems Items = new CapexmainRequestItems();

                var count = rep.SelectAllEmployees().Count() + 1;

                CapexbindddlCompany();

                Items.Description = data.Description;
                Items.Qty = data.Qty;
                Items.TexRate = data.TexRate;
                Items.Uom = data.Uom;
                Items.ID = count.ToString();






                if (data.BTNStatus == "Draft")
                {
                    if (Flag != null && Flag != "")
                    {
                        var da12 = _dbcontext.CapexUSPCapexmasterDraft(data.AssetsType, "", capextype2.CTID.ToString().Trim(), data.Description,
                       data.Description, " ", data.EXPType, data.ExpectedDate,
                        " ", DT, 0, "", (data.Imported != null ? data.Imported : ""),
                    (data.Justification != null ? data.Justification : "") , user.id, daAtt.ToString(), Flag.ToString().Trim(), "@DrawingList", (data.IndentId!=null?data.IndentId:"0"),
                       data.Benefit, IRRPaybackfile, cashoverFlowFile, data.IRRPaybackValue, data.cashoverFlowValue,
                        0);


                        Notification.PopupSaveCustom("Data Create SuccessFully " + "NFA ID : " + da12.SingleOrDefault().Column1 + " drafted Successfully");

                    }
                    else
                    {
                        var da12 = _dbcontext.CapexUSPCapexmasterDraft(data.AssetsType, "", capextype2.CTID.ToString().Trim(), data.Description,
                       data.Description, " ", data.EXPType, data.ExpectedDate,
                        " ", DT, 0, "", (data.Imported != null ? data.Imported : ""),
                    (data.Justification != null ? data.Justification : ""), user.id, daAtt.ToString(), "New", "@DrawingList", (data.IndentId != null ? data.IndentId : "0"),
                       data.Benefit, IRRPaybackfile, cashoverFlowFile, data.IRRPaybackValue, data.cashoverFlowValue,
                        0);


                        Notification.PopupSaveCustom("Data Create SuccessFully " + "NFA ID : " + da12.SingleOrDefault().Column1 + " drafted Successfully");
                    }




                }
                else if (data.BTNStatus == "Submit")
                {
                    if (Flag != null && Flag != "")
                    {
                        var da12 = _dbcontext.CapexUSPCapexmasterModified(data.AssetsType, "", capextype2.CTID.ToString().Trim(), data.Name,
                       data.Description, " ", data.EXPType, Convert.ToDateTime("2024-10-12"),
                        " ", DT, 0, "", (data.Imported != null ? data.Imported : ""),
                    (data.Justification != null ? data.Justification : ""), user.id, daAtt.ToString(), Flag.ToString().Trim(), "@DrawingList", (data.IndentId != null ? data.IndentId : "0"),
                       data.Benefit, IRRPaybackfile, cashoverFlowFile, data.IRRPaybackValue, data.cashoverFlowValue,
                        0);
                        var matches = Regex.Matches(Flag, @"\d+");
                        var str2 = string.Empty;
                        foreach (var match in matches)
                        {
                            str2 += match;
                        }

                        var resultString = Regex.Replace(Flag, @"\d+", "");


                        data.UID = da12.SingleOrDefault().Column1;
                        //Flag = da12.SingleOrDefault().Column1.ToString();

                        ViewBag.Message2 = Notification.PopupSaveCustom("Data Create SuccessFully " + "NFA ID : " + str2 + " drafted Successfully");
                    }
                    else
                    {//Convert.ToDateTime(data.ExpectedDate)

                        var dataCapex = _dbcontext.CapexMasters.Where(a => a.RequestNo == Convert.ToInt32(Flag)).SingleOrDefault();
                        var da12 = _dbcontext.CapexUSPCapexmasterModified(data.AssetsType, "", capextype2.CTID.ToString().Trim(), data.Name,
                       data.Description, " ", data.EXPType, Convert.ToDateTime(data.ExpectedDate),
                        " ", DT, 0, "", (data.Imported != null ? data.Imported : ""),
                    (data.Justification != null ? data.Justification : ""), user.id, daAtt.ToString(), "New", "@DrawingList", (data.IndentId != null ? data.IndentId : "0"),
                       data.Benefit, IRRPaybackfile, cashoverFlowFile, data.IRRPaybackValue, data.cashoverFlowValue,
                        0);
                        //data.UID = da12.SingleOrDefault().Column1;
                        Flag = da12.SingleOrDefault().Column1.ToString();
                        var matches = Regex.Matches(Flag, @"\d+");
                        var str2=string.Empty;
                        foreach (var match in matches)
                        {
                            str2 += match;
                        }
                        
                        var resultString = Regex.Replace(Flag, @"\d+","");
                        //ViewBag.js = string.Format(" $('#EID').val("+ str2 + ");");
                        ViewBag.Message2= Notification.PopupSaveCustom("Data Update SuccessFully " + "NFA ID : " + str2 + " drafted Successfully");
                    }
                }


                rep.InsertEmployee(Items);         //CapexItems<CapexmainRequestItems>.SelectEmployeeList();
                                                   //da.Items1.Add(Items);
                                                   //da.Items1.Add(Items);
                var da = rep.SelectAllEmployees();
                ViewData["Items"] = da.ToList();
                return RedirectToAction("CapexmainRequest", data);

            }
            catch (Exception)
            {
                Notification.PopupCustomeError("Data Fail ");
                return RedirectToAction("CapexmainRequest", data);
            }
        }








        [HttpGet]
        public List<CapexmainRequestItems> DataList1(string Description, string UOM, string Qty, string TaxRate)
        {


            CapexmainRequestItems Items = new CapexmainRequestItems();
            var count = rep.SelectAllEmployees().Count() + 1;

            CapexbindddlCompany();

            Items.Description = Description.ToString();
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


        [HttpGet]
        public List<CapexmainRequestItems> DataItemListEdit(string Description, string UOM, string Qty, string TaxRate)
        {

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


            return da.Column1 != null ? da.Column1 : "";

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
            var da = DataMatrix(id);
            ViewData["Item2"] = da;
            return da;
        }


        public IList<CapexShowApproval_RequestForm> DataMatrix(string id)
        {
            if(id == null)
            {
                return null;
            }
            var da = id.Split("/");

            var da2 = _dbcontext.CapexSelCapexType(user.id, da[0].Trim(), da[1].Trim(), da[2].Trim(), da[3].Trim()).ToList();

            // _dbcontext.
            if (da2.Any())
            {
                da3 = _dbcontext.CapexShowApproval_RequestForm1("0", da2.SingleOrDefault().CTID.ToString(), user.id, "NA").ToList();

            }




            return da3.ToList();

        }



        [HttpPost]
        public void Form2(IFormFileCollection da)
        {


        }



        [HttpPost]
        public string AddFileUplode(IFormFileCollection data)
        {
            file = data;
            return "";
        }

        




            [HttpPost]
        public string  AddFriend(IFormCollection fm)
        {


            try
            {





                DataTable DT = new DataTable();
                DataTable DTV = new DataTable();


                var Comp_code = fm["NFA"].ToString(); //fm["Comp_code"].ToString() + "/" + fm["BU"].ToString().Split(",")[0] + "/" + fm["ReqType"].ToString() + "/" + fm["BudgetType"].ToString();


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
                foreach (var da1 in Data)
                {
                    DT.Rows.Add(da1.ID, da1.Description, "1010", Comp_code, da1.Uom, da1.Qty, da1.TexRate);
                }
                foreach (var da2 in Data)
                {
                    DTV.Rows.Add(da2.ID, da2.Description, da2.Uom, da2.Qty, "0", "0", "0", "0", da2.TexRate, "0", "test");
                }



                var capextype = _dbcontext.UspCapexCapexTypeMapping("GET_CAPEXTYPE_BY_COMPANY_NAME", "", "", "", "", "", "", "", "").ToList();
                var capextype2 = capextype.Where(a => a.CapexType == Comp_code.ToString().Trim()).SingleOrDefault();


                var daAtt = _dbcontext.CapexAttachedTransFileId().SingleOrDefault().Column1;
                var dtf = _dbcontext.CapexSelReturnCapexFiles(fm["EID"].ToString()).SingleOrDefault();
                

                _dbcontext.CapexFAddAttachment("", (dtf!=null?dtf.FileCode: daAtt.ToString()), user.id, "FileType",
                    100, fm["F3_TermCondition"].ToString(), fm["F3_PaymentTerms"].ToString(), fm["F3_Delivery"].ToString(), fm["F3_Freight"].ToString(), fm["F3_InstalationCost"].ToString(),
                    fm["Remark"].ToString(), DTV);


                //string outs = _dbcontext.CapexUSPCapexmasterDraft("New", "", drp_budget.SelectedValue.ToString(), txt_pname.Text.Trim(), txt_pdesc.Text.Trim(), "",
                //                                   txt_purpose.Text.Trim(), txt_compdate.Text.Trim(), "", DT, "0", rbtnSelectQuote.SelectedValue.ToString(), drp_ImportedIndigenous.SelectedValue.ToString(),
                //                                   txt_jst.Text.Trim(), Session["usr"].ToString(), ViewState["GuidValue"].ToString(), ViewState["ReqID"].ToString(), pass, "", "", "", "", " ",
                //                                   txtIndentID.Text.Trim(), txtBenefit.Text.Trim(), IRRPaybackV, CashOutflowV, txtPaybackPeriodValue.Text.Trim(), txtProjectedCashOutflowValue.Text.Trim(), CFCAmount);

                var da = _dbcontext.CapexUSPCapexmasterDraft(fm["AssetsType"].ToString(), "", (capextype2 != null? capextype2.CTID.ToString():""), fm["Name"].ToString(),
                fm["DescriptionProject"].ToString(), "", fm["EXPType"].ToString(), Convert.ToDateTime(fm["ExpectedDate"]),
                "", DT, 0, "", (fm["Imported"].ToString() != null ? fm["Imported"].ToString() : ""),
                (fm["Justification"].ToString() != null ? fm["Justification"] : ""), user.id, (dtf != null ? dtf.FileCode : daAtt.ToString()), ( fm["EID"]!="" ? fm["EID"].ToString(): "New") , "@DrawingList", (fm["IndentId"].ToString() != null ? fm["IndentId"] : "0"),
                fm["Benefit"].ToString(), "", "", fm["IRRPaybackValue"].ToString(), fm["cashoverFlowValue"].ToString(),
                0);

                var matches = Regex.Matches(da.SingleOrDefault().Column1, @"\d+");
                var str2 = string.Empty;
                foreach (var match in matches)
                {
                    str2 += match;
                }

                ViewBag.js = string.Format("EID(" + str2 + ");");

                ViewBag.Message2 = Notification.PopupSaveCustom("Qutation Create SuccessFully");

                return str2; //RedirectToAction("create");

            }
            catch (Exception ex)
            {
                ViewBag.Message2 = Notification.PopupCustomeError("Qutation Failed");
                return "";
                //return Json("fail");
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
        public string UploadFile(IFormFile id)
        {
            // do something here
            return null;
        }



        private string uploadfile(IFormFile fileup, string SubFolder, string fileType)
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






                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                        //create folder if not exist
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path).CreateSubdirectory(SubFolder);

                        //get file extension
                        FileInfo fileInfo = new FileInfo(fileup.FileName);
                        string fileName = fileup.FileName.Replace(fileup.FileName, fileType + DateTime.Now.ToString("ddMMyyyyhhmmss")) + fileInfo.Extension.ToString();

                        string fileNameWithPath = Path.Combine(path, fileName);

                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            fileup.CopyTo(stream);
                        }





                        loc = fileName;
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
