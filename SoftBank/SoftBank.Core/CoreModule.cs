using Autofac;
using SoftBank.Core;
using SoftBank.Core.IServices;
using SoftBank.Core.Services;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBankApp.Core
{
    /// <summary>
    /// Register Core components to autofac container.
    /// </summary>
    internal class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<LocalDataContext>().AsSelf();
            builder.RegisterType<UserService>().As(typeof(IUserService)).InstancePerLifetimeScope();
            builder.RegisterType<MoneyTransferService>().As(typeof(IMoneyTransferService)).InstancePerLifetimeScope();
            builder.RegisterType<EventService>().As(typeof(IEventService)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).SingleInstance().AsSelf();
        }
    }
}
