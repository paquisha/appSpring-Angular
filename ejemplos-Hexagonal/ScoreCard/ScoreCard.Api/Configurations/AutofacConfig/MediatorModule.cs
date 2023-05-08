using System.Reflection;
using Autofac;
using MediatR;
using ScoreCard.Application.Queries.CustomerQueries;
using ScoreCard.Application.Queries.SubscriptionQueries;
using ScoreCard.Infrastructure.Behaviours;
using Module = Autofac.Module;

namespace ScoreCard.Api.Configurations.AutofacConfig;

public class MediatorModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(ReadCustomerQuery).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
        
        builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        builder.RegisterGeneric(typeof(LogTransactionBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }

    
}