namespace CapExTSVS.Models1
{

    public class IndentCreate
    {
        //public int IndentID { get; set; }
        //public string ? Company { get; set; }
        //public string ? BU { get; set; }
        //public string ?CapexType { get; set; }
        //public string? LocationWork { get; set; }
        //public string? TypeofWorkDetails { get; set; }

        //// Optional file paths
        //public string ?EnclosureBQQFile { get; set; }
        //public string? EnclosureDrawingFile { get; set; }

        //public decimal RateProposed { get; set; }
        //public string ?BudgetType { get; set; }

        //public DateTime? TentativeStartDate { get; set; }
        //public DateTime? TentativeCompletionDate { get; set; }

        //public string? ProposedContractorName { get; set; }
        //public string? VendorExistingLocation { get; set; }
        //public string? ContractorDetailsAddressGST { get; set; }

        //public int Userid { get; set; }
        //public string? Remarks { get; set; }
        //public string? TagPurchaser { get; set; }
        //public int Tat { get; set; } // Assuming Tat is an integer, adjust if needed





         public  string IndentID { get; set; }
        public  string Company { get; set; }
        public  string BU { get; set; }
        public  string LocatioWork { get; set; }
        public  string TypeofWorkDetails { get; set; }
        public  string EnclosureBQQFile { get; set; }
        public  string EnclosureDrawingFile { get; set; }
        public  decimal? RateProposed { get; set; }
        public  string BudgetType { get; set; }
        public DateTime  TentativeStartDate { get; set; }
        public DateTime  TentativeCompletionDate { get; set; }
        public  string ProposedContractorName { get; set; }
        public  string VendorExistingLocation { get; set; }
        public  string ContractorDetailsAddressGST { get; set; }
        public  string Userid { get; set; }
        public  string CapexType { get; set; }
        public  string Remarks { get; set; }
        public  string TagPurchaser { get; set; }
        public int? Tat { get; set; }


    }
}
