using EBond_API.ConnectDB;
using EBond_API.Data;
using EBond_API.DTO;
using EBond_API.Models;

namespace EBond_API.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;
        private readonly TokenService _tokenService;
        private readonly AuthRepository _authRepo;

        public AuthService(AppDbContext db, TokenService tokenService, AuthRepository authRepo)
        {
            _db = db;
            _tokenService = tokenService;
            _authRepo = authRepo;
        }

        public async Task<TokenResponse> Login(LoginRequest request, string ip)
        {
            var user = await _authRepo.GetUserByUsername(request.Username);

            if (user == null)
                throw new Exception("Tài khoản không tồn tại");

            if (string.IsNullOrEmpty(user.PasswordHash))
                throw new Exception("Tài khoản chưa được cấu hình mật khẩu");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Mật khẩu không đúng");

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var tokenHash = HashHelper.Hash(refreshToken);

            _db.RefreshTokens.Add(new RefreshTokenModels
            {
                UserID = user.Id,
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
                throw new Exception("Token không hợp lệ");

            if (token.RevokedAt != null)
                throw new Exception("Token đã bị thu hồi");

            if (token.ExpiryDate < DateTime.UtcNow)
                throw new Exception("Token đã hết hạn");

            var user = await _authRepo.GetUserById(token.UserID);

            if (user == null)
                throw new Exception("Tài khoản không tồn tại");

            var newRefreshToken = _tokenService.GenerateRefreshToken();
            var newHash = HashHelper.Hash(newRefreshToken);

            token.RevokedAt = DateTime.UtcNow;
            token.ReplacedByTokenHash = newHash;

            _db.RefreshTokens.Add(new RefreshTokenModels
            {
                UserID = token.UserID,
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
