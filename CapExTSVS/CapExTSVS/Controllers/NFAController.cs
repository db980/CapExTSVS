using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using static DataModels.CapExTSDBStoredProcedures;
using static LinqToDB.Common.Configuration;

namespace CapExTSVS.Controllers
{
    public class NFAController : Controller
    {

        private readonly ILogger<NFAController> _logger;
        public CapExTSDB _dbcontext;

        public static CapexmainRequestItems Items = new CapexmainRequestItems();
        CapexItems<CapexmainRequestItems> ne = new CapexItems<CapexmainRequestItems>();
        //CapexItems<CapexmainRequestItems> da = new CapexItems<CapexmainRequestItems>();

        static List<CapexmainRequestItems> cty = new List<CapexmainRequestItems>();
        //CapexItems<CapexmainRequestItems> da = new CapexItems<CapexmainRequestItems>();
        public object ViewState { get; private set; }

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
            //ViewData["Items"] = da.Items1.ToList();
            return View();
        }

        public IActionResult CapexApproval()
        {


            ViewData["CapexApprovalGrid"] = _dbcontext.CapexSelPendingforApproval(user.id).ToList();





            return View();
        }

        public IActionResult CapexmainRequest2(CapexmainRequest data)
        {


            

             //var count = CapexItems<CapexmainRequestItems>.SelectEmployeeList();

            CapexbindddlCompany();

            Items.Description = data.Description;
            Items.Qty = data.Qty;
            Items.TexRate = data.TexRate;
            Items.Uom = data.Uom;
            // Items.ID = count.ToString();

            //InsertEmployeeList(Items);


            ne.InsertEmployee<CapexmainRequestItems>(Items);         //CapexItems<CapexmainRequestItems>.SelectEmployeeList();
            //da.Items1.Add(Items);
            //da.Items1.Add(Items);
           var da= ne.SelectAllEmployees<CapexmainRequestItems>();


           // ViewData["Items"] = da.Items1.ToList();

            return  RedirectToAction("CapexmainRequest");
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


            return da.Column1;

        }


        [HttpGet]
        public string CapexBindddlValuChange(string id)
        {
            var da1 = id.Split(',');
            //var da = Vender<SelActiveVendorListResult>.Items1.Where();


            return null;//da.Column1;

        }

    }
}
