using CapExTSVS.Models1;
using DataModels;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;

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

          
            return View();
        }

        public IActionResult CapexApprovalHistory()
        {
            return View();
        }

        public IActionResult CapexmainRequest()
        {
            return View();
        }

        public IActionResult CapexApproval()
        {


            //var CFCAmount = 0m;
            //if (ddlbu.SelectedValue == "Engineering" && ddlexp.SelectedValue == "Capex" && ddlbudget.SelectedValue == "CFC")
            //{
            //    if (txt_CFCAmount.Text.Trim() == "")
            //    {
            //        showmsg("Please Enter CFC Amount.");
            //        txt_CFCAmount.Focus();
            //        return;
            //    }
            //    CFCAmount = Convert.ToDecimal(txt_CFCAmount.Text);
            //    if (CFCAmount <= 0)
            //    {
            //        showmsg("Please Enter valid CFC Amount.");
            //        txt_CFCAmount.Focus();
            //        return;
            //    }
            //}


            //if (txt_purpose.Text.Trim() == "")
            //{
            //    showmsg("Please Enter purpose");
            //    txt_purpose.Focus();
            //    return;
            //}

            //if (txt_compdate.Text.Trim() == "" || Convert.ToDateTime(txt_compdate.Text.Trim()) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
            //{
            //    showmsg("Please Enter Valid Expected Date of Completion");
            //    txt_compdate.Focus();
            //    return;
            //}


            //if (dglocal.Items.Count == 0)
            //{
            //    showmsg("Please Add Line Items");
            //    dglocal.Focus();
            //    return;
            //}
            //if (drp_ImportedIndigenous.SelectedValue.ToString() == "")
            //{
            //    showmsg("Please Select Imported/ Indigenous");
            //    drp_ImportedIndigenous.Focus();
            //    return;

            //}

            //if (grddata.Rows.Count == 0 && txt_jst.Text.Trim() == "")
            //{
            //    showmsg("Please Enter Justification, due to quote not attached");
            //    txt_jst.Focus();
            //    return;
            //}


            //DataTable fat = new DataTable();

            //if (grddata.Rows.Count > 0)
            //{
            //    fat.Columns.Add("FileId");
            //    fat.Columns.Add("FileType");
            //    foreach (GridViewRow item in grddata.Rows)
            //    {
            //        DataRow row;
            //        row = fat.NewRow();
            //        row["FileId"] = item.Cells[1].Text;
            //        row["FileType"] = item.Cells[3].Text;
            //        fat.Rows.Add(row);
            //    }


            //    if (rbtnSelectQuote.SelectedValue.ToString() == "")
            //    {
            //        showmsg("Please select Quotation");
            //        rbtnSelectQuote.Focus();
            //        return;
            //    }
            //    else if (grddata.Rows.Count < 3 && txt_jst.Text.Trim() == "")
            //    {
            //        showmsg("Please Enter Justification, due to Attached Quotation is less than 3 vendors");
            //        txt_jst.Focus();
            //        return;
            //    }

            //}


            //DataTable fated = new DataTable();
            //if (grddata.Rows.Count > 0)
            //{
            //    decimal gt = Convert.ToDecimal(ViewState["MaxTotalNFAValue"].ToString());
            //    string[] digits = Regex.Split(rbtnSelectQuote.SelectedItem.ToString(), @"[^0-9\.]+");
            //    List<decimal> numbers = new List<decimal>();
            //    int i = 0;
            //    foreach (GridViewRow item in grddata.Rows)
            //    {
            //        if (item.Cells[4].Text.Trim() != "&nbsp;")
            //        {
            //            decimal gt2 = Convert.ToDecimal(item.Cells[5].Text);
            //            numbers.Add(gt2);
            //        }

            //    }

            //    //if ((Convert.ToDecimal(digits[3]) < gt) && txt_jst.Text.Trim() == "")
            //    //{
            //    //    showmsg("Please Enter Justification, due to selected Quation Amount less than Capex Amount");
            //    //    txt_jst.Focus();
            //    //    return;
            //    //}

            //    if ((Convert.ToDecimal(digits[3]) > gt) && txt_jst.Text.Trim() == "")
            //    {
            //        showmsg("Please Enter Justification, due to selected Quation Amount Higher than Capex Amount");
            //        txt_jst.Focus();
            //        return;
            //    }

            //    decimal mi = numbers.Max();
            //    decimal mx = numbers.Min();
            //    decimal dtn = Convert.ToDecimal(digits[3]);
            //    if (Convert.ToDecimal(digits[3]) > numbers.Max() && txt_jst.Text.Trim() == "")
            //    {
            //        showmsg("Please Enter Justification, due to Higher Quation Amount Selected");
            //        txt_jst.Focus();
            //        return;
            //    }

            //    if (Convert.ToDecimal(digits[3]) >= mi && txt_jst.Text.Trim() == "")
            //    {
            //        showmsg("Please Enter Justification, due to Lowest Quation Available.");
            //        txt_jst.Focus();
            //        return;
            //    }
            //}


            //try
            //{
            //    DataTable tdnew = (DataTable)ViewState["CapexItemLine"];

            //    if (tdnew.Columns.Contains("ID") == false)
            //    {
            //        DataColumn dc = new DataColumn("ID");
            //        dc.AutoIncrement = true;
            //        dc.AutoIncrementSeed = 1;
            //        dc.AutoIncrementStep = 1;
            //        tdnew.Columns.Add(dc);
            //        dc.SetOrdinal(0);
            //    }

            //    for (int i = 0; i <= tdnew.Rows.Count - 1; i++)
            //    {
            //        tdnew.Rows[i]["ID"] = i + 1;
            //    }
            //    string pass = "";
            //    string grd = "";
            //    string lim = "0";

            //    DataTable tdnewVen = (DataTable)ViewState["CapexQuotationItemLine"];
            //    string IRRPaybackV = uploadfile(upldIRRPayback);
            //    string CashOutflowV = uploadfile(upldCashOutflow);

            //    if (IRRPaybackV == "")
            //        IRRPaybackV = hlIRRPayback.ToolTip.Trim().ToString();

            //    if (CashOutflowV == "")
            //        CashOutflowV = hlICashOutflow.ToolTip.Trim().ToString();

            //    string outs = ba.Capex_insert_draft(drp_Atype.SelectedValue.ToString(), txt_Acode.Text.Trim(), drp_budget.SelectedValue.ToString(), txt_pname.Text.Trim(), txt_pdesc.Text.Trim(), "", txt_purpose.Text.Trim(), txt_compdate.Text.Trim(), "", tdnew, ViewState["MaxTotalNFAValue"].ToString(), rbtnSelectQuote.SelectedValue.ToString(), drp_ImportedIndigenous.SelectedValue.ToString(), txt_jst.Text.Trim(), Session["usr"].ToString(), ViewState["GuidValue"].ToString(), ViewState["ReqID"].ToString(), pass, "", grd, "rbtnRequisitionType", lim, "txtEmployeeName", txtIndentID.Text.Trim(), txtBenefit.Text.Trim(), IRRPaybackV, CashOutflowV, txtPaybackPeriodValue.Text.Trim(), txtProjectedCashOutflowValue.Text.Trim(), CFCAmount);

            //    if (outs.Contains("Successfully") == true)
            //    {
            //        string[] digits = Regex.Split(outs.ToString(), @"[^0-9\.]+");
            //        ViewState["ReqID"] = digits[1].ToString();
            //        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("" + outs + "");
            //        var script = string.Format("alert({0});window.location ='CapexmainRequest.aspx';", message);
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            //    }
            //    else
            //    {
            //        showmsg(outs);
            //        return;
            //    }
            //}
            //catch
            //{

            //}






            return View();
        }

        
    }
}
