namespace SoftBankApp.Core
{
    public interface ICommandsBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
