using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;

namespace CapExTSVS.Controllers
{
    public class NFAController : Controller
    {

        private readonly ILogger<NFAController> _logger;
        public CapExTSDB _dbcontext;

        public NFAController(ILogger<NFAController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings();
            _dbcontext = new DataModels.CapExTSDB();

        }
        public IActionResult NFADraftRequest()
        {
            return View();
        }

        public IActionResult CapexApprovalHistory()
        {
            return View();
        }


        public IActionResult CapexApproval()
        {
            return View();
        }

        
    }
}
