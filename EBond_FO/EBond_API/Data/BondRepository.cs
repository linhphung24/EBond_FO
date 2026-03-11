namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.Models;
    using System.Data;

    public class BondRepository
    {
        private readonly SqlConnectionFactory _factory;

        public BondRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        // null or "" → skip filter (return all for that field)
        public async Task<List<IFG_Corporate_Bond_Info>> GetAllAsync(
            string? symbol                = null,
            string? name                  = null,
            int?    securityTradingStatus = null)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<IFG_Corporate_Bond_Info>(
                "API_IFG_Corporate_Bond_Info_GetALL",
                new
                {
                    Symbol                = symbol,
                    Name                  = name,
                    SecurityTradingStatus = securityTradingStatus
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
