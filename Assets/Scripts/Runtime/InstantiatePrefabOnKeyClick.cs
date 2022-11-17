using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class InstantiatePrefabOnKeyClick : IInitializable
    {
        [Inject] private IObjectResolver _objectResolver;
        [Inject] private InputManager _inputManager;
        private readonly GameObject _prefab;
        private readonly KeyCode _keyCode;

        public InstantiatePrefabOnKeyClick(GameObject prefab, KeyCode keyCode)
        {
            _keyCode = keyCode;
            _prefab = prefab;
        }

        void IInitializable.Initialize()
        {
            _inputManager.RegisterKeyListener(_keyCode, OnKeyClicked);
        }

        private void OnKeyClicked()
        {
            var instance = _objectResolver.Instantiate(_prefab);
            UnityEngine.Debug.Log($"{nameof(InstantiatePrefabOnSpaceKeyClick)}: Created new instance={instance.name} after '{_keyCode}' key clicked", instance);
        }
    }
}