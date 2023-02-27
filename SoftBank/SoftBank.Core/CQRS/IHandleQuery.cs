namespace SoftBankApp.Core
{
    public interface IHandleQuery
    {

    }
    public interface IHandleQuery<TQuery,TResult> : IHandleQuery
        where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }
}