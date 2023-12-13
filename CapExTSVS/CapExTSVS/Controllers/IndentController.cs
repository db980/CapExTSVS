using CapExTSVS.Models;
using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CapExTSVS.Controllers
{
    public class IndentController : Controller
    {
        private readonly ILogger<IndentController> _logger;
        public CapExTSDB _dbcontext;

        public IndentController(ILogger<IndentController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings();
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

                var data =_dbcontext.IndentSelApprovalHistory(HttpContext.Session.GetString("usr"), "10091", "17").ToList() ; //txtCapexCode.Text.Trim(), ddlStatus.SelectedValue.ToString()
                ViewData["GridBind"]  = data;
				
			}
            else
            {
                Response.Redirect("noentry.aspx");
            }

            return  View();
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
            return View();
        }

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