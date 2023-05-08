using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using MediatR;
using ScoreCard.Application.Queries.QueriesAZR;
using ScoreCard.Infrastructure.Behaviours;

namespace ScoreCard.Worker.Configurations.Autoconfig;

public class MediatorModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(ReadSecurityScoreControlAZRQuery).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));


        builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        builder.RegisterGeneric(typeof(LogTransactionBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}
