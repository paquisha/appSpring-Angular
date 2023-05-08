using Autofac;
using Module = Autofac.Module;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Infrastructure.Repositories;

namespace ScoreCard.Api.Configurations.AutofacConfig;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerRepository>()
            .As<ICustomerRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<CustomerSecretInformationRepository>()
            .As<ICustomerSecretInformationRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SubscriptionRepository>()
            .As<ISubscriptionRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SecurityScoreControlRepository>()
            .As<ISecurityScoreControlRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SecurityScoreSnapshotRepository>()
            .As<ISecutiryScoreSnapshotRepository>()
            .InstancePerLifetimeScope();
    }
}