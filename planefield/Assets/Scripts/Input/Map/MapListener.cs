using Input.InputActions.PLayer;
using Input.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input.Map
{
    public class MapListener : MonoBehaviour
    {
        private IInputNotifier _inputNotifier;
        
        [Inject]
        private void Constructor(IInputProvider inputProvider)
        {
            _inputNotifier = (IInputNotifier)inputProvider;
        }

        [UsedImplicitly]
        private void OnMove(InputValue value)
        {
            var action = new PlayerMoveInputAction(value.Get<Vector2>());
            _inputNotifier.NotifyAction(action);
        }

        [UsedImplicitly]
        private void OnDirect(InputValue value)
        {
            var action = new PlayerDirectInputAction(value.Get<Vector2>());
            _inputNotifier.NotifyAction(action);
        }

        [UsedImplicitly]
        private void OnShoot(InputValue value)
        {
            var action = new PlayerShootInputAction(value.isPressed);
            _inputNotifier.NotifyAction(action);
        }
    }
}
