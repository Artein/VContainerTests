using System.Threading;
using Cysharp.Threading.Tasks;
using Eflatun.SceneReference;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Runtime
{
    public readonly struct LoadSceneCommand
    {
        private readonly SceneReference _sceneRef;
        private readonly LifetimeScope _lifetimeScope;

        public LoadSceneCommand(SceneReference sceneRef, LifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _sceneRef = sceneRef;
        }

        public async UniTask PerformAsync(CancellationToken cancellationToken)
        {
            using (LifetimeScope.EnqueueParent(_lifetimeScope))
            {
                UnityEngine.Debug.Log($"Scene '{_sceneRef.Name}' loading starting");
                
                await SceneManager.LoadSceneAsync(_sceneRef.BuildIndex, LoadSceneMode.Additive);
                
                UnityEngine.Debug.Log($"Scene '{_sceneRef.Name}' loading finished");
            }
        }
    }
}