namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.Models;
    using System.Data;

    public class MCCodeRepository
    {
        private readonly SqlConnectionFactory _factory;

        public MCCodeRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<MCCode>> GetSecurityTradingStatusAsync()
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<MCCode>(
                "API_MCCode_GetSecurityTradingStatus",
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
