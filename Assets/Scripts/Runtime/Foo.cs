using UnityEngine;
using VContainer;

namespace Runtime
{
    public class Foo
    {
        // Zenject: Field attribute injection
        [Inject] private IBar _bar;
        
        // Zenject: Property attribute injection
        [Inject] private Camera _camera { get; set; }

        public void Validate()
        {
            UnityEngine.Debug.Log($"{nameof(Foo)} Injected field interface IBar={_bar}");
            UnityEngine.Debug.Log($"{nameof(Foo)}: Injected property Unity's Camera={_camera.name}");
        }
    }
}