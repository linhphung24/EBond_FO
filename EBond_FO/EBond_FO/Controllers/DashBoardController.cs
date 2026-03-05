using EBond_FO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EBond_FO.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly SqlConnection _db;

        public DashBoardController(SqlConnection db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = new List<IFG_Corporate_Bond_Info>();

            const string sql = "SELECT * FROM IFG_Corporate_Bond_Info";

            await _db.OpenAsync();

            await using var cmd = new SqlCommand(sql, _db);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new IFG_Corporate_Bond_Info
                {
                    id                    = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                    BeginString           = reader["BeginString"]?.ToString() ?? "",
                    BodyLength            = reader["BodyLength"]?.ToString() ?? "",
                    MsgType               = reader["MsgType"]?.ToString() ?? "",
                    SenderCompID          = reader["SenderCompID"]?.ToString() ?? "",
                    SendingTime           = reader["SendingTime"]?.ToString() ?? "",
                    Symbol                = reader["Symbol"]?.ToString() ?? "",
                    Name                  = reader["Name"]?.ToString() ?? "",
                    MaISIN                = reader["MaISIN"]?.ToString() ?? "",
                    Tradingdate           = reader["Tradingdate"]?.ToString() ?? "",
                    BoardCode             = reader["BoardCode"]?.ToString() ?? "",
                    SecurityTradingStatus = reader["SecurityTradingStatus"]?.ToString() ?? "",
                    TradingSessionID      = reader["TradingSessionID"]?.ToString() ?? "",
                    TradSesStatus         = reader["TradSesStatus"]?.ToString() ?? "",
                    MaturityDate          = reader["MaturityDate"]?.ToString() ?? "",
                    INTEREST_RATE         = reader["INTEREST_RATE"]?.ToString() ?? "",
                    IssueDate             = reader["IssueDate"]?.ToString() ?? "",
                    BOND_PERIOD           = reader["BOND_PERIOD"]?.ToString() ?? "",
                    PERIOD_UNIT           = reader["PERIOD_UNIT"]?.ToString() ?? "",
                    PERIOD_REMAIN         = reader["PERIOD_REMAIN"]?.ToString() ?? "",
                    INTEREST_TYPE         = reader["INTEREST_TYPE"]?.ToString() ?? "",
                    INTEREST_PERIOD       = reader["INTEREST_PERIOD"]?.ToString() ?? "",
                    INTEREST_PERIOD_UNIT  = reader["INTEREST_PERIOD_UNIT"]?.ToString() ?? "",
                    INTEREST_COUPON_TYPE  = reader["INTEREST_COUPON_TYPE"]?.ToString() ?? "",
                    INTERESTRATE_TYPE     = reader["INTERESTRATE_TYPE"]?.ToString() ?? "",
                    INTEREST_PAYMENT_TYPE = reader["INTEREST_PAYMENT_TYPE"]?.ToString() ?? "",
                    Issuer                = reader["Issuer"]?.ToString() ?? "",
                    TCPH                  = reader["TCPH"]?.ToString() ?? "",
                    Time                  = reader["Time"]?.ToString() ?? "",
                    TotalListingQtty      = reader["TotalListingQtty"]?.ToString() ?? "",
                    DateNo                = reader["DateNo"]?.ToString() ?? "",
                    BasicPrice            = reader["BasicPrice"]?.ToString() ?? "",
                    FloorPice             = reader["FloorPice"]?.ToString() ?? "",
                    CeilingPice           = reader["CeilingPice"]?.ToString() ?? "",
                    FloorPriceOut         = reader["FloorPriceOut"]?.ToString() ?? "",
                    CeilingPriceOut       = reader["CeilingPriceOut"]?.ToString() ?? "",
                    FloorPriceRep         = reader["FloorPriceRep"]?.ToString() ?? "",
                    CeilingPriceRep       = reader["CeilingPriceRep"]?.ToString() ?? "",
                    Parvalue              = reader["Parvalue"]?.ToString() ?? "",
                    MatchPrice            = reader["MatchPrice"]?.ToString() ?? "",
                    MatchQtty             = reader["MatchQtty"]?.ToString() ?? "",
                    OpenPrice             = reader["OpenPrice"]?.ToString() ?? "",
                    ClosePice             = reader["ClosePice"]?.ToString() ?? "",
                    TotalVolumeTraded     = reader["TotalVolumeTraded"]?.ToString() ?? "",
                    TotalValueTraded      = reader["TotalValueTraded"]?.ToString() ?? "",
                    MidPx                 = reader["MidPx"]?.ToString() ?? "",
                    CurrentPrice          = reader["CurrentPrice"]?.ToString() ?? "",
                    CurrentQtty           = reader["CurrentQtty"]?.ToString() ?? "",
                    HighestPice           = reader["HighestPice"]?.ToString() ?? "",
                    LowestPrice           = reader["LowestPrice"]?.ToString() ?? "",
                    NM_TotalTradedQtty    = reader["NM_TotalTradedQtty"]?.ToString() ?? "",
                    NM_TotalTradedValue   = reader["NM_TotalTradedValue"]?.ToString() ?? "",
                    PT_MatchQtty          = reader["PT_MatchQtty"]?.ToString() ?? "",
                    PT_MatchPrice         = reader["PT_MatchPrice"]?.ToString() ?? "",
                    PT_MaxQtty            = reader["PT_MaxQtty"]?.ToString() ?? "",
                    PT_MaxPrice           = reader["PT_MaxPrice"]?.ToString() ?? "",
                    PT_MinQtty            = reader["PT_MinQtty"]?.ToString() ?? "",
                    PT_MinPrice           = reader["PT_MinPrice"]?.ToString() ?? "",
                    PT_TotalTradedQtty    = reader["PT_TotalTradedQtty"]?.ToString() ?? "",
                    PT_TotalTradedValue   = reader["PT_TotalTradedValue"]?.ToString() ?? "",
                    Repos_TotalTradedQtty = reader["Repos_TotalTradedQtty"]?.ToString() ?? "",
                    Repos_TotalTradedValue= reader["Repos_TotalTradedValue"]?.ToString() ?? "",
                    RemainForeignQtty     = reader["RemainForeignQtty"]?.ToString() ?? "",
                    PT_BestBidQtty        = reader["PT_BestBidQtty"]?.ToString() ?? "",
                    PT_BestBidPrice       = reader["PT_BestBidPrice"]?.ToString() ?? "",
                    PT_BestOfferQtty      = reader["PT_BestOfferQtty"]?.ToString() ?? "",
                    PT_BestOfferPrice     = reader["PT_BestOfferPrice"]?.ToString() ?? "",
                    PT_TotalBidQtty       = reader["PT_TotalBidQtty"]?.ToString() ?? "",
                    PT_TotalOfferQtty     = reader["PT_TotalOfferQtty"]?.ToString() ?? "",
                    DTGDTP                = reader["DTGDTP"]?.ToString() ?? "",
                    FOREIGN_RATE          = reader["FOREIGN_RATE"]?.ToString() ?? "",
                    CreatedOn             = reader["CreatedOn"]?.ToString() ?? "",
                    UpdatedOn             = reader["UpdatedOn"]?.ToString() ?? "",
                    CreatedBy             = reader["CreatedBy"]?.ToString() ?? "",
                    UpdatedBy             = reader["UpdatedBy"]?.ToString() ?? "",
                    IPAddress             = reader["IPAddress"]?.ToString() ?? "",
                });
            }

            return View(list);
        }
    }
}
