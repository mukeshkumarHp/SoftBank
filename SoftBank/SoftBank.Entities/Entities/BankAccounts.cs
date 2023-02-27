using System.Text.Json.Serialization;

namespace SoftBankApp.Entities
{
    public class BankAccounts : IEntity
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        [JsonIgnore]
        public Users UserEntity { get; set; }
    }
}
