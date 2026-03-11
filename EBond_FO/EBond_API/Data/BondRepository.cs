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

        // symbol/name = null or "" → return all; otherwise filter by each field (accent-insensitive)
        public async Task<List<IFG_Corporate_Bond_Info>> GetAllAsync(string? symbol = null, string? name = null)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<IFG_Corporate_Bond_Info>(
                "API_IFG_Corporate_Bond_Info_GetALL",
                new { Symbol = symbol, Name = name },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
