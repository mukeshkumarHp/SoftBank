namespace SoftBankApp.Core
{
    public interface IQueryBus
    {
        TResult Send<TQuery, TResult>(TQuery command) where TQuery : IQuery;
    }
}