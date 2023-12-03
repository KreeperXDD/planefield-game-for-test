using Input.Interfaces;
using UnityEngine;

namespace Input.InputActions.PLayer
{
    public class PlayerDirectInputAction : IInputAction
    {
        public readonly Vector2 Vector;

        public PlayerDirectInputAction(Vector2 vector)
        {
            Vector = vector;
        }
    }
}