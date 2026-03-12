namespace EBond_API.Data
{
    using Dapper;
    using EBond_API.Models;
    using System.Data;
    public class UserRepository
    {
        private readonly SqlConnectionFactory _factory;

        public UserRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }
    }
}
