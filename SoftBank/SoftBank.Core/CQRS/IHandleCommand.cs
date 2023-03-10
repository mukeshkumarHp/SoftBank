namespace SoftBankApp.Core
{
    public interface IHandleCommand
    {

    }
    public interface IHandleCommand<TCommand> : IHandleCommand
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
