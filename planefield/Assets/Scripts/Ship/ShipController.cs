using Input.InputActions.PLayer;
using Input.Interfaces;
using UnityEngine;
using Zenject;

namespace Ship
{
    public class ShipController : MonoBehaviour
    {
        [Inject] private IInputProvider _inputProvider;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private Camera _mainCamera;

        private CharacterController _characterController;
        private Vector2 _moveVector;
        private Vector2 _directVector;
        private float _speed;
        
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();

            RegistrationActions();
        }

        private void Update()
        {
            Move();
        }

        private void FixedUpdate()
        {
            ShipRotation();
        }

        private void RegistrationActions()
        {
            _inputProvider.RegisterAction<PlayerMoveInputAction>(OnMoveActionHandle);
            _inputProvider.RegisterAction<PlayerDirectInputAction>(OnDirectActionHandle);
        }

        private void OnMoveActionHandle(PlayerMoveInputAction action)
        {
            _moveVector = action.Vector;
        }

        private void OnDirectActionHandle(PlayerDirectInputAction action)
        {
            _directVector = action.Vector;
        }

        private void Move()
        {
            var targetSpeed = _moveSpeed;

            if (_moveVector == Vector2.zero)
            {
                targetSpeed = 0;
            }

            _speed = targetSpeed;
            
            _characterController.Move(_moveVector * _speed * Time.deltaTime);
        }

        private void ShipRotation()
        {
            var test = new Vector3(_directVector.x, _directVector.y, 10f);
            
            var mousePosition = _mainCamera.ScreenToWorldPoint(test) - transform.position;
            
            var angle = (float)Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}