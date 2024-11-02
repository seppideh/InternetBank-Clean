using System.Text.Json.Serialization;

namespace InternetBank.Domain.BankAccounts.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public int Amount { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV2 { get; set; } = string.Empty;
        public string ExpireDate { get; set; } = string.Empty;
        public string StaticPassword { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User ApplicationUser { get; set; } = new User();
        public ICollection<BankTransaction> Transactions { get; set; } = new List<BankTransaction>();
    }
}