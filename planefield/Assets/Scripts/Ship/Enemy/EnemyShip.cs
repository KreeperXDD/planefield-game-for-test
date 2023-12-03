using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Ship.Enemy
{
    public class EnemyShip : MonoBehaviour
    {
        [Inject] private ShipController _ship;

        private void Update()
        {
            MoveTowardsPlayer();
        }

        private void MoveTowardsPlayer()
        {
            if (_ship == null)
            {
                return;
            }
            Debug.Log(_ship);
            
            var direction = _ship.transform.position - transform.position;
            transform.Translate(direction.normalized * Time.deltaTime);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<Vector3, EnemyShip>
        {
            [Inject] private DiContainer _diContainer;

            public override EnemyShip Create(Vector3 vector)
            {
                var shipPrefab = Addressables.LoadAssetAsync<GameObject>("ShipPrefab/EnemyShip").WaitForCompletion();

                var newVector = new Vector3(vector.x, vector.y, 0);

                var ship = _diContainer.InstantiatePrefabForComponent<EnemyShip>(shipPrefab, newVector,
                    Quaternion.identity, null);

                return ship;
            }

            private void OnDeadShipHandle(EnemyShip ship)
            {
                ship.gameObject.SetActive(false);
                _pool.Return(ship);
            }
        }
    }
}