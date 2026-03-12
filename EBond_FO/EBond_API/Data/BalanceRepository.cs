namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.Models;
    using System.Data;

    public class BalanceRepository
    {
        private readonly SqlConnectionFactory _factory;

        public BalanceRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<Balance?> GetBalanceAsync(string custodycd)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryFirstOrDefaultAsync<Balance>(
                "TCAccountTransactionBond_GetBalance",
                new { CustodyID = custodycd },
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
