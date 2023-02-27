namespace SoftBankApp.Entities
{
    public class InvalidKeys : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
    }
}
