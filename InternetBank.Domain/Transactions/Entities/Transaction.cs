namespace InternetBank.Domain.Transactions.Entities
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public string SorceCardNumber { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string DestinationCardNumber { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public Account Account { get; set; } = new Account();
        public User ApplicationUser { get; set; } = new User();
    }
}