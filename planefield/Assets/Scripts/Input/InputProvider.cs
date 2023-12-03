using System;
using System.Collections.Generic;
using Input.Interfaces;
using JetBrains.Annotations;

namespace Input
{
    [UsedImplicitly]
    public class InputProvider : IInputProvider, IInputNotifier
    {
        private Dictionary<Type, List<Delegate>> _actionEvents;

        public InputProvider()
        {
            _actionEvents = new Dictionary<Type, List<Delegate>>();
        }

        public void NotifyAction<TAction>(TAction action) where TAction : IInputAction
        {
            var type = typeof(TAction);

            if (_actionEvents.TryGetValue(type, out var callbacks))
            {
                for (int index = 0, count = callbacks.Count; index < count; index++)
                {
                    var callback = callbacks[index];

                    callback?.DynamicInvoke(action);
                }
            }
        }

        public void RegisterAction<TAction>(Action<TAction> callback) where TAction : IInputAction
        {
            var type = typeof(TAction);

            if (_actionEvents.TryGetValue(type, out var callbacks))
            {
                callbacks.Add(callback);
                return;
            }

            callbacks = new List<Delegate>() { callback };

            _actionEvents.Add(type, callbacks);
        }

        public void UnregisterAction<TAction>(Action<TAction> callback) where TAction : IInputAction
        {
            var type = typeof(TAction);

            if (_actionEvents.TryGetValue(type, out var callbacks))
            {
                callbacks.Remove(callback);
            }
        }
    }
}