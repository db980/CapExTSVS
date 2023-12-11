using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexMaster101023
{
    public int RequestNo { get; set; }

    public string? Assettype { get; set; }

    public string? OldAssetCode { get; set; }

    public string? CapexType { get; set; }

    public string? Empcode { get; set; }

    public string? Grid { get; set; }

    public string? ReqType { get; set; }

    public decimal? MaxLimit { get; set; }

    public string? FixedAssetsType { get; set; }

    public string? Pname { get; set; }

    public string? Pdescription { get; set; }

    public string? CapitalExpenseAsset { get; set; }

    public string? Purpose { get; set; }

    public DateTime? EdateCompletion { get; set; }

    public string? PurchaseLocation { get; set; }

    public decimal? AmountPerUnit { get; set; }

    public decimal? NoofUnits { get; set; }

    public decimal? TotalValueInInr { get; set; }

    public string? SelectQuote { get; set; }

    public string? ImportedIndigenous { get; set; }

    public string? VendorJustification { get; set; }

    public int? Status { get; set; }

    public string? DepartmentLvl1 { get; set; }

    public DateTime? DepartmentLvl1Date { get; set; }

    public string? DepartmentLvl1Remarks { get; set; }

    public string? DepartmentLvl2 { get; set; }

    public DateTime? DepartmentLvl2Date { get; set; }

    public string? DepartmentLvl2Remarks { get; set; }

    public string? FinanceLvl3 { get; set; }

    public DateTime? FinanceLvl3Date { get; set; }

    public string? FinanceLvl3Remarks { get; set; }

    public string? FinancefLvl4 { get; set; }

    public DateTime? FinancefLvl4Date { get; set; }

    public string? FinancefLvl4Remarks { get; set; }

    public string? FinanceLvl5 { get; set; }

    public DateTime? FinanceLvl5Date { get; set; }

    public string? FinanceLvl5Remarks { get; set; }

    public string? MdLvl6 { get; set; }

    public DateTime? MdLvl6Date { get; set; }

    public string? MdLvl6Remarks { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? RejectedBy { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? RejectedRemarks { get; set; }

    public string? ReturnedBy { get; set; }

    public DateTime? ReturnedDate { get; set; }

    public string? ReturnedRemarks { get; set; }

    public decimal? MiscExpenses { get; set; }

    public string? BugtchkAssignto { get; set; }

    public DateTime? BugtchkAssignedDate { get; set; }

    public string? BugtchkAssignBy { get; set; }

    public bool IsbugtchkStatus { get; set; }

    public string? BugtRstatus { get; set; }

    public string? BugtRstatusBy { get; set; }

    public DateTime? BugtRstatusDate { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? CwipcreatedDate { get; set; }

    public int? IndentId { get; set; }

    public string? Benefit { get; set; }

    public string? IrrpaybackPeriod { get; set; }

    public string? ProjectedCashOutflow { get; set; }
}
