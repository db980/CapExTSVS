using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using static DataModels.CapExTSDBStoredProcedures;

namespace CapExTSVS.Controllers
{
    public class NFAController : Controller
    {

        private readonly ILogger<NFAController> _logger;
        public CapExTSDB _dbcontext;

        public NFAController(ILogger<NFAController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();

        }
        public IActionResult NFADraftRequest()
        {
            ViewData["NFADraftRequestGrid"] = _dbcontext.CapexSelCapexRequestDetails(user.id, "", "0", "", "","", "", "").ToList();


            return View();
        }



        protected void CapexbindddlCompany()
        {

            ViewData["CapexbindddlCompany"] = _dbcontext.CapexSelddl("", "com").ToList();

        }

        public IActionResult CapexApprovalHistory()
        {
            
                  ViewData["CapexSelApprovalHistoryGrid"] = _dbcontext.CapexSelApprovalHistory(user.id,"","0").ToList();

            return View();
        }

        public IActionResult CapexmainRequest()
        {

            CapexbindddlCompany();
            return View();
        }

        public IActionResult CapexApproval()
        {


            ViewData["CapexApprovalGrid"] = _dbcontext.CapexSelPendingforApproval(user.id).ToList() ;





            return View();
        }
        [HttpGet]
        public IList<UspCapexSelComProjectResult> CapexBindddlProject(string id)
        {

            var dt = _dbcontext.UspCapexSelComProject(id).ToList();


            //_dbcontext.CapexSelCapexType();


            return dt.ToList();
        }

    }
}
