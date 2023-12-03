using Ship;
using UnityEngine;
using Zenject;

namespace IoC
{
    public class AppMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ServiceInstaller.Install(Container);
        }
    }
}