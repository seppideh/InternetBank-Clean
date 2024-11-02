using System.Text.Json.Serialization;

namespace InternetBank.Domain.ApplicationUser.Users.Entities
{
    public class User : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}