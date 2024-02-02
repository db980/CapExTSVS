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


using MoreLinq;
using Microsoft.EntityFrameworkCore;

using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

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

            
            //var dtn = _dbcontext.CapexSelCapexRequestDetails("All", "", "","", "","", "", "");
            ViewData["NFADraftRequestGrid"] = _dbcontext.CapexSelCapexRequestDetails("All", "", "0", "", "", "", "", "").ToList();


            return View();
        }

       
        [HttpGet]
        public void NfaReportView(string id)
        {
            //return null;
        }

        [HttpGet]
        public ActionResult NfaReportExport(string id)
        {
            DataTable dt = new DataTable();
            
            dt = _dbcontext.CapexSelCapexreportdata(id).ToDataTable();
            

            try
            {
               
                string reportName = "TestReport";
                string reportPath = Path.Combine(System.Environment.CurrentDirectory,"RDLC", "Report1.rdlc"); //or webHostEnvironment.WebRootPath if your report is in wwwroot folder

                Stream reportDefinition; // your RDLC from file or resource
                                         //IEnumerable dataSource; // your datasource for the report
                using var fs = new FileStream(reportPath, FileMode.Open);
                reportDefinition = fs;
                Microsoft.Reporting.NETCore.LocalReport report = new Microsoft.Reporting.NETCore.LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("dste", dt));
                //report.SetParameters(new[] { new ReportParameter("parameter1", "RDLC Sample Report ") });
                byte[] pdf = report.Render("PDF");
               
                fs.Dispose();

                ViewData["NFADraftRequestGrid"] = _dbcontext.CapexSelCapexRequestDetails("All", "", "0", "", "", "", "", "").ToList();

                return  File(pdf, "application/pdf", reportName + ".pdf");




            }
            catch(Exception ex)
            {
                return null;

            }


        }

        public IActionResult IndentMasterReport()
        {

            ViewData["IndentMasterReportGrid"] = _dbcontext.CapexSelIndentforList("", "","", "").ToList();


            return View();
        }


        
    }
}
