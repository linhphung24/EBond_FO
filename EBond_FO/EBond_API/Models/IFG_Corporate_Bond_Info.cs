namespace EBond_API.Models
{
    public class IFG_Corporate_Bond_Info
    {
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Issuer { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string? BOND_PERIOD { get; set; }
        public int? PERIOD_UNIT { get; set; }
        public int? INTEREST_PERIOD { get; set; }
        public int? INTEREST_PERIOD_UNIT { get; set; }
        public int? INTEREST_TYPE { get; set; }
        public int? INTERESTRATE_TYPE { get; set; }
        public int? INTEREST_PAYMENT_TYPE { get; set; }
        public decimal? TotalListingQtty { get; set; }
        public decimal? Parvalue { get; set; }
    }
}
