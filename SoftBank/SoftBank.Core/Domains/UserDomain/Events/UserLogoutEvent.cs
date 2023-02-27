using SoftBankApp.Core;

namespace SoftBankApp.Core.Domains.UserDomain.Events
{
    public class UserLogoutEvent : DomainEventBase
    {
        public int UserId { get; set; }
    }
}
