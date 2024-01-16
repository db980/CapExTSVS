using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using toastr.Net;
using toastr.Net.OptionEnums;

namespace CapExTSVS.Controllers
{
    public class LoginController : Controller
    {


        private readonly ILogger<LoginController> _logger;
        public CapExTSDB _dbcontext;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            DataConnection.DefaultSettings = new MySettings(null);
            _dbcontext = new DataModels.CapExTSDB();

        }
        public IActionResult Index()
        {
            

            return View();
        }


        public ActionResult Login(Logindata login)
        {

            var data = _dbcontext.UserCreate_Stor(login.EID, login.Password,"1", "UserCreateMasterGet").SingleOrDefault(); //txtCapexCode.Text.Trim(), ddlStatus.SelectedValue.ToString()

            if (data == null)
            {
                ViewBag.Message = Notification.Show("Inalid User & Password", position: Position.TopRight, type: ToastType.Error, timeOut: 7000);
                return View("index");
            }
           
            if(data.EmpCode!="")
            {
                if (data.IsActive != "1")
                {
                    ViewBag.Message = Notification.Show("Inalid User Not  Active", position: Position.TopRight, type: ToastType.Error, timeOut: 7000);

                    return View("index");
                }

                HttpContext.Session.SetString("usr", data.EmpCode.ToString());

                user.id = data.EmpCode;
                //user.Name = data.SingleOrDefault().name;


                return RedirectToAction("inddashboard", "indent");
            }
           
            else
            {
                ViewBag.Message = Notification.Show("Inalid User & Password", position: Position.TopRight, type: ToastType.Error, timeOut: 7000);

            }


            return View("index");
        }





    }
}
