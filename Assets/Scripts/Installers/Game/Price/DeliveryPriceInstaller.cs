using Game.Services.DeliveryPriceService.PricePipeline.Impl;
using Zenject;

namespace Installers.Game.Price
{
    public class DeliveryPriceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DeliveryDistancePriceMultiplier>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeliveryItemsAmountMultiplier>().AsSingle();
        }
    }
}