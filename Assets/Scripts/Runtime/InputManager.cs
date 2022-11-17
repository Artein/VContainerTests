using System;
using UnityEngine;
using VContainer.Unity;

namespace Runtime
{
    // Zenject: Similar ITickable interface
    public class InputManager : ITickable
    {
        public event Action MousePrimaryButtonClicked;
        public event Action SpaceKeyClicked;
        
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
        }
    }
}