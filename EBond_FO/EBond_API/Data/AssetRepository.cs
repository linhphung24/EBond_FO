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

        public async Task<List<Asset>> GetAssetByCustomerAsync(string custodycd)
        {
            using var conn = _factory.CreateConnection();

            var result = await conn.QueryAsync<Asset>(
                "SCMAST_CheckQuantity",
                new { custodycd },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
