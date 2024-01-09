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
            //Stream reportPath = Environment.CurrentDirectory.ToString();  //Server.MapPath("StudentBus.rdlc"); // your RDLC from file or resource
            ////IEnumerable dataSource= dt; // your datasource for the report

            //LocalReport report = new LocalReport();
            //report.LoadReportDefinition(reportPath);
            //report.DataSources.Add(new ReportDataSource("dste", dt));
            //report.SetParameters(new[] { new ReportParameter("Parameter1", "Parameter value") });
            //byte[] pdf = report.Render("PDF");





            // Create a data source for the report
            //var dataSource = new ReportDataSource("dste", dt);

            // Load the report
            //LocalReport localReport = new LocalReport();
            //localReport.ReportPath = "D:\\testing_@\\Self\\Running\\CapExTSVS\\CapExTSVS\\RDLC\\Report1.rdlc";
            //localReport.DataSources.Add(dataSource);

            //// Render the report
            //string fileNameExtension = "PDF"; // Can be PDF, Excel, etc.
            //string mimeType= "application/pdf";
            //string encoding;
            //string fileNameExtension1= "PDF";
            //Warning[] warnings;
            //byte[] pdf1 = localReport.Render("PDF");
            //string[] streams = localReport.Render(
            //    reportType,
            //    null, out mimeType, out encoding, out fileNameExtension, out warnings);

            // Return the rendered report as a file download
            //var result = localReport.Execute(RenderType.Excel, extension, parameters, mimetype);
            //return File(result.MainStream, "application/msexcel", "Export.xls");

            try
            {
                //string mimetype = "";
                //int extension = 1;
                //var path = "D:\\testing_@\\Self\\Running\\CapExTSVS\\CapExTSVS\\RDLC\\Report1.rdlc";
                //Dictionary<string, string> parameters = new Dictionary<string, string>();
                //// parameters.Add("prm", "RDLC report (Set as parameter)");
                //AspNetCore.Reporting.LocalReport lr = new AspNetCore.Reporting.LocalReport(path);
                //lr.AddDataSource("dste", dt);
                //var result = lr.Execute(RenderType.Excel, extension, parameters, mimetype);
                //return File(result.MainStream, "application/msexcel", "Export.xls");




                string reportName = "TestReport";
                string reportPath = Path.Combine("D:\\testing_@\\Self\\Running\\CapExTSVS\\CapExTSVS\\RDLC\\", "Report1.rdlc"); //or webHostEnvironment.WebRootPath if your report is in wwwroot folder

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




                //string mimetype = "";
                //int extension = 1;
                //var path = reportPath;
                //Dictionary<string, string> parameters = new Dictionary<string, string>();
                //parameters.Add("prm", "RDLC report (Set as parameter)");
                //Microsoft.Reporting.NETCore.LocalReport lr = new Microsoft.Reporting.NETCore.LocalReport();
                //lr.DataSources.Add("dste", dt);
                //var result = lr.Execute(RenderType.Excel, extension, parameters, mimetype);
                //return File(result.MainStream, "application/msexcel", "Export.xls");



            }
            catch(Exception ex)
            {
                return null;

            }



            


            // DataTable dt = new DataTable();
            // string id = d;

            // dt = _dbcontext.CapexSelCapexreportdata(id).ToDataTable();
            //// dt.Rows = a;
            // CapexTSDataSet dste = new CapexTSDataSet();
            // dste.Tables.Clear();
            // dste.Tables.Add(dt);
            // Warning[] warnings;
            // string[] streamIds;
            // string mimeType = string.Empty;
            // string encoding = string.Empty;
            // string extension = string.Empty;
            // ReportViewer ReportViewer1 = new ReportViewer();
            // ReportViewer1.LocalReport.ReportPath = "Report.rdlc";
            // ReportViewer1.LocalReport.DataSources.Clear();
            // ReportDataSource rdc = new("CustomerDataSet", dt);
            // ReportViewer1.LocalReport.DataSources.Add(item: new ReportDataSource("dste", dt));
            // ReportViewer1.LocalReport.Refresh();
            // byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            //// Response.Buffer = true;
            // Response.Clear();
            // Response.ContentType = mimeType;


            // Stream reportDefinition; // your RDLC from file or resource
            // IEnumerable dataSource; // your datasource for the report

            // LocalReport report = new LocalReport();
            // report.LoadReportDefinition(reportDefinition);
            // report.DataSources.Add(new ReportDataSource("source", dataSource));
            // report.SetParameters(new[] { new ReportParameter("Parameter1", "Parameter value") });
            // byte[] pdf = report.Render("PDF");

            // DataSet ds = SomeMethodToRetrieveDataSet(); // e.g. via DataAdapter
            //                                             // If your report needs parameters, they need to be set ...
            // ReportParameter[] parameters = new ReportParameter[...];

            // ReportDataSource reportDataSource = new ReportDataSource();
            // // Must match the DataSource in the RDLC
            // reportDataSource.Name = "ReportData";
            // reportDataSource.Value = ds.Tables[0];

            // // Add any parameters to the collection
            // reportViewer1.LocalReport.SetParameters(parameters);
            // reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            // reportViewer1.DataBind();
            //Response.AddHeader("content-disposition", "attachment; filename=" + id + "." + extension);
            // Response.OutputStream.Write(bytes, 0, bytes.Length);
            //Response.Flush();
            //Response.End();

            //return null;
        }

        public IActionResult IndentMasterReport()
        {

            ViewData["IndentMasterReportGrid"] = _dbcontext.CapexSelIndentforList("", "","", "").ToList();


            return View();
        }


        
    }
}
