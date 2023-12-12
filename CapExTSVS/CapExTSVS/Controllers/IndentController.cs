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





            // var da=_DBContext.IndentMasters.Select(a=>a).ToList(); 




            
            
            
            

            var q =
                (from c in _dbcontext.IndentMasters
                select c).ToList();

            foreach (var c in q)
                Console.WriteLine(c.Company);


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