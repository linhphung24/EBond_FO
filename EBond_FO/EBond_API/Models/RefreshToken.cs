namespace EBond_API.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public int UserID { get; set; }

        public string TokenHash { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? Device { get; set; }
        public string? UserAgent { get; set; }

        public DateTime? RevokedAt { get; set; }

        public string? ReplacedByTokenHash { get; set; }

        public string? IpAddress { get; set; }
    }
}
