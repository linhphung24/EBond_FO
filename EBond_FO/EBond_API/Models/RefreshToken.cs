namespace EBond_API.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public string TokenHash { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public string ReplacedByTokenHash { get; set; }

        public string IpAddress { get; set; }

        public User User { get; set; }
    }
}
