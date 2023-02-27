namespace SoftBankApp.Entities
{
    public class Notifications : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Users Login { get; set; }
        public bool IsDisplayed { get; set; }
    }
}
