namespace EBond_API.Data
{
    using EBond_API.Models;
    using Microsoft.Data.SqlClient;
    using System.Data;

    public class AuthRepository
    {
        private readonly SqlConnectionFactory _factory;

        public AuthRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            using var conn = _factory.CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "sp_User_GetByUsername";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(
                new SqlParameter("@Username", username));

            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.Read())
                return null;

            return new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                PasswordHash = reader.GetString(2)
            };
        }
    }
}
