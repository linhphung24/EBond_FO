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
            cmd.Parameters.Add(new SqlParameter("@Username", username));

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            return new User
            {
                Id           = reader.GetInt32(0),
                Username     = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                PasswordHash = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
            };
        }

        public async Task<User?> GetUserById(int id)
        {
            using var conn = _factory.CreateConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "sp_User_GetById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", id));

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            return new User
            {
                Id           = reader.GetInt32(0),
                Username     = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                PasswordHash = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
            };
        }
    }
}
