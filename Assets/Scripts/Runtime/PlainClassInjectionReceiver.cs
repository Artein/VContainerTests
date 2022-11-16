using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class PlainClassInjectionReceiver : IInitializable
    {
        // Field attribute injection
        [Inject] private IBar _bar;
        
        // Property attribute injection
        [Inject] private Camera Camera { get; set; }
        
        private readonly UnityComponent _unityComponent;

        // Constructor injection
        public PlainClassInjectionReceiver(UnityComponent unityComponent)
        {
            _unityComponent = unityComponent;
        }

        void IInitializable.Initialize()
        {
            UnityEngine.Debug.Log($"{nameof(PlainClassInjectionReceiver)} injections:");
            UnityEngine.Debug.Log($"\t\tInjected field interface IBar={_bar}");
            UnityEngine.Debug.Log($"\t\tInjected property Unity's Camera={Camera.name}");
            UnityEngine.Debug.Log($"\t\tInjected field UnityComponent={_unityComponent.name}");
        }
    }
}