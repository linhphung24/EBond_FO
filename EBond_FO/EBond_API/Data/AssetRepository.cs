namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.Models;
    using System.Data;

    public class AssetRepository
    {
        private readonly SqlConnectionFactory _factory;

        public AssetRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<AssetViewModels>> GetAssetByCustomerAsync(string custodycd)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<AssetViewModels>(
                "SCMAST_CheckQuantity",
                new { custodycd },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task<BalanceViewModels?> GetBalanceAsync(string custodycd)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryFirstOrDefaultAsync<BalanceViewModels>(
                "TCAccountTransactionBond_GetBalance",
                new { CustodyID = custodycd },
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
