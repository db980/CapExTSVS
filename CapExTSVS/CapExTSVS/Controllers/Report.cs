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

namespace CapExTSVS.Controllers
{
    public class Report : Controller
    {

        private readonly ILogger<Report> _logger;
        public CapExTSDB _dbcontext;

        public Report(ILogger<Report> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();

        }


        public IActionResult NfaReport()
        {
            return View();
        }

        public IActionResult IndentMasterReport()
        {
            return View();
        }


        
    }
}
