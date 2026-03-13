namespace EBond_API.Models
{
    public class OrderModels
    {
        public int id { get; set; }
        /// <summary>
        /// ID lệnh gốc
        /// </summary>
        public int reforderid { get; set; }
        /// <summary>
        /// Trạng thái lệnh gốc
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Số lượng lệnh gốc
        /// </summary>
        public int refqtty { get; set; }
        /// <summary>
        /// Giá lệnh gốc
        /// </summary>
        public decimal refprice { get; set; }
        public string requestId { get; set; }
        public string rootorderid { get; set; }
        public string orgorderid { get; set; }
        public string custodycd { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public string LoginID { get; set; }
        public string Symbol { get; set; }
        public decimal price { get; set; }
        public int qtty { get; set; }
        public string side { get; set; }
        public string side_code { get; set; }
        public string OrderType { get; set; }
        public string oodstatus { get; set; }
        public string Channel { get; set; }
        public string OrderTypeFIX { get; set; }
        public string OrdType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 TotalTrade { get; set; }
        public decimal TotalTradedValue { get; set; }
        public string BICCODE { get; set; }
        public string MsgType { get; set; }
        public string DEPOSITID { get; set; }
        public decimal INTEREST_RATE { get; set; }
        public decimal PERIOD_REMAIN { get; set; }
        public decimal BasicPrice { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime MaturityDate { get; set; }
        /// <summary>
        /// Lệnh ẩn danh
        /// </summary>
        public bool Invisible { get; set; }
        public string PaymentType { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime txdate { get; set; }
        public string BoardCode { get; set; }
        public string BrockerSet { get; set; }
        public string ipaddress { get; set; }

        public string orderidmatch { get; set; }
        public string custodycd_depositid { get; set; }
        public string RemarkError { get; set; }
        public string UpdatedBy { get; set; }
    }
}
