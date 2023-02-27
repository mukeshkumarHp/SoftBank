using System.Text.Json.Serialization;

namespace SoftBank.Core.Models
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        [JsonIgnore]
        public UserViewModel UserEntity { get; set; }
    }
}
