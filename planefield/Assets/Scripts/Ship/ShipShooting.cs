using Input.InputActions.PLayer;
using Input.Interfaces;
using UnityEngine;
using Zenject;

namespace Ship
{
    public class ShipShooting : MonoBehaviour
    {
        [Inject] private IInputProvider _inputProvider;

        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _bulletSpeed;

        private bool _shoot;

        private void Start()
        {
            _inputProvider.RegisterAction<PlayerShootInputAction>(OnShootActionHandle);
        }

        private void OnShootActionHandle(PlayerShootInputAction action)
        {
            _shoot = action.IsShooting;
            Shoot();
        }

        private void Shoot()
        {
            if (_shoot)
            {
                factory.create;
            }
        }

        private GameObject GetInstanceBullet()
        {
            var obj = Instantiate(_bulletPrefab, _firePoint.position, gameObject.transform.rotation);
            obj.SetActive(false);
            return obj;
        }
    }
}