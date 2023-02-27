using System;

namespace SoftBankApp.Core
{
    public interface IEvent
    {
        DateTime OccurredOn { get; }
    }
}
