using Eflatun.SceneReference;
using UnityEngine;
using VContainer;

namespace Runtime
{
    public class UnityComponent : MonoBehaviour
    {
        // Field attribute injection
        [Inject] private IBar _bar;

        // Property attribute injection
        [Inject] private Camera Camera { get; set; }

        // Injection method 
        [Inject] private void Construct(SceneReference sceneRef)
        {
        }
    }
}