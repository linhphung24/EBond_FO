namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.ConnectDB;
    using EBond_API.Models;
    using System.Data;

    public class UserRepository
    {
        private readonly SqlConnectionFactory _factory;

        public UserRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<MCAccountModels?> GetAccountAsync(string custodycd)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryFirstOrDefaultAsync<MCAccountModels>(
                "MCAccount_GetDetail_ByCustodyID",
                new { CustodyID = custodycd },
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
