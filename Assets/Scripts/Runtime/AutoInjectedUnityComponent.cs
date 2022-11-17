using Eflatun.SceneReference;
using UnityEngine;
using VContainer;

namespace Runtime
{
    // A game object with this component is assigned to XLifetimeScope->Auto injected game objects
    public class AutoInjectedUnityComponent : MonoBehaviour
    {
        // Injection method 
        [Inject] private void Construct(SceneReference sceneRef)
        {
            UnityEngine.Debug.Log($"{nameof(AutoInjectedUnityComponent)}: Construct()", this);
        }
    }
}