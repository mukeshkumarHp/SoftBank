namespace SoftBankApp.Core
{
    public interface IQuery
    {
    }
    public interface IQuery<TQuery> where TQuery : IQuery<TQuery>
    {
    }
}