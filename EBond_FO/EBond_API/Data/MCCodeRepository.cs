namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.ConnectDB;
    using EBond_API.Models;
    using System.Data;

    public class MCCodeRepository
    {
        private readonly SqlConnectionFactory _factory;

        public MCCodeRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<MCCodeModels>> GetSecurityTradingStatusAsync()
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<MCCodeModels>(
                "API_MCCode_GetSecurityTradingStatus",
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
