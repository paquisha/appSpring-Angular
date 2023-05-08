using Autofac;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Infrastructure.AzureResourceExplorer;
using ScoreCard.Infrastructure.Repositories;

namespace ScoreCard.Worker.Configurations.Autoconfig;

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
        builder.RegisterType<SecurityScoreSnapshotRepository>()
            .As<ISecutiryScoreSnapshotRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SecurityScoreControlAZRRepository>()
            .As<ISecurityScoreControlAZR>()
            .InstancePerLifetimeScope();
       builder.RegisterType<SecureScoreAZRRepository>()
            .As<ISecureScoreAZR>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SecurityPlanAZRRepository>()
            .As<ISecurityPlanAZR>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SecurityStandardAZRRepository>()
            .As<ISecurityStandardAZR>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ControlRecommendationAZRRepository>()
            .As<IControlRecommendationAZR>()
            .InstancePerLifetimeScope();
        
    }
}