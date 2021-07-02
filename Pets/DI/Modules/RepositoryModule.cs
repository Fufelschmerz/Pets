using Autofac;
using Pets.Core.Abstractions.Repositories;
using Pets.Core.Domain.Entities;
using Pets.DataAccess.Repository.Animals;
using Pets.DataAccess.Repository.Breeds;
using Pets.DataAccess.Repository.Feedings;
using Pets.DataAccess.Repository.Foods;

namespace Pets.DI.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FoodRepository>().As<IFoodRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnimalRepository<AnimalEntity>>().As<IAnimalRepository<AnimalEntity>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FeedingRepository>().As<IFeedingRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BreedRepository>().As<IBreedRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnimalRepository<Cat>>().As<IAnimalRepository<Cat>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnimalRepository<Dog>>().As<IAnimalRepository<Dog>>()
                .InstancePerLifetimeScope();
        }
    }
}
