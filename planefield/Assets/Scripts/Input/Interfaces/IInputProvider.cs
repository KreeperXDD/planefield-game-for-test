using System;

namespace Input.Interfaces
{
    public interface IInputProvider
    {
        public void RegisterAction<TAction>(Action<TAction> callback) where TAction : IInputAction;
        public void UnregisterAction<TAction>(Action<TAction> callback) where TAction : IInputAction;
    }
}