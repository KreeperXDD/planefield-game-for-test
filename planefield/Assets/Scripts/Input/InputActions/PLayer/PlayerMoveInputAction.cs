using Input.Interfaces;
using UnityEngine;


namespace Input.InputActions.PLayer
{
    public class PlayerMoveInputAction : IInputAction
    {
        public readonly Vector2 Vector;

        public PlayerMoveInputAction(Vector2 vector)
        {
            Vector = vector;
        }
    }
}
