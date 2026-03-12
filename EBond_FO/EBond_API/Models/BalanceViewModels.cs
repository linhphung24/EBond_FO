namespace EBond_API.Models
{
    public class BalanceViewModels
    {
        public string?  WorkingDate          { get; set; }
        public DateTime? BusinessDate        { get; set; }
        public string?  CustodyID            { get; set; }
        public string?  Name                 { get; set; }
        public string?  IDNumber             { get; set; }
        public DateTime? IDIssueDate         { get; set; }
        public string?  Address              { get; set; }
        public string?  SMSNumber            { get; set; }
        public string?  Email                { get; set; }
        public string?  AEID                 { get; set; }
        public decimal? CASH                 { get; set; }
        public decimal? CashAvailble         { get; set; }
        public decimal? CashVCB              { get; set; }
        public decimal? Debit                { get; set; }
        public decimal? Block                { get; set; }
        public decimal? Unblock              { get; set; }
        public decimal? CashReceiving        { get; set; }
        public decimal? BuyMatchValue        { get; set; }
        public decimal? SellMatchValue       { get; set; }
        public decimal? BuyPendingValue      { get; set; }
        public decimal? Free                 { get; set; }
        public decimal? FeeVSD               { get; set; }
        public decimal? FeeVSDPending        { get; set; }
        public decimal? InterestAtm          { get; set; }
        public decimal? RightAtm             { get; set; }
        public decimal? NonTermRateTPRL      { get; set; }
        public decimal? NonTermAmountTPRL    { get; set; }
    }
}
