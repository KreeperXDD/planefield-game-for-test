using Input.Interfaces;
using UnityEngine;

namespace Input.InputActions.PLayer
{
    public class PlayerShootInputAction : IInputAction
    {
        public readonly bool IsShooting;

        public PlayerShootInputAction(bool isShooting)
        {
            IsShooting = isShooting;
        }
        
    }
}
