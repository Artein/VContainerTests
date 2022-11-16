using UnityEngine;
using VContainer;

namespace Runtime
{
    public class Foo
    {
        // Zenject: Field attribute injection
        [Inject] private IBar _bar;
        
        // Zenject: Property attribute injection
        [Inject] private Camera Camera { get; set; }
        
        [Inject] private UnityComponent _unityComponent;

        public void Validate()
        {
            UnityEngine.Debug.Log($"{nameof(Foo)} injections:");
            UnityEngine.Debug.Log($"\t\tInjected field interface IBar={_bar}");
            UnityEngine.Debug.Log($"\t\tInjected property Unity's Camera={Camera.name}");
            UnityEngine.Debug.Log($"\t\tInjected field UnityComponent={_unityComponent.name}");
        }
    }
}