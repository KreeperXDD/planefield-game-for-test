using Ship;
using Ship.Enemy;
using UnityEngine;
using Zenject;

namespace IoC
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private ShipController _ship;

        public override void InstallBindings()
        {
            Container
                .Bind<ShipController>()
                .FromInstance(_ship)
                .AsSingle();
            
            Container
                .BindFactory<Vector3, EnemyShip, EnemyShip.Factory>()
                .AsSingle()
                .NonLazy();
        }
    }
}