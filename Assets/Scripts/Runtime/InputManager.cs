using System;
using UnityEngine;
using VContainer.Unity;

namespace Runtime
{
    // Zenject: Similar ITickable interface
    public class InputManager : ITickable
    {
        public event Action ButtonClicked;
        
        void ITickable.Tick()
        {
            if (Input.GetMouseButtonUp(0)) // primary button
            {
                ButtonClicked?.Invoke();
            }
        }
    }
}