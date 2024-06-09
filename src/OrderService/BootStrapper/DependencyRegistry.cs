using Autofac;
using OrderService.Repositories.Base;
using OrderService.Configuration;
using OrderService.Repositories.Database;
using OrderService.Repositories.Domain.OrderRepository;
using OrderService.Services.Domain.OrderServices;

namespace OrderService.BootStrapper
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Configuration
            builder.RegisterType<DataConnectionProvider>().As<IDataConnection>();
            builder.RegisterType<DBConfig>().As<IDBConfig>().InstancePerLifetimeScope();

            //Repositories
            builder.RegisterGeneric(typeof(BaseRepository<,>)).As(typeof(IBaseRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();

            //Services
            builder.RegisterType<OrderService.Services.Domain.OrderServices.OrderService>().As<IOrderService>().InstancePerLifetimeScope();
        }
    }
}
