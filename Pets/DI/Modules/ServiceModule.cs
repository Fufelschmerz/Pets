using Autofac;
using Pets.BLL.Services.AnimalService;
using Pets.BLL.Services.BreedService;
using Pets.BLL.Services.FeedingService;
using Pets.BLL.Services.FoodService;
using Pets.Core.Abstractions.Animals.Services;
using Pets.Core.Abstractions.Services.Animals;
using Pets.Core.Abstractions.Services.Breeds;
using Pets.Core.Abstractions.Services.Feedings;
using Pets.Core.Abstractions.Services.Foods;

namespace Pets.DI.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FoodService>().As<IFoodService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnimalService>().As<IAnimalService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<FeedingService>().As<IFeedingService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<BreedService>().As<IBreedService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<CatService>().As<ICatService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DogService>().As<IDogService>()
                .InstancePerLifetimeScope();
        }
    }
}
