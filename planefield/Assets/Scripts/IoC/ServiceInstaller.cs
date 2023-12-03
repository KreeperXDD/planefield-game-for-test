using Input;
using Input.Interfaces;
using JetBrains.Annotations;
using Zenject;

namespace IoC
{
    [UsedImplicitly]
    public class ServiceInstaller:Installer<ServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IInputProvider>()
                .To<InputProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}