using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class InstantiatePrefabOnSpaceKeyClick : IInitializable
    {
        [Inject] private IObjectResolver _objectResolver;
        [Inject] private InputManager _inputManager;
        private readonly GameObject _prefab;

        public InstantiatePrefabOnSpaceKeyClick(GameObject prefab)
        {
            _prefab = prefab;
        }

        void IInitializable.Initialize()
        {
            _inputManager.SpaceKeyClicked += OnSpaceKeyClicked;
        }

        private void OnSpaceKeyClicked()
        {
            var instance = _objectResolver.Instantiate(_prefab);
            UnityEngine.Debug.Log($"{nameof(InstantiatePrefabOnSpaceKeyClick)}: Created new instance={instance.name}", instance);
        }
    }
}