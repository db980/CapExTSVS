using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapExTSVS.Models;

public partial class CapExTsContext : DbContext
{
    public CapExTsContext()
    {
    }

    public CapExTsContext(DbContextOptions<CapExTsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aa1> Aa1s { get; set; }

    public virtual DbSet<CapexComBumaster> CapexComBumasters { get; set; }

    public virtual DbSet<CapexConversation> CapexConversations { get; set; }

    public virtual DbSet<CapexDrawingAttachment> CapexDrawingAttachments { get; set; }

    public virtual DbSet<CapexEmployeeCompanyMapping> CapexEmployeeCompanyMappings { get; set; }

    public virtual DbSet<CapexEmployeePurposeLimit> CapexEmployeePurposeLimits { get; set; }

    public virtual DbSet<CapexExpBudgetMaster> CapexExpBudgetMasters { get; set; }

    public virtual DbSet<CapexFAttachment> CapexFAttachments { get; set; }

    public virtual DbSet<CapexInitRecipient> CapexInitRecipients { get; set; }

    public virtual DbSet<CapexMaster> CapexMasters { get; set; }

    public virtual DbSet<CapexMaster101023> CapexMaster101023s { get; set; }

    public virtual DbSet<CapexMaster231123> CapexMaster231123s { get; set; }

    public virtual DbSet<CapexMasterItem> CapexMasterItems { get; set; }

    public virtual DbSet<CapexMasterItemVendorQuotation> CapexMasterItemVendorQuotations { get; set; }

    public virtual DbSet<CapexMasterLog> CapexMasterLogs { get; set; }

    public virtual DbSet<CapexNature> CapexNatures { get; set; }

    public virtual DbSet<CapexPayApprovalCat> CapexPayApprovalCats { get; set; }

    public virtual DbSet<CapexPayApprovalCatEmpMapping> CapexPayApprovalCatEmpMappings { get; set; }

    public virtual DbSet<CapexPayApprovalCatEmpMapping03102023> CapexPayApprovalCatEmpMapping03102023s { get; set; }

    public virtual DbSet<CapexPlant> CapexPlants { get; set; }

    public virtual DbSet<CapexPurchReqMapping> CapexPurchReqMappings { get; set; }

    public virtual DbSet<CapexReturnRejectRemark> CapexReturnRejectRemarks { get; set; }

    public virtual DbSet<CapexRightsMaster> CapexRightsMasters { get; set; }

    public virtual DbSet<CapexStatus> CapexStatuses { get; set; }

    public virtual DbSet<CapexTypeMaster> CapexTypeMasters { get; set; }

    public virtual DbSet<CapexUserRightsMaster> CapexUserRightsMasters { get; set; }

    public virtual DbSet<CapexViewOnlyEmpRoleMapping> CapexViewOnlyEmpRoleMappings { get; set; }

    public virtual DbSet<IndId> IndIds { get; set; }

    public virtual DbSet<IndentMaster> IndentMasters { get; set; }

    public virtual DbSet<IndentMaster09102023> IndentMaster09102023s { get; set; }

    public virtual DbSet<IndentMasterLog> IndentMasterLogs { get; set; }

    public virtual DbSet<IndentPayApprovalCatEmpMapping> IndentPayApprovalCatEmpMappings { get; set; }

    public virtual DbSet<Temp> Temps { get; set; }

    public virtual DbSet<TempDtLineItem001> TempDtLineItem001s { get; set; }

    public virtual DbSet<Tempcap03> Tempcap03s { get; set; }

    public virtual DbSet<TestCapexPayApprovalCatEmpMapping> TestCapexPayApprovalCatEmpMappings { get; set; }

    public virtual DbSet<UserMasterTemp> UserMasterTemps { get; set; }

    public virtual DbSet<VendorMaster> VendorMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-H2DSLGF;Database=CapExTS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aa1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AA1");

            entity.Property(e => e.PlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PlantDes)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapexComBumaster>(entity =>
        {
            entity.HasKey(e => new { e.CompCode, e.Bu });

            entity.ToTable("Capex_ComBUMaster");

            entity.Property(e => e.CompCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Comp_code");
            entity.Property(e => e.Bu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BU");
            entity.Property(e => e.Des)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IndId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IndID");
        });

        modelBuilder.Entity<CapexConversation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexConversation");

            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.ConId).ValueGeneratedOnAdd();
            entity.Property(e => e.PostedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexDrawingAttachment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Capex_drawing_attachment");

            entity.Property(e => e.AssignedDate).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CapexId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CapexID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CreatedBY");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DrawingCapexName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FileCode)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Fileid)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("fileid");
            entity.Property(e => e.Filepth)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("filepth");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdartedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UpdatedBY");
        });

        modelBuilder.Entity<CapexEmployeeCompanyMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Capex_EmployeeCompanyMapping");

            entity.Property(e => e.CompanyIds).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpCode).HasMaxLength(20);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedBy).HasMaxLength(20);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexEmployeePurposeLimit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexEmployeePurposeLimit");

            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Grid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexExpBudgetMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Capex_ExpBudgetMaster");

            entity.Property(e => e.Btype)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Etype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EType");
            entity.Property(e => e.St).HasColumnName("st");
        });

        modelBuilder.Entity<CapexFAttachment>(entity =>
        {
            entity.HasKey(e => e.Fileid);

            entity.ToTable("Capex_f_attachment");

            entity.HasIndex(e => new { e.Fileid, e.Filepth, e.FileCode, e.Userid, e.FileType, e.CapexId, e.QuotationAmount }, "NonClusteredIndex-20201016-114920");

            entity.Property(e => e.Fileid)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("fileid");
            entity.Property(e => e.CapexId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CapexID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Delivery)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FileCode)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Filepth)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("filepth");
            entity.Property(e => e.Fright)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InstallationCost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Moddate)
                .HasColumnType("datetime")
                .HasColumnName("moddate");
            entity.Property(e => e.PaymentTerm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuotationAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Userid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userid");
        });

        modelBuilder.Entity<CapexInitRecipient>(entity =>
        {
            entity.HasKey(e => new { e.RequestorCode, e.RecipientsCode, e.IsActive });

            entity.ToTable("Capex_InitRecipients");

            entity.HasIndex(e => new { e.RequestorCode, e.RecipientsCode, e.IsActive }, "NonClusteredIndex-20210222-175950");

            entity.Property(e => e.RequestorCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RecipientsCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.MappedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexMaster>(entity =>
        {
            entity.HasKey(e => e.RequestNo);

            entity.ToTable("CapexMaster", tb => tb.HasTrigger("trg_CapexMaster"));

            entity.HasIndex(e => new { e.RequestNo, e.CapexType, e.Pname, e.Status, e.DepartmentLvl1, e.DepartmentLvl2, e.FinanceLvl3, e.FinancefLvl4, e.FinanceLvl5, e.MdLvl6, e.IsbugtchkStatus, e.BugtRstatus, e.BugtRstatusBy, e.BugtRstatusDate }, "NonClusteredIndex-20190103-131309");

            entity.Property(e => e.AmountPerUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Assettype)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Benefit)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BugtRstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bugtRStatus");
            entity.Property(e => e.BugtRstatusBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtRStatusBy");
            entity.Property(e => e.BugtRstatusDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtRStatusDate");
            entity.Property(e => e.BugtchkAssignBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignBy");
            entity.Property(e => e.BugtchkAssignedDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtchkAssignedDate");
            entity.Property(e => e.BugtchkAssignto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignto");
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CapitalExpenseAsset)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CfcAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CwipcreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CWIPCreatedDate");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl1Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_1_Date");
            entity.Property(e => e.DepartmentLvl1Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1_Remarks");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.DepartmentLvl2Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_2_Date");
            entity.Property(e => e.DepartmentLvl2Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2_Remarks");
            entity.Property(e => e.EdateCompletion).HasColumnType("datetime");
            entity.Property(e => e.Empcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empcode");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl3Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_3_Date");
            entity.Property(e => e.FinanceLvl3Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3_Remarks");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinanceLvl5Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_5_Date");
            entity.Property(e => e.FinanceLvl5Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5_Remarks");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.FinancefLvl4Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCEF_Lvl_4_Date");
            entity.Property(e => e.FinancefLvl4Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4_Remarks");
            entity.Property(e => e.FixedAssetsType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Grid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImportedIndigenous)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.IrrpaybackPeriod)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IRRPaybackPeriod");
            entity.Property(e => e.IrrpaybackPeriodValue)
                .HasMaxLength(500)
                .HasColumnName("IRRPaybackPeriodValue");
            entity.Property(e => e.IsbugtchkStatus).HasColumnName("isbugtchkStatus");
            entity.Property(e => e.MaxLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.MdLvl6Date)
                .HasColumnType("datetime")
                .HasColumnName("MD_Lvl_6_Date");
            entity.Property(e => e.MdLvl6Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6_Remarks");
            entity.Property(e => e.MiscExpenses).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NoofUnits).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OldAssetCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pdescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PDescription");
            entity.Property(e => e.Pname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PName");
            entity.Property(e => e.ProjectedCashOutflow)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProjectedCashOutflowValue).HasMaxLength(500);
            entity.Property(e => e.PurchaseLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SelectQuote)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalValueInInr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalValueInINR");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorJustification)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapexMaster101023>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexMaster101023");

            entity.Property(e => e.AmountPerUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Assettype)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Benefit)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BugtRstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bugtRStatus");
            entity.Property(e => e.BugtRstatusBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtRStatusBy");
            entity.Property(e => e.BugtRstatusDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtRStatusDate");
            entity.Property(e => e.BugtchkAssignBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignBy");
            entity.Property(e => e.BugtchkAssignedDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtchkAssignedDate");
            entity.Property(e => e.BugtchkAssignto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignto");
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CapitalExpenseAsset)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CwipcreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CWIPCreatedDate");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl1Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_1_Date");
            entity.Property(e => e.DepartmentLvl1Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1_Remarks");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.DepartmentLvl2Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_2_Date");
            entity.Property(e => e.DepartmentLvl2Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2_Remarks");
            entity.Property(e => e.EdateCompletion).HasColumnType("datetime");
            entity.Property(e => e.Empcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empcode");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl3Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_3_Date");
            entity.Property(e => e.FinanceLvl3Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3_Remarks");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinanceLvl5Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_5_Date");
            entity.Property(e => e.FinanceLvl5Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5_Remarks");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.FinancefLvl4Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCEF_Lvl_4_Date");
            entity.Property(e => e.FinancefLvl4Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4_Remarks");
            entity.Property(e => e.FixedAssetsType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Grid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImportedIndigenous)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.IrrpaybackPeriod)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IRRPaybackPeriod");
            entity.Property(e => e.IsbugtchkStatus).HasColumnName("isbugtchkStatus");
            entity.Property(e => e.MaxLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.MdLvl6Date)
                .HasColumnType("datetime")
                .HasColumnName("MD_Lvl_6_Date");
            entity.Property(e => e.MdLvl6Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6_Remarks");
            entity.Property(e => e.MiscExpenses).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NoofUnits).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OldAssetCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pdescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PDescription");
            entity.Property(e => e.Pname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PName");
            entity.Property(e => e.ProjectedCashOutflow)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestNo).ValueGeneratedOnAdd();
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SelectQuote)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalValueInInr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalValueInINR");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorJustification)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapexMaster231123>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexMaster231123");

            entity.Property(e => e.AmountPerUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Assettype)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Benefit)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BugtRstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bugtRStatus");
            entity.Property(e => e.BugtRstatusBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtRStatusBy");
            entity.Property(e => e.BugtRstatusDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtRStatusDate");
            entity.Property(e => e.BugtchkAssignBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignBy");
            entity.Property(e => e.BugtchkAssignedDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtchkAssignedDate");
            entity.Property(e => e.BugtchkAssignto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignto");
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CapitalExpenseAsset)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CfcAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CwipcreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CWIPCreatedDate");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl1Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_1_Date");
            entity.Property(e => e.DepartmentLvl1Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1_Remarks");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.DepartmentLvl2Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_2_Date");
            entity.Property(e => e.DepartmentLvl2Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2_Remarks");
            entity.Property(e => e.EdateCompletion).HasColumnType("datetime");
            entity.Property(e => e.Empcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empcode");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl3Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_3_Date");
            entity.Property(e => e.FinanceLvl3Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3_Remarks");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinanceLvl5Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_5_Date");
            entity.Property(e => e.FinanceLvl5Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5_Remarks");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.FinancefLvl4Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCEF_Lvl_4_Date");
            entity.Property(e => e.FinancefLvl4Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4_Remarks");
            entity.Property(e => e.FixedAssetsType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Grid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImportedIndigenous)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.IrrpaybackPeriod)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IRRPaybackPeriod");
            entity.Property(e => e.IrrpaybackPeriodValue)
                .HasMaxLength(500)
                .HasColumnName("IRRPaybackPeriodValue");
            entity.Property(e => e.IsbugtchkStatus).HasColumnName("isbugtchkStatus");
            entity.Property(e => e.MaxLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.MdLvl6Date)
                .HasColumnType("datetime")
                .HasColumnName("MD_Lvl_6_Date");
            entity.Property(e => e.MdLvl6Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6_Remarks");
            entity.Property(e => e.MiscExpenses).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NoofUnits).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OldAssetCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pdescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PDescription");
            entity.Property(e => e.Pname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PName");
            entity.Property(e => e.ProjectedCashOutflow)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProjectedCashOutflowValue).HasMaxLength(500);
            entity.Property(e => e.PurchaseLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestNo).ValueGeneratedOnAdd();
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SelectQuote)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalValueInInr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalValueInINR");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorJustification)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapexMasterItem>(entity =>
        {
            entity.HasKey(e => e.Cmiid);

            entity.ToTable("CapexMasterItem");

            entity.HasIndex(e => new { e.CapexId, e.LineItem, e.ItemName, e.CapexNature, e.LocationCode, e.CostCenter, e.Cwip, e.CwipInsertedBy, e.InternalOrder, e.InternalOrderInsertedBy, e.CreatedBy, e.UpdatedBy }, "NonClusteredIndex-20210222-175703");

            entity.Property(e => e.Cmiid).HasColumnName("CMIID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.CapexNature)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CostCenter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Cwip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CWIP");
            entity.Property(e => e.CwipDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CWIP_Description");
            entity.Property(e => e.CwipInsertedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CWIP_InsertedBy");
            entity.Property(e => e.CwipInsertedDate)
                .HasColumnType("datetime")
                .HasColumnName("CWIP_InsertedDate");
            entity.Property(e => e.InternalOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InternalOrderDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("InternalOrder_Description");
            entity.Property(e => e.InternalOrderInsertedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("InternalOrder_InsertedBy");
            entity.Property(e => e.InternalOrderInsertedDate)
                .HasColumnType("datetime")
                .HasColumnName("InternalOrder_InsertedDate");
            entity.Property(e => e.ItemName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LineItem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PerUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UOM");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexMasterItemVendorQuotation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexMasterItem_VendorQuotation");

            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Cvqid)
                .ValueGeneratedOnAdd()
                .HasColumnName("CVQID");
            entity.Property(e => e.FileCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FinalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InitialAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InitialRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ItemName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LineItem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalWithTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UOM");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vendor_Code");
        });

        modelBuilder.Entity<CapexMasterLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexMaster_log");

            entity.Property(e => e.AmountPerUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Assettype)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Benefit)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BugtRstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bugtRStatus");
            entity.Property(e => e.BugtRstatusBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtRStatusBy");
            entity.Property(e => e.BugtRstatusDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtRStatusDate");
            entity.Property(e => e.BugtchkAssignBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignBy");
            entity.Property(e => e.BugtchkAssignedDate)
                .HasColumnType("datetime")
                .HasColumnName("bugtchkAssignedDate");
            entity.Property(e => e.BugtchkAssignto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bugtchkAssignto");
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CapitalExpenseAsset)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CwipcreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CWIPCreatedDate");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl1Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_1_Date");
            entity.Property(e => e.DepartmentLvl1Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1_Remarks");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.DepartmentLvl2Date)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTMENT_Lvl_2_Date");
            entity.Property(e => e.DepartmentLvl2Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2_Remarks");
            entity.Property(e => e.EdateCompletion).HasColumnType("datetime");
            entity.Property(e => e.Empcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empcode");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl3Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_3_Date");
            entity.Property(e => e.FinanceLvl3Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3_Remarks");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinanceLvl5Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCE_Lvl_5_Date");
            entity.Property(e => e.FinanceLvl5Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5_Remarks");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.FinancefLvl4Date)
                .HasColumnType("datetime")
                .HasColumnName("FINANCEF_Lvl_4_Date");
            entity.Property(e => e.FinancefLvl4Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4_Remarks");
            entity.Property(e => e.FixedAssetsType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Grid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImportedIndigenous)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.IrrpaybackPeriod)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IRRPaybackPeriod");
            entity.Property(e => e.IsbugtchkStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isbugtchkStatus");
            entity.Property(e => e.LogId)
                .ValueGeneratedOnAdd()
                .HasColumnName("LogID");
            entity.Property(e => e.LoggedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MaxLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.MdLvl6Date)
                .HasColumnType("datetime")
                .HasColumnName("MD_Lvl_6_Date");
            entity.Property(e => e.MdLvl6Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6_Remarks");
            entity.Property(e => e.MiscExpenses).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NoofUnits).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OldAssetCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pdescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PDescription");
            entity.Property(e => e.Pname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PName");
            entity.Property(e => e.ProjectedCashOutflow)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SelectQuote)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalValueInInr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalValueInINR");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorJustification)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapexNature>(entity =>
        {
            entity.HasKey(e => e.Cnid);

            entity.ToTable("CapexNature");

            entity.Property(e => e.Cnid)
                .ValueGeneratedNever()
                .HasColumnName("CNID");
            entity.Property(e => e.CapexNature1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CapexNature");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexPayApprovalCat>(entity =>
        {
            entity.HasKey(e => e.Cpacid);

            entity.ToTable("CapexPayApprovalCat");

            entity.Property(e => e.Cpacid).HasColumnName("CPACID");
            entity.Property(e => e.AmountForm).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.AmountTo).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.IsSpecialCategory).HasComment("0=Default,1=Customer Funded Capex");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Capex).WithMany(p => p.CapexPayApprovalCats)
                .HasForeignKey(d => d.CapexId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CapexPayA__Capex__17036CC0");
        });

        modelBuilder.Entity<CapexPayApprovalCatEmpMapping>(entity =>
        {
            entity.HasKey(e => new { e.CapexId, e.Empcode }).HasName("PK__CapexEMP__319559AF29BC1B69");

            entity.ToTable("CapexPayApprovalCat_EMP_Mapping");

            entity.HasIndex(e => new { e.CapexId, e.Empcode, e.DepartmentLvl1, e.DepartmentLvl2, e.FinanceLvl3, e.FinancefLvl4, e.FinanceLvl5, e.MdLvl6 }, "NonClusteredIndex-20210222-175853");

            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.Empcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMPCode");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.IsSpecialCategory).HasComment("0=Default,1=CFC Capex Customer Funded");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Capex).WithMany(p => p.CapexPayApprovalCatEmpMappings)
                .HasForeignKey(d => d.CapexId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CapexEMP___Capex__47A6A41B");
        });

        modelBuilder.Entity<CapexPayApprovalCatEmpMapping03102023>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexPayApprovalCat_EMP_Mapping03102023");

            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.Empcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMPCode");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexPlant>(entity =>
        {
            entity.HasKey(e => e.PlantCode).HasName("PK__Plant__55ADBFFE8D4247B8");

            entity.ToTable("CapexPlant");

            entity.Property(e => e.PlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ComCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Com_Code");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.PlantDes)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PostlCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CapexPurchReqMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexPurchReqMapping");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.PurchaseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RequisitionCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexReturnRejectRemark>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Capex_ReturnRejectRemarks");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.RemarkFrom).HasMaxLength(50);
            entity.Property(e => e.RemarkType).HasMaxLength(50);
        });

        modelBuilder.Entity<CapexRightsMaster>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__CapexRig__CAF055CA79782F27");

            entity.ToTable("CapexRightsMaster");

            entity.Property(e => e.Rid).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.Rname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RName");
        });

        modelBuilder.Entity<CapexStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CapexStatus");

            entity.Property(e => e.CapexStatus1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CapexStatus");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isActive");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexTypeMaster>(entity =>
        {
            entity.HasKey(e => e.Ctid);

            entity.ToTable("CapexTypeMaster");

            entity.Property(e => e.Ctid).HasColumnName("CTID");
            entity.Property(e => e.Bu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BU");
            entity.Property(e => e.BudgetType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CapexType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CompCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Comp_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Des)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.ReqType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexUserRightsMaster>(entity =>
        {
            entity.HasKey(e => new { e.Rid, e.EmpCode }).HasName("PK__CapexUse__6D2AD1B6483A9F43");

            entity.ToTable("CapexUser_RightsMaster");

            entity.Property(e => e.EmpCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Mid).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CapexViewOnlyEmpRoleMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Capex_ViewOnlyEMP_RoleMapping");

            entity.Property(e => e.CapexCreatedById)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Capex_CreatedBy_ID");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMP_Code");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.MappedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MappedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Mapped_Date");
        });

        modelBuilder.Entity<IndId>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IndID");

            entity.Property(e => e.BuLvl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Empcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMPCode");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IndId1).HasColumnName("IndID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.RmLvl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<IndentMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IndentMaster", tb => tb.HasTrigger("trg_IndentMaster"));

            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Bu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BU");
            entity.Property(e => e.BuLvl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl");
            entity.Property(e => e.BuLvlDate)
                .HasColumnType("datetime")
                .HasColumnName("BU_LvlDate");
            entity.Property(e => e.BuLvlRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl_Remarks");
            entity.Property(e => e.BudgetType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContractorDetailsAddressGst)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ContractorDetailsAddressGST");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnclosureBqqfile)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EnclosureBQQFile");
            entity.Property(e => e.EnclosureDrawingFile)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IndentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IndentID");
            entity.Property(e => e.IndentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocatioWork)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProposedContractorName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RateProposed).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(1000);
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RmLvl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl");
            entity.Property(e => e.RmLvlDate)
                .HasColumnType("datetime")
                .HasColumnName("RM_LvlDate");
            entity.Property(e => e.RmLvlRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl_Remarks");
            entity.Property(e => e.TagPurchaser).HasMaxLength(200);
            entity.Property(e => e.Tat).HasColumnName("TAT");
            entity.Property(e => e.TentativeCompletionDate).HasColumnType("datetime");
            entity.Property(e => e.TentativeStartDate).HasColumnType("datetime");
            entity.Property(e => e.TypeofWorkDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorExistingLocation)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IndentMaster09102023>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IndentMaster09102023");

            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Bu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BU");
            entity.Property(e => e.BuLvl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl");
            entity.Property(e => e.BuLvlDate)
                .HasColumnType("datetime")
                .HasColumnName("BU_LvlDate");
            entity.Property(e => e.BuLvlRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl_Remarks");
            entity.Property(e => e.BudgetType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContractorDetailsAddressGst)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ContractorDetailsAddressGST");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnclosureBqqfile)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EnclosureBQQFile");
            entity.Property(e => e.EnclosureDrawingFile)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IndentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IndentID");
            entity.Property(e => e.IndentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocatioWork)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProposedContractorName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RateProposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(1000);
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RmLvl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl");
            entity.Property(e => e.RmLvlDate)
                .HasColumnType("datetime")
                .HasColumnName("RM_LvlDate");
            entity.Property(e => e.RmLvlRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl_Remarks");
            entity.Property(e => e.TentativeCompletionDate).HasColumnType("datetime");
            entity.Property(e => e.TentativeStartDate).HasColumnType("datetime");
            entity.Property(e => e.TypeofWorkDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorExistingLocation)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IndentMasterLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IndentMaster_log");

            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Bu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BU");
            entity.Property(e => e.BuLvl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl");
            entity.Property(e => e.BuLvlDate)
                .HasColumnType("datetime")
                .HasColumnName("BU_LvlDate");
            entity.Property(e => e.BuLvlRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl_Remarks");
            entity.Property(e => e.CapexType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContractorDetailsAddressGst)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ContractorDetailsAddressGST");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnclosureBqqfile)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EnclosureBQQFile");
            entity.Property(e => e.EnclosureDrawingFile)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.LocatioWork)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LogId)
                .ValueGeneratedOnAdd()
                .HasColumnName("LogID");
            entity.Property(e => e.LoggedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProposedContractorName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RateProposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RejectedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RejectedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(1000);
            entity.Property(e => e.ReturnedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RmLvl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl");
            entity.Property(e => e.RmLvlDate)
                .HasColumnType("datetime")
                .HasColumnName("RM_LvlDate");
            entity.Property(e => e.RmLvlRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl_Remarks");
            entity.Property(e => e.TagPurchaser).HasMaxLength(200);
            entity.Property(e => e.TentativeCompletionDate).HasColumnType("datetime");
            entity.Property(e => e.TentativeStartDate).HasColumnType("datetime");
            entity.Property(e => e.TypeofWorkDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VendorExistingLocation)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IndentPayApprovalCatEmpMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IndentPayApprovalCat_EMP_Mapping");

            entity.Property(e => e.BuLvl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BU_Lvl");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Empcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMPCode");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IndId).HasColumnName("IndID");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.RmLvl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RM_Lvl");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Temp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp");

            entity.Property(e => e.ChasisNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CHASIS_NUMBER");
            entity.Property(e => e.CreationDate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.CustomerTrxId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_TRX_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.EngineNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENGINE_NUMBER");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE");
            entity.Property(e => e.LineNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LINE_NUMBER");
            entity.Property(e => e.OrgId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ORG_ID");
            entity.Property(e => e.OrgName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ORG_NAME");
            entity.Property(e => e.Quantity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("QUANTITY");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.TrxDate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TRX_DATE");
            entity.Property(e => e.TrxNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TRX_NUMBER");
            entity.Property(e => e.UnitPrice)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UNIT_PRICE");
            entity.Property(e => e.UomCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UOM_CODE");
        });

        modelBuilder.Entity<TempDtLineItem001>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp_dtLineItem001");

            entity.Property(e => e.Categories)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.ItemName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Quantity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxRate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Uom)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<Tempcap03>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tempcap03");

            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
        });

        modelBuilder.Entity<TestCapexPayApprovalCatEmpMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test_CapexPayApprovalCat_EMP_Mapping");

            entity.Property(e => e.CapexId).HasColumnName("CapexID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentLvl1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_1");
            entity.Property(e => e.DepartmentLvl2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_Lvl_2");
            entity.Property(e => e.Empcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMPCode");
            entity.Property(e => e.FinanceLvl3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_3");
            entity.Property(e => e.FinanceLvl5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCE_Lvl_5");
            entity.Property(e => e.FinancefLvl4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FINANCEF_Lvl_4");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MdLvl6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MD_Lvl_6");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserMasterTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserMaster_Temp");

            entity.Property(e => e.EmpCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empCode");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<VendorMaster>(entity =>
        {
            entity.HasKey(e => e.VendorCode).HasName("PK__Vendor_M__3610B079622AA7B6");

            entity.ToTable("Vendor_Master");

            entity.Property(e => e.VendorCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Vendor_Code");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CompanyCode).HasMaxLength(10);
            entity.Property(e => e.ContactPersonContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_Person_Contact_Number");
            entity.Property(e => e.ContactPersonEmailAddress)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Contact_Person_Email_Address");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Contact_Person_Name");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Create_Date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Created_By");
            entity.Property(e => e.District)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirmContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm_Contact_Number");
            entity.Property(e => e.FirmEmailAddress)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Firm_Email_Address");
            entity.Property(e => e.FirmName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Firm_Name");
            entity.Property(e => e.Gst)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PinCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pin_Code");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Updated_By");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });
        modelBuilder.HasSequence("Capex_TransFileIdSequence").HasMin(0L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
