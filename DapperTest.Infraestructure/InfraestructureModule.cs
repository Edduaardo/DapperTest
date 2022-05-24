using Autofac;
using DapperTest.Core.Aggregates.ProdutoAggregate;
using DapperTest.Infraestructure.Data;
using DapperTest.SharedKernel.Interfaces;

namespace DapperTest.Infraestructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseConnection>()
                .As<IDatabaseConnection>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            builder.RegisterType<ProductRepository>()
                .As<IProdutoRepository<Product>>()
                .WithParameter(
                    new TypedParameter(typeof(string), "Produtos"))
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IDatabaseConnection) && pi.Name == "connection",
                    (pi, ctx) => ctx.Resolve<IDatabaseConnection>())
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IUnitOfWork) && pi.Name == "unitOfWork",
                    (pi, ctx) => ctx.Resolve<IUnitOfWork>());
        }
    }
}
