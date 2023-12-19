using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;

namespace CapExTSVS.Controllers
{
    public class LoginController : Controller
    {


        private readonly ILogger<LoginController> _logger;
        public CapExTSDB _dbcontext;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings();
            _dbcontext = new DataModels.CapExTSDB();

        }
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
