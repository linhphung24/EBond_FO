using EBond_API.Data;
using EBond_API.DTO;
using EBond_API.Models;

namespace EBond_API.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;
        private readonly TokenService _tokenService;

        public AuthService(AppDbContext db, TokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        public async Task<TokenResponse> Login(LoginRequest request, string ip)
        {
            var user = _db.Users
                .SingleOrDefault(x => x.Username == request.Username);

            if (user == null)
                throw new Exception("Invalid user");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid password");

            var accessToken = _tokenService.GenerateAccessToken(user);

            var refreshToken = _tokenService.GenerateRefreshToken();

            var tokenHash = HashHelper.Hash(refreshToken);

            _db.RefreshTokens.Add(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = tokenHash,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IpAddress = ip
            });

            await _db.SaveChangesAsync();

            return new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        public async Task<TokenResponse> Refresh(string refreshToken)
        {
            var hash = HashHelper.Hash(refreshToken);

            var token = _db.RefreshTokens
                .SingleOrDefault(x => x.TokenHash == hash);

            if (token == null)
                throw new Exception("Invalid token");

            if (token.RevokedAt != null)
                throw new Exception("Token revoked");

            if (token.ExpiryDate < DateTime.UtcNow)
                throw new Exception("Token expired");

            var user = _db.Users.Find(token.UserId);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            var newHash = HashHelper.Hash(newRefreshToken);

            token.RevokedAt = DateTime.UtcNow;
            token.ReplacedByTokenHash = newHash;

            _db.RefreshTokens.Add(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = newHash,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            });

            var accessToken = _tokenService.GenerateAccessToken(user);

            await _db.SaveChangesAsync();

            return new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
