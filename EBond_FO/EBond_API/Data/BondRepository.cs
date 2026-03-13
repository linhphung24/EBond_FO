namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.ConnectDB;
    using EBond_API.Models;
    using System.Data;

    public class BondRepository
    {
        private readonly SqlConnectionFactory _factory;

        public BondRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        // search = null or "" → return all; matches both symbol and name (accent-insensitive)
        public async Task<List<IFG_Corporate_Bond_InfoModels>> GetAllAsync(
            string? search                = null,
            int?    securityTradingStatus = null)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<IFG_Corporate_Bond_InfoModels>(
                "API_IFG_Corporate_Bond_Info_GetALL",
                new
                {
                    Search                = search,
                    SecurityTradingStatus = securityTradingStatus
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
