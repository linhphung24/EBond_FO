using Dapper;
using EBond_FO.Models;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EBond_FO.Repositories
{
    public static class BondRepository
    {
        public static async Task<List<IFG_Corporate_Bond_Info>> GetAll(string symbol = "", string fromdate = "", string todate = "")
        {
            var procedure = "IFG_Corporate_Bond_Info_GetAll";

            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                var results = await connection.QueryAsync<IFG_Corporate_Bond_Info>(
                    procedure, new { Symbol = symbol, FromDate = fromdate, ToDate = todate },
                    commandType: CommandType.StoredProcedure);

                return results.ToList();
            }
        }
    }
}
