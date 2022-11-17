using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace Runtime
{
    // Zenject: Similar ITickable interface
    public sealed class InputManager : ITickable
    {
        public event Action MousePrimaryButtonClicked;
        public event Action SpaceKeyClicked;

        private readonly List<KeyValuePair<KeyCode, Action>> _keyListeners = new();

        public IDisposable RegisterKeyListener(KeyCode keyName, Action keyClicked)
        {
            _keyListeners.Add(new KeyValuePair<KeyCode, Action>(keyName, keyClicked));

            return new DisposableAction(() =>
            {
                _keyListeners.RemoveAll(pair => pair.Key == keyName);
            });
        }
        
        void ITickable.Tick()
        {
            if (Input.GetMouseButtonUp(0)) // primary button
            {
                MousePrimaryButtonClicked?.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                SpaceKeyClicked?.Invoke();
            }

            for (int i = 0; i < _keyListeners.Count; i++)
            {
                var pair = _keyListeners[i];
                if (Input.GetKeyUp(pair.Key))
                {
                    pair.Value.Invoke();
                }
            }
        }
    }
}